using Newtonsoft.Json;

namespace XamarinLooker.Model
{
    public class LookAddress
    {
        [JsonProperty(PropertyName = "line1")] 
        public string Line1 { get; set; }

        [JsonProperty(PropertyName = "line2")] 
        public string Line2 { get; set; }

        [JsonProperty(PropertyName = "city")] 
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")] 
        public string State { get; set; }

        [JsonProperty(PropertyName = "zip")] 
        public string Zip { get; set; }

        [JsonProperty(PropertyName = "formattedAddress")]
        public string FormattedAddress { get; set; }
    }
}