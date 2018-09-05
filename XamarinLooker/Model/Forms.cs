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

    public class LookerForm
    {
        [JsonProperty(PropertyName ="content")]
        public string Content { get; set; }
    }

    public class Client
    {
        [JsonProperty(PropertyName = "On-Site Contact")]
        public OnSiteContact OnSiteContact { get; set; }

        public Location Location { get; set; }

        [JsonProperty(PropertyName = "Document Location")]
        public Location DocumentLocation { get; set; }
    }

    public class Location
    {
        public Coordinates Coordinates { get; set; }
    }

    public class Coordinates
    {
        [JsonProperty(PropertyName ="coordinates")]
        public string[] Points { get; set; }
    }
   
    public class OnSiteContact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}