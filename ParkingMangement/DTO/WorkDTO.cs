using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class WorkDTO
    {
        private int identify;
        private string userID;
        private DateTime timeStart;
        private DateTime timeEnd;
        private string computer;

        public int Identify { get => identify; set => identify = value; }
        public string UserID { get => userID; set => userID = value; }
        public DateTime TimeStart { get => timeStart; set => timeStart = value; }
        public DateTime TimeEnd { get => timeEnd; set => timeEnd = value; }
        public string Computer { get => computer; set => computer = value; }
    }
}
