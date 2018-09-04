using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XamarinLooker.Model
{
    public class DueDates
    {
        public DueDates()
        {
            Report = new DateFragments();
            Looker = new DateFragments();
        }
        [JsonProperty(PropertyName = "report")]
        public DateFragments Report { get; set; }
        [JsonProperty(PropertyName = "looker")]
        public DateFragments Looker { get; set; }
    }
}