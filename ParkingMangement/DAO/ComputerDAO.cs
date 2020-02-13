using ParkingMangement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class ComputerDAO
    {
        public static ComputerDTO GetDataByPartIDAndParkingTypeID(string partID, int parkingTypeID)
        {
            string sql = "select * from Computer where IDPart = '" + partID + "' and ParkingTypeID = " + parkingTypeID;
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                ComputerDTO computerDTO = new ComputerDTO();
                computerDTO.Identify = dt.Rows[0].Field<int>("Identify");
                computerDTO.PartID = dt.Rows[0].Field<string>("IDPart");
                computerDTO.ParkingTypeID = dt.Rows[0].Field<int>("ParkingTypeID");
                computerDTO.DayCost = dt.Rows[0].Field<int>("DayCost");
                computerDTO.NightCost = dt.Rows[0].Field<int>("NightCost");
                computerDTO.DayNightCost = dt.Rows[0].Field<int>("DayNightCost");
                computerDTO.IntervalBetweenDayNight = dt.Rows[0].Field<int>("IntervalBetweenDayNight");
                computerDTO.StartHourNight = dt.Rows[0].Field<int>("StartHourNight");
                computerDTO.EndHourNight = dt.Rows[0].Field<int>("EndHourNight");
                computerDTO.HourMilestone1 = dt.Rows[0].Field<int>("HourMilestone1");
                computerDTO.HourMilestone2 = dt.Rows[0].Field<int>("HourMilestone2");
                computerDTO.HourMilestone3 = dt.Rows[0].Field<int>("HourMilestone3");
                computerDTO.CostMilestone1 = dt.Rows[0].Field<int>("CostMilestone1");
                computerDTO.CostMilestone2 = dt.Rows[0].Field<int>("CostMilestone2");
                computerDTO.CostMilestone3 = dt.Rows[0].Field<int>("CostMilestone3");
                computerDTO.CostMilestone4 = dt.Rows[0].Field<int>("CostMilestone4");
                computerDTO.CostMilestoneNight1 = dt.Rows[0].Field<int>("CostMilestoneNight1");
                computerDTO.CostMilestoneNight2 = dt.Rows[0].Field<int>("CostMilestoneNight2");
                computerDTO.CostMilestoneNight3 = dt.Rows[0].Field<int>("CostMilestoneNight3");
                computerDTO.CostMilestoneNight4 = dt.Rows[0].Field<int>("CostMilestoneNight4");
                computerDTO.CycleMilestone3 = dt.Rows[0].Field<int>("CycleMilestone3");
                computerDTO.IsAdd = dt.Rows[0].Field<string>("IsAdd");
                computerDTO.CycleTicketMonth = dt.Rows[0].Field<int>("CycleTicketMonth");
                computerDTO.CostTicketMonth = dt.Rows[0].Field<int>("CostTicketMonth");
                computerDTO.MinMinute = dt.Rows[0].Field<int>("MinMinute");
                computerDTO.MinCost = dt.Rows[0].Field<int>("MinCost");
                computerDTO.Limit = dt.Rows[0].Field<int>("Limit");
                return computerDTO;
            }
            return new ComputerDTO();
        }

        public static bool IsHasData(string partID, int parkingTypeID)
        {
            string sql = "select * from Computer where IDPart = '" + partID + "' and ParkingTypeID = " + parkingTypeID;
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static bool Update(ComputerDTO computerDTO)
        {
            string sql = "update Computer set DayCost =" + computerDTO.DayCost + ", NightCost =" + computerDTO.NightCost + ", DayNightCost =" + computerDTO.DayNightCost + ", IntervalBetweenDayNight ="
                + computerDTO.IntervalBetweenDayNight + ", StartHourNight =" + computerDTO.StartHourNight + ", EndHourNight =" + computerDTO.EndHourNight + ", HourMilestone1 =" + computerDTO.HourMilestone1 +
                ", HourMilestone2 =" + computerDTO.HourMilestone2 + ", HourMilestone3 =" + computerDTO.HourMilestone3 + ", CostMilestone1 =" + computerDTO.CostMilestone1 + ", CostMilestone2 =" +
                computerDTO.CostMilestone2 + ", CostMilestone3 =" + computerDTO.CostMilestone3 + ", CostMilestone4 =" + computerDTO.CostMilestone4 + ", CycleMilestone3 =" + computerDTO.CycleMilestone3 + ", IsAdd ='" + computerDTO.IsAdd +
                "', CostMilestoneNight1 =" + computerDTO.CostMilestoneNight1 + ", CostMilestoneNight2 =" + computerDTO.CostMilestoneNight2 +
                ", CostMilestoneNight3 =" + computerDTO.CostMilestoneNight3 + ", CostMilestoneNight4 =" + computerDTO.CostMilestoneNight4 +
                ", CycleTicketMonth =" + computerDTO.CycleTicketMonth + ", CostTicketMonth =" + computerDTO.CostTicketMonth + ", MinMinute =" + computerDTO.MinMinute + ", MinCost =" + computerDTO.MinCost + ", Limit =" + computerDTO.Limit +
                " where Identify =" + computerDTO.Identify;
            return Database.ExcuNonQuery(sql);
        }

        public static bool Insert(ComputerDTO computerDTO)
        {
            string sql = "insert into Computer(IDPart, ParkingTypeID, DayCost, NightCost, DayNightCost, IntervalBetweenDayNight, StartHourNight, EndHourNight, HourMilestone1, HourMilestone2, HourMilestone3," +
                " CostMilestone1, CostMilestone2, CostMilestone3, CostMilestone4, CostMilestoneNight1, CostMilestoneNight2, CostMilestoneNight3, CostMilestoneNight4, CycleMilestone3, IsAdd, CycleTicketMonth, CostTicketMonth, MinMinute, MinCost, Limit) values ('" + 
                computerDTO.PartID + "', " + computerDTO.ParkingTypeID
                + ", " + computerDTO.DayCost + ", " + computerDTO.NightCost + ", " + computerDTO.DayNightCost + ", " + computerDTO.IntervalBetweenDayNight + ", " + computerDTO.StartHourNight + ", " + 
                computerDTO.EndHourNight + ", " + computerDTO.HourMilestone1 + ", " + computerDTO.HourMilestone2 + ", " + computerDTO.HourMilestone3 + ", " + computerDTO.CostMilestone1 + ", " + 
                computerDTO.CostMilestone2 + ", " + computerDTO.CostMilestone3 + ", " + computerDTO.CostMilestone4 + ", " +
                computerDTO.CostMilestoneNight1 + ", " + computerDTO.CostMilestoneNight2 + ", " + computerDTO.CostMilestoneNight3 + ", " + computerDTO.CostMilestoneNight4 + ", " +
                computerDTO.CycleMilestone3 + ", '" + computerDTO.IsAdd + "', " + computerDTO.CycleTicketMonth + ", " +
                computerDTO.CostTicketMonth + ", " + computerDTO.MinMinute + ", " + computerDTO.MinCost + ", " + computerDTO.Limit + ")";
            return Database.ExcuNonQuery(sql);
        }
    }
}
