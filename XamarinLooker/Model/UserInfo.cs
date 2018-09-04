using Newtonsoft.Json;

namespace XamarinLooker.Model
{
    public class UserInfo
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
    }
}