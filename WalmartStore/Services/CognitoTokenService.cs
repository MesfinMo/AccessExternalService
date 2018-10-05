using AES.Configurations;
using AES.Domains.Aws;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WalmartStore.Services
{
    public class CognitoTokenService : ITokenService
    {
        private CognitoToken token = new CognitoToken();
        private readonly IOptions<AwsCognitoSettings> cognitoSettings;
        public CognitoTokenService(IOptions<AwsCognitoSettings> cognitoSettings)
        {
            this.cognitoSettings = cognitoSettings;
        }
        public async Task<string> GetTokenAsync()
        {
            if (!this.token.IsValidAndNotExpiring)
            {
                this.token = await this.GetNewTokenAsync();
            }
            return token.AccessToken;
        }
        private async Task<CognitoToken> GetNewTokenAsync()
        {
            CognitoToken token = null;
            var _client = new HttpClient();

            var clientId = this.cognitoSettings.Value.ClientId;
            var clientSecret = this.cognitoSettings.Value.ClientSecret;
            var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}");

            var path = "oauth2/token";

            //_client.BaseAddress = new Uri(this.cognitoSettings.Value.TokenUrl);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(clientCreds));
            var postMessage = new Dictionary<string, string>();
            postMessage.Add("grant_type", "client_credentials");
            postMessage.Add("scope", "");

            var request = new HttpRequestMessage(HttpMethod.Post, this.cognitoSettings.Value.TokenUrl + path)
            {
                Content = new FormUrlEncodedContent(postMessage)
            };

            try
            {
                HttpResponseMessage response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    token = JsonConvert.DeserializeObject<CognitoToken>(result);
                    token.ExpiresAt = DateTime.UtcNow.AddSeconds(token.ExpiresIn);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return token;
        }
    }
}
