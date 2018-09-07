using Newtonsoft.Json;

namespace XamarinLooker.Model
{
    public class Client
    {
        [JsonProperty(PropertyName = "On-Site Contact")]
        public OnSiteContact OnSiteContact { get; set; }

        public Location Location { get; set; }

        [JsonProperty(PropertyName = "Document Location")]
        public Location DocumentLocation { get; set; }
    }
}