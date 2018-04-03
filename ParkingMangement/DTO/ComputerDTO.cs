using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class ComputerDTO
    {
        private int identify;
        private string partID;
        private int parkingTypeID;
        private int dayCost;
        private int nightCost;
        private int dayNightCost;
        private int intervalBetweenDayNight;
        private int startHourNight;
        private int endHourNight;
        private int hourMilestone1;
        private int hourMilestone2;
        private int hourMilestone3;
        private int costMilestone1;
        private int costMilestone2;
        private int costMilestone3;
        private int cycleMilestone3;
        private string isAdd;
        private int cycleTicketMonth;
        private int costTicketMonth;

        public int Identify { get => identify; set => identify = value; }
        public string PartID { get => partID; set => partID = value; }
        public int ParkingTypeID { get => parkingTypeID; set => parkingTypeID = value; }
        public int DayCost { get => dayCost; set => dayCost = value; }
        public int NightCost { get => nightCost; set => nightCost = value; }
        public int DayNightCost { get => dayNightCost; set => dayNightCost = value; }
        public int IntervalBetweenDayNight { get => intervalBetweenDayNight; set => intervalBetweenDayNight = value; }
        public int StartHourNight { get => startHourNight; set => startHourNight = value; }
        public int EndHourNight { get => endHourNight; set => endHourNight = value; }
        public int HourMilestone1 { get => hourMilestone1; set => hourMilestone1 = value; }
        public int HourMilestone2 { get => hourMilestone2; set => hourMilestone2 = value; }
        public int HourMilestone3 { get => hourMilestone3; set => hourMilestone3 = value; }
        public int CostMilestone1 { get => costMilestone1; set => costMilestone1 = value; }
        public int CostMilestone2 { get => costMilestone2; set => costMilestone2 = value; }
        public int CostMilestone3 { get => costMilestone3; set => costMilestone3 = value; }
        public int CycleMilestone3 { get => cycleMilestone3; set => cycleMilestone3 = value; }
        public string IsAdd { get => isAdd; set => isAdd = value; }
        public int CycleTicketMonth { get => cycleTicketMonth; set => cycleTicketMonth = value; }
        public int CostTicketMonth { get => costTicketMonth; set => costTicketMonth = value; }
    }
}
