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

    public class EstimatedTime
    {
        [JsonProperty(PropertyName ="min")]
        public string Min { get; set; }

        [JsonProperty(PropertyName = "max")]
        public string Max { get; set; }
    }

    public class Field
    {
        [JsonProperty(PropertyName ="name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "forms")]
        public Forms Forms { get; set; } 
    }
}