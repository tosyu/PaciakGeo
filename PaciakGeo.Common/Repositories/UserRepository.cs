using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using PaciakGeo.Common.Models;
using PaciakGeo.Common.Services;

namespace PaciakGeo.Common.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> logger;
        private readonly INpgsqlConnectionProvider npgsqlConnectionProvider;

        public UserRepository(ILogger<UserRepository> logger, INpgsqlConnectionProvider npgsqlConnectionProvider)
        {
            this.logger = logger;
            this.npgsqlConnectionProvider = npgsqlConnectionProvider;
        }

        public async Task<User> GetUser(int uid)
        {
            await using var connection = npgsqlConnectionProvider.GetConnection(DbType.PaciakGeo);
            await connection.OpenAsync();

            var result = await connection.QueryFirstOrDefaultAsync<User>(Sql.GetUser, new {Uid = uid});

            return result;
        }

        public async Task<bool> Exists(int uid)
        {
            await using var connection = npgsqlConnectionProvider.GetConnection(DbType.PaciakGeo);
            await connection.OpenAsync();
            var result = connection.QuerySingleOrDefault<int>(Sql.UserExists, new {Uid = uid});

            return result > 0;
        }

        public async Task<bool> Upsert(User user)
        {
            var exists = await Exists(user.Uid);
            
            await using var connection = npgsqlConnectionProvider.GetConnection(DbType.PaciakGeo);
            await connection.OpenAsync();

            logger.LogDebug($"Upserting user {user.Uid} with location {user.Location}");
            return await connection.ExecuteAsync(exists ? Sql.Update : Sql.Insert, user) > 0;
        }

        public async Task<bool> Delete(User user)
        {
            return await DeleteByUid(user.Uid);
        }

        public async Task<bool> DeleteByUid(int uid)
        {
            await using var connection = npgsqlConnectionProvider.GetConnection(DbType.PaciakGeo);
            await connection.OpenAsync();

            logger.LogDebug($"Deleting user {uid}");
            return await connection.ExecuteAsync(Sql.DeleteByUid, new {Uid = uid}) > 0;
        }

        public async Task<IEnumerable<User>> GetUsersForLocationUpdate(int? limit = null)
        {
            await using var connection = npgsqlConnectionProvider.GetConnection(DbType.PaciakGeo);
            await connection.OpenAsync();

            if (limit != null)
            {
                return await connection.QueryAsync<User>(Sql.GetUsersForLocationUpdateLimited, new {Limit = limit});
            }

            return await connection.QueryAsync<User>(Sql.GetUsersForLocationUpdate);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            await using var connection = npgsqlConnectionProvider.GetConnection(DbType.PaciakGeo);
            await connection.OpenAsync();

            return await connection.QueryAsync<User>(Sql.GetUsers);
        }

        private static class Sql
        {
            public const string UserExists = @"select COUNT(*) from users where uid = @Uid";
            
            public const string GetUser = @"select uid as Uid, name as Name, avatar_url as AvatarUrl, tracking_enabled as TrackingEnabled, last_updated_location as LastUpdatedLocation
                from users where uid = @Uid";
            
            public const string Insert = @"insert into users (uid, name, avatar_url, location, last_updated_location, location_latitude, location_longitude)
                values (@Uid, @Name, @AvatarUrl, @Location, current_date, @LocationLatitude, @LocationLongitude)";

            public const string Update = @"update users
                set name = @Name, avatar_url = @AvatarUrl, location = @Location, last_updated_location = @LastUpdatedLocation,
                    location_latitude = @LocationLatitude, location_longitude = @LocationLongitude
                where uid = @Uid";

            public const string DeleteByUid = @"delete * from users where uid = @Uid";
            
            public static string GetUsersForLocationUpdate = @"select 
                    uid as Uid, name as Name, avatar_url as AvatarUrl, tracking_enabled as TrackingEnabled,
                    location as Location, last_updated_location as LastUpdatedLocation, location_longitude as LocationLongitude,
                    location_latitude as LocationLatitude
                from users
                where tracking_enabled = false AND date_cmp(current_date, last_updated_location) >= 1";
            
            public static string GetUsersForLocationUpdateLimited = @"select
                    uid as Uid, name as Name, avatar_url as AvatarUrl, tracking_enabled as TrackingEnabled,
                    location as Location, last_updated_location as LastUpdatedLocation, location_longitude as LocationLongitude,
                    location_latitude as LocationLatitude
                from users
                where tracking_enabled = false AND date_cmp(current_date, last_updated_location) >= 1
                limit @Limit";

            public static string GetUsers = @"select
                    uid as Uid, name as Name, avatar_url as AvatarUrl, tracking_enabled as TrackingEnabled,
                    location as Location, last_updated_location as LastUpdatedLocation, location_longitude as LocationLongitude,
                    location_latitude as LocationLatitude
                from users";
        }
    }
}