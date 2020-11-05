using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.Model
{
    class Function
    {
        [JsonProperty("functionId")]
        public string FunctionId { get; set; }
        [JsonProperty("functionName")]
        public string FunctionName { get; set; }
        [JsonProperty("functionSec")]
        public string FunctionSec { get; set; }
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        [JsonProperty("deleted")]
        public int Deleted { get; set; }
    }
}
