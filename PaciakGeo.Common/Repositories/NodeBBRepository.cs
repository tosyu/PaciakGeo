using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PaciakGeo.Common.Models;
using PaciakGeo.Common.Models.Configuration;

namespace PaciakGeo.Common.Repositories
{
    public class NodeBBRepository : INodeBBRepository
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<NodeBBConfig> nodeBBOptions;

        public NodeBBRepository(HttpClient httpClient, IOptions<NodeBBConfig> nodeBBOptions)
        {
            this.httpClient = httpClient;
            this.nodeBBOptions = nodeBBOptions;
        }

        public async Task<PaciakUser> GetUserBySessionId(string sessionId)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, "/api/me");
            
            request.Headers.Add("Cookie", $"express.sid={sessionId}");

            using var result = await httpClient.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<PaciakUser>();
            }

            return null;
        }
        
        public async Task<IEnumerable<PaciakUser>> GetUsers()
        {
            var authHaderValue = $"Bearer {nodeBBOptions.Value.Token}";
            var more = true;
            var page = 0;
            var result = new List<PaciakUser>();

            do
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/users?page={page}");
                request.Headers.Add("Authorization", authHaderValue);
                
                using var responseMessage = await httpClient.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var content = await responseMessage.Content.ReadFromJsonAsync<PaciakUsers>();

                    if (content != null)
                    {
                        if (content.Users != null)
                        {
                            result.AddRange(content.Users.ToList());
                        }
                        more = content.Pagination?.Next.Active ?? false;
                        page++;
                    }
                    else
                    {
                        more = false;
                    }
                }
                else
                {
                    more = false;
                }
            } while (more);

            return result;
        }

        public async Task<PaciakUser> GetUser(string username)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/user/{username}");
            request.Headers.Add("Authorization", $"Bearer {nodeBBOptions.Value.Token}");

            using var responseMessage = await httpClient.SendAsync(request);

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<PaciakUser>();
            }

            return null;
        }

        public async Task<IEnumerable<PaciakUser>> GetUsers(string[] usernames)
        {
            var result = await Task.WhenAll(usernames.Select(GetUser));

            return result.Where(u => u != null).ToList();
        }
    }
}