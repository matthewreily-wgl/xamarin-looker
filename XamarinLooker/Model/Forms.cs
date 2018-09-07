using Newtonsoft.Json;

namespace XamarinLooker.Model
{
    public class Forms
    {
        [JsonProperty(PropertyName = "client")]
        public Client Client { get; set; }

        [JsonProperty(PropertyName ="looker")]
        public LookerForm Looker { get; set; }
    }
}