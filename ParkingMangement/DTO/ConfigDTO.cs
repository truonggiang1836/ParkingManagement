using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class ConfigDTO
    {
        private int totalSpace;
        private int ticketSpace;
        private int ticketLimitDay;
        private int nightLimit;

        public int TotalSpace { get => totalSpace; set => totalSpace = value; }
        public int TicketSpace { get => ticketSpace; set => ticketSpace = value; }
        public int TicketLimitDay { get => ticketLimitDay; set => ticketLimitDay = value; }
        public int NightLimit { get => nightLimit; set => nightLimit = value; }
    }
}
