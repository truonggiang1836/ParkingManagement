using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class CardTypeDTO
    {
        public static string CARD_TYPE_TICKET_COMMON = "1";
        public static string CARD_TYPE_TICKET_MONTH = "2";
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
