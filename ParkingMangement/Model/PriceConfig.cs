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

        [JsonProperty("cycleMilestone3")]
        public int CycleMilestone3 { get; set; }

        [JsonProperty("cycleTicketMonth")]
        public int CycleTicketMonth { get; set; }

        [JsonProperty("dayCost")]
        public int DayCost { get; set; }

        [JsonProperty("dayNightCost")]
        public int DayNightCost { get; set; }

        [JsonProperty("endHourNight")]
        public int EndHourNight { get; set; }

        [JsonProperty("hourMilestone1")]
        public int HourMilestone1 { get; set; }

        [JsonProperty("hourMilestone2")]
        public int HourMilestone2 { get; set; }

        [JsonProperty("hourMilestone3")]
        public int HourMilestone3 { get; set; }

        [JsonProperty("intervalBetweenDayNight")]
        public int IntervalBetweenDayNight { get; set; }

        [JsonProperty("isAdd")]
        public string IsAdd { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("minCost")]
        public int MinCost { get; set; }

        [JsonProperty("minMinute")]
        public int MinMinute { get; set; }

        [JsonProperty("nightCost")]
        public int NightCost { get; set; }

        [JsonProperty("startHourNight")]
        public int StartHourNight { get; set; }

        [JsonProperty("projectId")]
        public string ProjectId { get; set; }
    }
}
