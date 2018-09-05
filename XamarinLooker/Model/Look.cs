using System.Linq;
using Newtonsoft.Json;
using XamarinLooker.ExtensionHelpers;

namespace XamarinLooker.Model
{
    public class Look
    {
        [JsonProperty(PropertyName = "jobNumber")]
        public string JobNumber { get; set; }

        [JsonProperty(PropertyName = "forms")]
        public Forms Forms { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public string Distance { get; set; }

        [JsonProperty(PropertyName = "schema")]
        public Schema Schema { get; set; }

        [JsonProperty(PropertyName = "dueDates")]
        public DueDates DueDates { get; set; }

        [JsonProperty(PropertyName = "normalizedLookAddress")]
        public LookAddress LookAddress { get; set; }

        public string LookerDueDate
        {
            get
            {
                return DueDates?.Looker != null ? DueDates.Looker.ToDateTime().ToShortDateString() : string.Empty;
            }
        }

        public string LookerInstructions
        {
            get
            {
                if(Schema?.Fields?.Length > 0)
                {
                    return Schema.Fields.ToList().First(f => string.Compare("Looker Instructions", f.Name) == 0).Forms.Looker.Content;
                }
                return string.Empty;
            }
        }
        public string LookerFee => Schema.LookerFee.ToDollars();
    }
}