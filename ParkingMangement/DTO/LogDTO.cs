using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class LogDTO
    {
        private int identify;
        private int logTypeID;
        private string note;
        private string account;
        private DateTime processDate;
        private string computer;

        public int Identify { get => identify; set => identify = value; }
        public int LogTypeID { get => logTypeID; set => logTypeID = value; }
        public string Note { get => note; set => note = value; }
        public string Account { get => account; set => account = value; }
        public DateTime ProcessDate { get => processDate; set => processDate = value; }
        public string Computer { get => computer; set => computer = value; }
    }
}
