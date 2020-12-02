using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParkingMangement.Model
{
    public class DisplayConfig
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("lostCard")]
        public int LostCard { get; set; }
        [JsonProperty("bikeSpace")]
        public int BikeSpace { get; set; }
        [JsonProperty("carSpace")]
        public int CarSpace { get; set; }
        [JsonProperty("ticketLimitDay")]
        public int TicketLimitDay { get; set; }
        [JsonProperty("nightLimit")]
        public int NightLimit { get; set; }
        [JsonProperty("parkingTypeId")]
        public int ParkingTypeId { get; set; }
        [JsonProperty("expiredTicketMonthTypeID")]
        public int ExpiredTicketMonthTypeID { get; set; }
        [JsonProperty("parkingName")]
        public string ParkingName { get; set; }
        [JsonProperty("calculationTicketMonth")]
        public int CalculationTicketMonth { get; set; }
        [JsonProperty("isAutoLockCard")]
        public int IsAutoLockCard { get; set; }
        [JsonProperty("lockCardDate")]
        public int LockCardDate { get; set; }
        [JsonProperty("projectId")]
        public string ProjectId { get; set; }
    }
}
