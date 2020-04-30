using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParkingMangement.Model
{
    public class PriceConfig
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("idPart")]
        public string IdPart { get; set; }

        [JsonProperty("parkingTypeID")]
        public int ParkingTypeID { get; set; }

        [JsonProperty("costMilestone1")]
        public int CostMilestone1 { get; set; }

        [JsonProperty("costMilestone2")]
        public int CostMilestone2 { get; set; }

        [JsonProperty("costMilestone3")]
        public int CostMilestone3 { get; set; }

        [JsonProperty("costMilestone4")]
        public int CostMilestone4 { get; set; }

        [JsonProperty("costMilestoneNight1")]
        public int CostMilestoneNight1 { get; set; }

        [JsonProperty("costMilestoneNight2")]
        public int CostMilestoneNight2 { get; set; }

        [JsonProperty("costMilestoneNight3")]
        public int CostMilestoneNight3 { get; set; }

        [JsonProperty("costMilestoneNight4")]
        public int CostMilestoneNight4 { get; set; }

        [JsonProperty("costTicketMonth")]
        public int CostTicketMonth { get; set; }

        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
    }
}
