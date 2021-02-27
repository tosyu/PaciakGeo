using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PaciakGeo.WebApi.Models.Configuration;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Repositories
{
    public class NodeBBRepository : INodeBBRepository
    {
        private readonly HttpClient httpClient;

        public NodeBBRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<PaciakUserDto> GetUserBySessionId(string sessionId)
        {
            // GET https://paciak.pl/api/me
            // Accept: application/json
            // Cookie: express.sid=s%3AseSzKzKO4j8bCbIyFe1RoSX_cDeRetao.kbDhPgALNbmyysGzXfxl5fz2CdpsZSxWI42VgkImfT0; io=ShrdOEBWKeH76JIqAAHz
            // User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:85.0) Gecko/20100101 Firefox/85.0
            using var request = new HttpRequestMessage(HttpMethod.Get, "/api/me");
            
            request.Headers.Add("Cookie", $"express.sid={sessionId}");

            using var result = await httpClient.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<PaciakUserDto>();
            }

            return null;
        }
    }
}