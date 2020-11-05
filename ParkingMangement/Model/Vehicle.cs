using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.Model
{
    class Vehicle
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("monthly_cost")]
        public int MonthlyCost { get; set; }
        [JsonProperty("vehicel_type")]
        public int VehicleType { get; set; }
        [JsonProperty("vehicel_id")]
        public int VehicleId { get; set; }
        [JsonProperty("card_type")]
        public int CardType { get; set; }
        [JsonProperty("project_id")]
        public int ProjectId { get; set; }
        [JsonProperty("deleted")]
        public int Deleted { get; set; }
    }
}
