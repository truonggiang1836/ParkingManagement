using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class CardDTO
    {
        private string systemId;
        private string identify;
        private string id;
        private string isUsing;
        private string type;
        private DateTime dayUnlimit;

        public string Identify { get => identify; set => identify = value; }
        public string Id { get => id; set => id = value; }
        public string IsUsing { get => isUsing; set => isUsing = value; }
        public string Type { get => type; set => type = value; }
        public DateTime DayUnlimit { get => dayUnlimit; set => dayUnlimit = value; }
        public string SystemId { get => systemId; set => systemId = value; }

        public static string IsUsingString(string IsUsing)
        {
            string isUsing = "không";
            if (IsUsing.Equals("1"))
            {
                isUsing = "có";
            }
            return isUsing;
        }
    }
}
