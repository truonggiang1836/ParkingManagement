using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.Model
{
    class BlackCar
    {
        [JsonProperty("digit")]
        public string Digit { get; set; }
        [JsonProperty("deleted")]
        public int Deleted { get; set; }
    }
}
