using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class TicketLogDTO
    {
        private int identify;
        private int logTypeID;
        private TicketMonthDTO ticketMonthDTO;

        public TicketLogDTO()
        {
        }

        public TicketLogDTO(int logTypeID, TicketMonthDTO ticketMonthDTO)
        {
            this.logTypeID = logTypeID;
            this.ticketMonthDTO = ticketMonthDTO;
        }

        public int Identify { get => identify; set => identify = value; }
        public int LogTypeID { get => logTypeID; set => logTypeID = value; }
        internal TicketMonthDTO TicketMonthDTO { get => ticketMonthDTO; set => ticketMonthDTO = value; }
    }
}
