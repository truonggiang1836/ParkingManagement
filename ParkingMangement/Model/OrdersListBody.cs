using Newtonsoft.Json;
using ParkingMangement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.Model
{
    class OrdersListBody
    {
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("data")]
        public List<CarDTO> Data { get; set; }
    }
}
