using ParkingMangement.DAO;
using ParkingMangement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.Utils
{
    class LogUtil
    {
        public static void addLog(LogDTO logDTO)
        {
            if (logDTO.LogTypeID == Constant.LOG_TYPE_LOGIN)
            {
                logDTO.Note = "Đăng nhập hệ thống";
            }
            if (logDTO.LogTypeID == Constant.LOG_TYPE_LOGOUT)
            {
                logDTO.Note = "Đăng xuất hệ thống";
            }
            LogDAO.Insert(logDTO);
        }

        public static void addLoginLog()
        {
            LogDTO logDTO = new LogDTO();
            logDTO.LogTypeID = Constant.LOG_TYPE_LOGIN;
            logDTO.Account = Program.CurrentUserID;
            logDTO.ProcessDate = DateTime.Now;
            logDTO.Computer = Environment.MachineName;
            LogUtil.addLog(logDTO);
        }
    }
}
