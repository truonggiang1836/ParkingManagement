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
        private int parkingTypeId;
        private string camera1;
        private string camera2;
        private string camera3;
        private string camera4;
        private string rfid1;
        private string rfid2;

        public int TotalSpace { get => totalSpace; set => totalSpace = value; }
        public int TicketSpace { get => ticketSpace; set => ticketSpace = value; }
        public int TicketLimitDay { get => ticketLimitDay; set => ticketLimitDay = value; }
        public int NightLimit { get => nightLimit; set => nightLimit = value; }
        public int ParkingTypeId { get => parkingTypeId; set => parkingTypeId = value; }
        public string Camera1 { get => camera1; set => camera1 = value; }
        public string Camera2 { get => camera2; set => camera2 = value; }
        public string Camera3 { get => camera3; set => camera3 = value; }
        public string Camera4 { get => camera4; set => camera4 = value; }
        public string Rfid1 { get => rfid1; set => rfid1 = value; }
        public string Rfid2 { get => rfid2; set => rfid2 = value; }
    }
}
