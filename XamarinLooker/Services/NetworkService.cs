using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinLooker.Model;

namespace XamarinLooker.Services
{
    public class NetworkService : INetworkService
    {
        private readonly ISettingsService _settingsService;

        public NetworkService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<Look[]> GetLooks()
        {
            using (var client = GetClient())
            {

                //ToDo: replace hardcoded url with a settings property
                var response = await client.GetAsync($"https://apidev.wegolook.com/users/{ _settingsService.GetSettings().UserId }/looks");
                var looks = JsonConvert.DeserializeObject<List<Look>>(await response.Content.ReadAsStringAsync());
                return looks.ToArray();    
            }
        }

        public async Task<string> GetMediaUploadUrlAsync(string lookId)
        {
            using (var client = GetClient())
            {
                var content = new StringContent($"fileName: {lookId}", Encoding.UTF8, "application/json");
                //ToDo: replace hard-coded url
                var result = await client.PostAsync($"https://apidev.wegolook.com/looks/{lookId}/forms/client/uploads", content);
                var stringResult = await result.Content.ReadAsStringAsync();
                return stringResult;    
            }
        }

        private HttpClient GetClient()
        {
            var settings = _settingsService.GetSettings();
            if (string.IsNullOrEmpty(settings.AuthAccessToken))
            {
                throw new AuthenticationException("User is not Authenticated");
            }
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", settings.AuthAccessToken);
            return client;
        }
    }
}