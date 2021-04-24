using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class RevenueDTO
    {
        private string isSync = "0";
        public string RevenueId { get; set; }
        public string StartDateTimeString { get; set; }
        public string UserId { get; set; }
        public string JsonBody { get; set; }
        public string IsSync { get => isSync; set => isSync = value; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
