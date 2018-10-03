using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Domains.Aws
{
    public class CognitoToken
    {
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        public DateTime ExpiresAt { get; set; }
        public bool IsValidAndNotExpiring
        {
            get
            {
                return !String.IsNullOrEmpty(this.AccessToken) &&
                this.ExpiresAt > DateTime.UtcNow.AddSeconds(30);
            }
        }
    }
}
