using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class UserDTO
    {
        public UserDTO()
        {

        }
        public UserDTO(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["body"];
            id = (string)jUser["id"];
            name = (string)jUser["name"];
            account = (string)jUser["account"];
            password = (string)jUser["password"];
            functionId = (string)jUser["type"];
            sexId = (int)jUser["gender"];
            token = (string)jUser["token"];
        }

        private string id;
        private string name;
        private string account;
        private string password;
        private string functionId;
        private int sexId;
        private string token;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Account { get => account; set => account = value; }
        public string Password { get => password; set => password = value; }
        public string FunctionId { get => functionId; set => functionId = value; }
        public int SexId { get => sexId; set => sexId = value; }
        public string Token { get => token; set => token = value; }
    }
}
