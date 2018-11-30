using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class PartDTO
    {
        private string id;
        private string name;
        private string sign;
        private int amount;


        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Sign { get => sign; set => sign = value; }
        public int Amount { get => amount; set => amount = value; }
    }
}
