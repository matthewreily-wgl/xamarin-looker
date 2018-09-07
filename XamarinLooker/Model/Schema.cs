using Newtonsoft.Json;

namespace XamarinLooker.Model
{
    public class Schema
    {
        [JsonProperty(PropertyName = "name")] 
        public string Name { get; set; }

        [JsonProperty(PropertyName = "lookerFee")]
        public string LookerFee { get; set; }

        [JsonProperty("fields")]
        public Field[] Fields { get; set; }

        [JsonProperty(PropertyName = "estimatedTime")]
        public EstimatedTime EstimatedTime { get; set; }
    }
}