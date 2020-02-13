using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.Model
{
    class MonthlyCard
    {
        [JsonProperty("area_id")]
        public int AreaId { get; set; }
        [JsonProperty("project_id")]
        public int ProjectId { get; set; }
        [JsonProperty("admin_id")]
        public int AdminId { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("brand")]
        public int Brand { get; set; }
        [JsonProperty("created")]
        public long Created { get; set; }
        [JsonProperty("updated")]
        public long Updated { get; set; }
        [JsonProperty("disable")]
        public int Disable { get; set; }
        [JsonProperty("car_number")]
        public string CarNumber { get; set; }
        [JsonProperty("card_id")]
        public int CardId { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("company_id")]
        public int CompanyId { get; set; }
        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("start_date")]
        public long StartDate { get; set; }
        [JsonProperty("end_date")]
        public long EndDate { get; set; }
        [JsonProperty("parking_fee")]
        public int ParkingFee { get; set; }
        [JsonProperty("id_number")]
        public string IdNumber { get; set; }
        [JsonProperty("vehicle_id")]
        public int VehicleId { get; set; }
    }
}
