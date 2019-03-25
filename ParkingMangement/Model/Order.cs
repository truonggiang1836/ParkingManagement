using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.Model
{
    class Order
    {
        [JsonProperty("area_id")]
        public int AreaId { get; set; }
        [JsonProperty("order_id")]
        public int OrderId { get; set; }
        //[JsonProperty("card_id")]
        //public int CardId { get; set; }
        [JsonProperty("card_code")]
        public string CardCode { get; set; }
        [JsonProperty("checkin_time")]
        public string CheckinTime { get; set; }
        [JsonProperty("checkout_time")]
        public string CheckoutTime { get; set; }
        [JsonProperty("car_number")]
        public string CarNumber { get; set; }
        [JsonProperty("admin_checkin_id")]
        public string AdminCheckinId { get; set; }
        [JsonProperty("admin_checkin_name")]
        public string AdminCheckinName { get; set; }
        [JsonProperty("monthly_card_id")]
        public string MonthlyCardId { get; set; }
        [JsonProperty("vehicle_id")]
        public string VehicleId { get; set; }
        [JsonProperty("vehicle_name")]
        public string VehicleName { get; set; }
        [JsonProperty("vehicle_code")]
        public string VehicleCode { get; set; }
        [JsonProperty("is_card_lost")]
        public int IsCardLost { get; set; }
        [JsonProperty("total_price")]
        public int TotalPrice { get; set; }
        [JsonProperty("pc_name")]
        public string PcName { get; set; }
        [JsonProperty("account")]
        public string Account { get; set; }
        [JsonProperty("created")]
        public string Created { get; set; }
        [JsonProperty("updated")]
        public string Updated { get; set; }
        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }
        [JsonProperty("car_number_in")]
        public string CarNumberIn { get; set; }
        [JsonProperty("car_number_out")]
        public string CarNumberOut { get; set; }
        [JsonProperty("admin_checkout_id")]
        public string AdminCheckoutId { get; set; }
        [JsonProperty("admin_checkout_name")]
        public string AdminCheckoutName { get; set; }
    }
}
