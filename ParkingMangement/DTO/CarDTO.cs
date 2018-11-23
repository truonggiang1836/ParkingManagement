using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class CarDTO
    {
        public List<CarDTO> getListCarDTO(string jsonString)
        {
            JObject jObject = JObject.Parse(jsonString);
            JToken jUser = jObject["body"];
            Id = (string)jUser["id"];
            return null;
        }

        [JsonProperty("id")]
        public int Identify { get; set; } = -1;
        [JsonProperty("card_code")]
        public int CardIdentify { get; set; } = -1;
        public string Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        [JsonProperty("car_number")]
        public string Digit { get; set; }
        [JsonProperty("admin_checkin_name")]
        public string IdIn { get; set; }
        [JsonProperty("admin_checkout_name")]
        public string IdOut { get; set; }
        [JsonProperty("total_price")]
        public int? Cost { get; set; }
        public int Seri { get; set; }
        [JsonProperty("monthly_card_code")]
        public string IdTicketMonth { get; set; }
        [Browsable(false)]
        [JsonProperty("vehicle_id")]
        public string IdPart { get; set; }
        public string Images { get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string Images4 { get; set; }
        [JsonProperty("is_card_lost")]
        public int? IsLostCard { get; set; }
        [JsonProperty("pc_name")]
        public string Computer { get; set; }
        [JsonProperty("notes")]
        public string Note { get; set; }
        [JsonProperty("account")]
        public string Account { get; set; }
        [Browsable(false)]
        public int CostBefore { get; set; }
        public DateTime DateUpdate { get; set; }
        [Browsable(false)]
        public DateTime DateLostCard { get; set; }


        [Browsable(false)]
        [JsonProperty("checkin_time")]
        public int? CheckinTime { get; set; }
        [Browsable(false)]
        [JsonProperty("checkout_time")]
        public int? CheckoutTime { get; set; }
        [Browsable(false)]
        [JsonProperty("updated")]
        public int? Updated { get; set; }
        [JsonProperty("card_stt")]
        public int SmartCardIdentify { get; set; }
        [JsonProperty("vehicle_name")]
        public string PartName { get; set; }

        public void setDataFromAPIForFields()
        {
            if (CheckinTime != null)
            {
                TimeStart = Util.getDateTimeFromMilliSecond((double)CheckinTime * 1000);
            }
            if (CheckoutTime != null)
            {
                TimeEnd = Util.getDateTimeFromMilliSecond((double)CheckoutTime * 1000);
            }
            if (Updated != null)
            {
                DateUpdate = Util.getDateTimeFromMilliSecond((double)Updated * 1000);
            }
        }
    }
}
