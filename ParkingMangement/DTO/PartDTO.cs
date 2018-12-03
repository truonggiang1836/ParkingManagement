using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class PartDTO
    {
        public string ID { get; set; }
        public string PartID { get; set; }
        public string Name { get; set; }
        public string Sign { get; set; }
        public int Amount { get; set; }
        public string TypeID { get; set; }
        public string CardTypeID { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
