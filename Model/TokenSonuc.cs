using Newtonsoft.Json;

namespace NetsisRestOrnekleri.Model
{
    public class TokenSonuc
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }

        [JsonProperty("as:client_id")]
        public string AsClientId { get; set; }
        public string username { get; set; }
        public string branchcode { get; set; }
        public string dbname { get; set; }
        public string jlogin { get; set; }

        [JsonProperty(".issued")]
        public string Issued { get; set; }

        [JsonProperty(".expires")]
        public string Expires { get; set; }
    }
}
