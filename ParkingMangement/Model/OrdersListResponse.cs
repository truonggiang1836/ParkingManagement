using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.Model
{
    class OrdersListResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("body")]
        public OrdersListBody Body { get; set; }
    }
}
