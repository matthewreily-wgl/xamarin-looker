using Newtonsoft.Json;

namespace XamarinLooker.Model
{
    public class EstimatedTime
    {
        [JsonProperty(PropertyName ="min")]
        public string Min { get; set; }

        [JsonProperty(PropertyName = "max")]
        public string Max { get; set; }
    }
}