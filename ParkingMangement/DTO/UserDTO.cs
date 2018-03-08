using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class UserDTO
    {
        private string id;
        private string name;
        private string account;
        private string password;
        private string functionId;
        private int sexId;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Account { get => account; set => account = value; }
        public string Password { get => password; set => password = value; }
        public string FunctionId { get => functionId; set => functionId = value; }
        public int SexId { get => sexId; set => sexId = value; }
    }
}
