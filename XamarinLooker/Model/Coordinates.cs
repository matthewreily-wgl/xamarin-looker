using Newtonsoft.Json;

namespace XamarinLooker.Model
{
    public class Coordinates
    {
        [JsonProperty(PropertyName ="coordinates")]
        public string[] Points { get; set; }
    }
}