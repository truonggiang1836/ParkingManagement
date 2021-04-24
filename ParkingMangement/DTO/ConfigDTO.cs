using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class ConfigDTO
    {
        public const int TYPE_IN_IN = 1;
        public const int TYPE_OUT_OUT = 2;
        public const int TYPE_IN_OUT = 3;
        public const int TYPE_OUT_IN = 4;
        public const int CALCULATION_TICKET_MONTH_NO = 0;
        public const int CALCULATION_TICKET_MONTH_YES = 1;
        public const int AUTO_LOCK_CARD_NO = 0;
        public const int AUTO_LOCK_CARD_YES = 1;

        private int lostCard;
        private int bikeSpace;
        private int carSpace;
        private int ticketLimitDay;
        private int nightLimit;
        private int parkingTypeId;
        private string camera1;
        private string camera2;
        private string camera3;
        private string camera4;
        private string rfid1;
        private string rfid2;
        private int intOutType = TYPE_IN_OUT;
        private int expiredTicketMonthTypeID;
        private string ipHost;
        private string folderRoot;
        private string parkingName;
        private int calculationTicketMonth = CALCULATION_TICKET_MONTH_NO;
        private int isAutoLockCard;
        private int lockCardDate;
        private int noticeExpiredDate;
        private int depositCost;
        private string noticeFeeContent;

        public int BikeSpace { get => bikeSpace; set => bikeSpace = value; }
        public int CarSpace { get => carSpace; set => carSpace = value; }
        public int TicketLimitDay { get => ticketLimitDay; set => ticketLimitDay = value; }
        public int NightLimit { get => nightLimit; set => nightLimit = value; }
        public int ParkingTypeId { get => parkingTypeId; set => parkingTypeId = value; }
        public string Camera1 { get => camera1; set => camera1 = value; }
        public string Camera2 { get => camera2; set => camera2 = value; }
        public string Camera3 { get => camera3; set => camera3 = value; }
        public string Camera4 { get => camera4; set => camera4 = value; }
        public string Rfid1 { get => rfid1; set => rfid1 = value; }
        public string Rfid2 { get => rfid2; set => rfid2 = value; }
        public int IntOutType { get => intOutType; set => intOutType = value; }
        public int LostCard { get => lostCard; set => lostCard = value; }
        public int ExpiredTicketMonthTypeID { get => expiredTicketMonthTypeID; set => expiredTicketMonthTypeID = value; }
        public string IpHost { get => ipHost; set => ipHost = value; }
        public string FolderRoot { get => folderRoot; set => folderRoot = value; }
        public string ParkingName { get => parkingName; set => parkingName = value; }
        public int CalculationTicketMonth { get => calculationTicketMonth; set => calculationTicketMonth = value; }
        public int IsAutoLockCard { get => isAutoLockCard; set => isAutoLockCard = value; }
        public int LockCardDate { get => lockCardDate; set => lockCardDate = value; }
        public int NoticeExpiredDate { get => noticeExpiredDate; set => noticeExpiredDate = value; }
        public int DepositCost { get => depositCost; set => depositCost = value; }
        public string NoticeFeeContent { get => noticeFeeContent; set => noticeFeeContent = value; }
        public int StartHourNightShift { get; set; }
        public int EndHourNightShift { get; set; }
    }
}
