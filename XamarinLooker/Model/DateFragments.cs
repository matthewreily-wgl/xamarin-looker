using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XamarinLooker.Model
{
    public class DateFragments
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "month")]
        public string Month { get; set; }

        [JsonProperty(PropertyName = "year")]
        public string Year { get; set; }
    }
}