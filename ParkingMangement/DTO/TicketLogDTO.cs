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
        private DateTime processDate;
        private string ticketMonthID;
        private string account;

        public int Identify { get => identify; set => identify = value; }
        public int LogTypeID { get => logTypeID; set => logTypeID = value; }
        public DateTime ProcessDate { get => processDate; set => processDate = value; }
        public string TicketMonthID { get => ticketMonthID; set => ticketMonthID = value; }
        public string Account { get => account; set => account = value; }
    }
}
