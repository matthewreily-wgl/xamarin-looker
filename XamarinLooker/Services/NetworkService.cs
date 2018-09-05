﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
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
            var settings = _settingsService.GetSettings();
            if (string.IsNullOrEmpty(settings.AuthAccessToken))
            {
              throw new AuthenticationException("User is not Authenticated");
            }
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", settings.AuthAccessToken);

            //ToDo: replace hardcoded url with a settings property
            var response = await client.GetAsync($"https://apidev.wegolook.com/users/{ settings.UserId }/looks");

            var looks = JsonConvert.DeserializeObject<List<Look>>(await response.Content.ReadAsStringAsync());
            return looks.ToArray();
        }
    }
}