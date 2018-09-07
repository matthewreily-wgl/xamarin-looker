using Newtonsoft.Json;

namespace XamarinLooker.Model
{
    public class Field
    {
        [JsonProperty(PropertyName ="name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "forms")]
        public Forms Forms { get; set; } 
    }
}