﻿using ParkingMangement.DTO;
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
            string sql = "select * from [Computer] where IDPart = '" + partID + "' and ParkingTypeID = " + parkingTypeID;
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null)
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
                computerDTO.CycleMilestone3 = dt.Rows[0].Field<int>("CycleMilestone3");
                computerDTO.IsAdd = dt.Rows[0].Field<string>("IsAdd");
                computerDTO.CycleTicketMonth = dt.Rows[0].Field<int>("CycleTicketMonth");
                computerDTO.CostTicketMonth = dt.Rows[0].Field<int>("CostTicketMonth");
                return computerDTO;
            }
            return null;
        }
    }
}