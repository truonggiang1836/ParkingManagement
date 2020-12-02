using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.Model
{
    class Emloyee
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("employee_code")]
        public string Code { get; set; }
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("pass")]
        public string Pass { get; set; }
        [JsonProperty("sex")]
        public string Sex { get; set; }
        [JsonProperty("position")]
        public string Position { get; set; }
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }
        [JsonProperty("deleted")]
        public int Deleted { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("tel")]
        public string Tel { get; set; }
    }
}
