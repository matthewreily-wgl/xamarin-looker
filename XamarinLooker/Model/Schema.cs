using Newtonsoft.Json;

namespace XamarinLooker.Model
{
    public class Schema
    {
        [JsonProperty(PropertyName = "name")] 
        public string Name { get; set; }

        [JsonProperty(PropertyName = "lookerFee")]
        public string LookerFee { get; set; }
    }
}