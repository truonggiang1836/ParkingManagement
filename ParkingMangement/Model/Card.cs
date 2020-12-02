using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.Model
{
    class Card
    {
        [JsonProperty("area_id")]
        public int AreaId { get; set; }
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }
        [JsonProperty("admin_id")]
        public int AdminId { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("company_id")]
        public int CompanyId { get; set; }
        [JsonProperty("created")]
        public long Created { get; set; }
        [JsonProperty("updated")]
        public long Updated { get; set; }
        [JsonProperty("disable")]
        public int Disable { get; set; }
        [JsonProperty("deleted")]
        public int Deleted { get; set; }
        //[JsonProperty("id")]
        //public int Id { get; set; }
        [JsonProperty("monthly_card_id")]
        public int MonthlyCardId { get; set; }
        [JsonProperty("stt")]
        public string Stt { get; set; }
        [JsonProperty("vehicle_id")]
        public int VehicleId { get; set; }
    }
}
