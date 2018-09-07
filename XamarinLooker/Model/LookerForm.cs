using Newtonsoft.Json;

namespace XamarinLooker.Model
{
    public class LookerForm
    {
        [JsonProperty(PropertyName ="content")]
        public string Content { get; set; }
    }
}