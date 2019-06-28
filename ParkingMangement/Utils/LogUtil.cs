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
            LogDAO.Insert(logDTO);
        }

        public static LogDTO createCommonLog()
        {
            LogDTO logDTO = new LogDTO();
            logDTO.Account = Program.CurrentUserID;
            logDTO.ProcessDate = DateTime.Now;
            logDTO.Computer = Environment.MachineName;
            return logDTO;
        }

        public static void addLoginLog()
        {
            LogDTO logDTO = createCommonLog();
            logDTO.LogTypeID = Constant.LOG_TYPE_DANG_NHAP;
            logDTO.Note = Constant.LOG_NOTE_DANG_NHAP;
            addLog(logDTO);
        }

        public static void addLogoutLog()
        {
            LogDTO logDTO = createCommonLog();
            logDTO.LogTypeID = Constant.LOG_TYPE_DANG_XUAT;
            logDTO.Note = Constant.LOG_NOTE_DANG_XUAT;
            addLog(logDTO);
        }

        public static void addLogChinhSuaGiaTienGuiXe(ComputerDTO oldComputerDTO, ComputerDTO newComputerDTO, int parkingTypeID)
        {
            LogDTO logDTO = createCommonLog();
            logDTO.LogTypeID = Constant.LOG_TYPE_CHINH_SUA_GIA_TIEN_GUI_XE;
            String note = "";
            switch (parkingTypeID)
            {
                case Constant.LOAI_GIU_XE_THEO_CONG_VAN:
                    note += "Cong thuc tinh tien theo cong van";
                    break;
                case Constant.LOAI_GIU_XE_LUY_TIEN:
                    note += "Cong thuc tinh tien luy tien";
                    break;
                case Constant.LOAI_GIU_XE_TONG_HOP:
                    note += "Cong thuc tinh tien tong hop";
                    break;
                default:
                    note += "Cong thuc tinh tien theo cong van";
                    break;
            }
            note += Constant.BREAK_LINE;
            note += " -Loai xe: " + PartDAO.GetPartNameByPartID(newComputerDTO.PartID) + Constant.BREAK_LINE;
            if (oldComputerDTO.StartHourNight != newComputerDTO.StartHourNight)
            {
                note += " -Gio bat dau dem: " + oldComputerDTO.StartHourNight + Constant.ARROW_STRING + 
                    newComputerDTO.StartHourNight + Constant.BREAK_LINE;
            }
            if (oldComputerDTO.EndHourNight != newComputerDTO.EndHourNight)
            {
                note += " -Gio ket thuc dem: " + oldComputerDTO.EndHourNight + Constant.ARROW_STRING +
                    newComputerDTO.EndHourNight + Constant.BREAK_LINE;
            }
            if (oldComputerDTO.IntervalBetweenDayNight != newComputerDTO.IntervalBetweenDayNight)
            {
                note += " -Khoang giao ngay + dem: " + oldComputerDTO.IntervalBetweenDayNight + Constant.ARROW_STRING +
                    newComputerDTO.IntervalBetweenDayNight + Constant.BREAK_LINE;
            }
            if (oldComputerDTO.DayCost != newComputerDTO.DayCost)
            {
                note += " -Gia ngay: " + oldComputerDTO.DayCost + Constant.ARROW_STRING +
                    newComputerDTO.DayCost + Constant.BREAK_LINE;
            }
            if (oldComputerDTO.NightCost != newComputerDTO.NightCost)
            {
                note += " -Gia dem: " + oldComputerDTO.NightCost + Constant.ARROW_STRING +
                    newComputerDTO.NightCost + Constant.BREAK_LINE;
            }
            if (oldComputerDTO.DayNightCost != newComputerDTO.DayNightCost)
            {
                note += " -Gia ngay + dem: " + oldComputerDTO.DayNightCost + Constant.ARROW_STRING +
                    newComputerDTO.DayNightCost + Constant.BREAK_LINE;
            }
            if (oldComputerDTO.MinMinute != newComputerDTO.MinMinute)
            {
                note += " -Thoi gian moc toi thieu: " + oldComputerDTO.MinMinute + Constant.ARROW_STRING +
                    newComputerDTO.MinMinute + Constant.BREAK_LINE;
            }
            if (oldComputerDTO.MinCost != newComputerDTO.MinCost)
            {
                note += " -Gia moc toi thieu: " + oldComputerDTO.MinCost + Constant.ARROW_STRING +
                    newComputerDTO.MinCost + Constant.BREAK_LINE;
            }

            if (oldComputerDTO.HourMilestone1 != newComputerDTO.HourMilestone1)
            {
                note += " -Moc 1: " + oldComputerDTO.HourMilestone1 + Constant.ARROW_STRING +
                    newComputerDTO.HourMilestone1 + Constant.BREAK_LINE;
            }
            if (oldComputerDTO.CostMilestone1 != newComputerDTO.CostMilestone1)
            {
                note += " -Gia moc 1: " + oldComputerDTO.CostMilestone1 + Constant.ARROW_STRING +
                    newComputerDTO.CostMilestone1 + Constant.BREAK_LINE;
            }
            if (oldComputerDTO.HourMilestone2 != newComputerDTO.HourMilestone2)
            {
                note += " -Moc 2: " + oldComputerDTO.HourMilestone2 + Constant.ARROW_STRING +
                    newComputerDTO.HourMilestone2 + Constant.BREAK_LINE;
            }
            if (oldComputerDTO.CostMilestone2 != newComputerDTO.CostMilestone2)
            {
                note += " -Gia moc 2: " + oldComputerDTO.CostMilestone2 + Constant.ARROW_STRING +
                    newComputerDTO.CostMilestone2 + Constant.BREAK_LINE;
            }
            if (oldComputerDTO.CostMilestone3 != newComputerDTO.CostMilestone3)
            {
                note += " -Gia lon hon 2 moc: " + oldComputerDTO.CostMilestone3 + Constant.ARROW_STRING +
                    newComputerDTO.CostMilestone3 + Constant.BREAK_LINE;
            }

            if (oldComputerDTO.IsAdd != newComputerDTO.IsAdd)
            {
                note += " -Loai cong moc: " + getLoaiCongMoc(oldComputerDTO.IsAdd) + Constant.ARROW_STRING +
                    getLoaiCongMoc(newComputerDTO.IsAdd) + Constant.BREAK_LINE;
            }          

            logDTO.Note = note;
            addLog(logDTO);
        }

        private static string getLoaiCongMoc(string isAdd)
        {
            string note = "";
            switch (isAdd)
            {
                case Constant.TINH_TIEN_LUY_TIEN_KHONG_CONG:
                    note += "khong cong";
                    break;
                case Constant.TINH_TIEN_LUY_TIEN_CONG_1_MOC:
                    note += "cong 1 moc";
                    break;
                case Constant.TINH_TIEN_LUY_TIEN_CONG_2_MOC:
                    note += "cong 2 moc";
                    break;
                default:
                    note += "khong cong";
                    break;
            }
            return note;
        }

        public static void addLogTaoMoiThe(CardDTO cardDTO)
        {
            LogDTO logDTO = createCommonLog();
            logDTO.LogTypeID = Constant.LOG_TYPE_TAO_MOI_THE;
            string isUsing = CardDTO.IsUsingString(cardDTO.IsUsing);
            logDTO.Note = Constant.LOG_NOTE_TAO_MOI_THE + " -STT: " + cardDTO.Identify + " -Mã thẻ: " + cardDTO.Id + " -Loại xe: " + PartDAO.GetPartNameByPartID(cardDTO.Type.ToString())
                + " -Sử dụng: " + isUsing;
            addLog(logDTO);
        }

        public static void addLogChinhSuaThe(CardDTO oldCardDTO, CardDTO newCardDTO)
        {
            LogDTO logDTO = createCommonLog();
            logDTO.LogTypeID = Constant.LOG_TYPE_CHINH_SUA_THE;
            logDTO.Note = Constant.LOG_NOTE_CHINH_SUA_THE + " -STT: " + oldCardDTO.Identify;
            if (oldCardDTO.Id.Equals(newCardDTO.Id))
            {
                logDTO.Note += " -Mã thẻ: " + oldCardDTO.Id;
            } else
            {
                logDTO.Note += " -Mã thẻ: " + oldCardDTO.Id + " -> " + newCardDTO.Id;
            }
            if (!oldCardDTO.Type.Equals(newCardDTO.Type))
            {
                logDTO.Note += " -Loại thẻ: " + PartDAO.GetPartNameByPartID(oldCardDTO.Type.ToString()) + " -> " + PartDAO.GetPartNameByPartID(newCardDTO.Type.ToString());
            }
            if (!oldCardDTO.IsUsing.Equals(newCardDTO.IsUsing))
            {
                logDTO.Note += " -Sử dụng: " + CardDTO.IsUsingString(oldCardDTO.IsUsing) + " -> " + CardDTO.IsUsingString(newCardDTO.IsUsing);
            }
            addLog(logDTO);
        }

        public static void addLogXoaThe(string identidy, string cardId)
        {
            LogDTO logDTO = createCommonLog();
            logDTO.LogTypeID = Constant.LOG_TYPE_XOA_THE;
            logDTO.Note = Constant.LOG_NOTE_XOA_THE + " -STT: " + identidy + " -Mã thẻ: " + cardId;
            addLog(logDTO);
        }

        public static void addLogTaoMoiNhanVien(UserDTO userDTO)
        {
            LogDTO logDTO = createCommonLog();
            logDTO.LogTypeID = Constant.LOG_TYPE_TAO_MOI_NHAN_VIEN;
            string functionName = FunctionalDAO.GetFunctionNameByID(userDTO.FunctionId);
            string sexName = SexDAO.GetSexNameByID(userDTO.SexId);
            logDTO.Note = Constant.LOG_NOTE_TAO_MOI_NHAN_VIEN + " -Mã thẻ: " + userDTO.Id + " -Họ tên: " + userDTO.Name + " -Tài khoản: " + userDTO.Account + " -Mật khẩu: " + userDTO.Password
                + " -Chức vụ: " + functionName + " -Giới tính: " + sexName;
            addLog(logDTO);
        }

        public static void addLogChinhSuaNhanVien(UserDTO oldUserDTO, UserDTO newUserDTO)
        {
            LogDTO logDTO = createCommonLog();
            logDTO.LogTypeID = Constant.LOG_TYPE_CHINH_SUA_NHAN_VIEN;

            string defaultNoteValue = Constant.LOG_NOTE_CHINH_SUA_NHAN_VIEN + " -Mã thẻ: " + oldUserDTO.Id;
            logDTO.Note = Constant.LOG_NOTE_CHINH_SUA_NHAN_VIEN + " -Mã thẻ: " + oldUserDTO.Id;
            if (!oldUserDTO.Name.Equals(newUserDTO.Name))
            {
                logDTO.Note += " -Họ tên: " + oldUserDTO.Name + " -> " + newUserDTO.Name;
            }
            if (!oldUserDTO.Account.Equals(newUserDTO.Account))
            {
                logDTO.Note += " -Tài khoản: " + oldUserDTO.Account + " -> " + newUserDTO.Account;
            }
            if (!oldUserDTO.Password.Equals(newUserDTO.Password))
            {
                logDTO.Note += " -Mật khẩu: " + oldUserDTO.Password + " -> " + newUserDTO.Password;
            }
            if (!oldUserDTO.FunctionId.Equals(newUserDTO.FunctionId))
            {
                logDTO.Note += " -Chức vụ: " + FunctionalDAO.GetFunctionNameByID(oldUserDTO.FunctionId) + " -> " + FunctionalDAO.GetFunctionNameByID(newUserDTO.FunctionId);
            }
            if (!oldUserDTO.SexId.Equals(newUserDTO.SexId))
            {
                logDTO.Note += " -Giới tính: " + SexDAO.GetSexNameByID(oldUserDTO.SexId) + " -> " + SexDAO.GetSexNameByID(newUserDTO.SexId);
            }
            if (logDTO.Note.Equals(defaultNoteValue))
            {
                return;
            }
            addLog(logDTO);
        }

        public static void addLogXoaNhanVien(string userID)
        {
            LogDTO logDTO = createCommonLog();
            logDTO.LogTypeID = Constant.LOG_TYPE_XOA_NHAN_VIEN;
            logDTO.Note = Constant.LOG_NOTE_XOA_NHAN_VIEN + " -Mã thẻ: " + userID;
            addLog(logDTO);
        }

        public static void addLogTaoMoiLoaiXe(PartDTO partDTO)
        {
            LogDTO logDTO = createCommonLog();
            logDTO.LogTypeID = Constant.LOG_TYPE_TAO_MOI_LOAI_XE;

            logDTO.Note = Constant.LOG_NOTE_TAO_MOI_THE + " -Mã loại xe: " + partDTO.ID + " -Tên loại xe: " + partDTO.Name + " -Ký hiệu: " + partDTO.Sign
                 + " -Tiền thu tháng: " + partDTO.Amount;
            addLog(logDTO);
        }

        public static void addLogXoaLoaiXe(string partID, string partName)
        {
            LogDTO logDTO = createCommonLog();
            logDTO.LogTypeID = Constant.LOG_TYPE_XOA_LOAI_XE;

            logDTO.Note = Constant.LOG_NOTE_XOA_LOAI_XE + " -Mã loại xe: " + partID + " -Tên loại xe: " + partName;
            addLog(logDTO);
        }

        public static void addLogChinhSuaLoaiXe(PartDTO oldPartDTO, PartDTO newPartDTO)
        {
            //LogDTO logDTO = createCommonLog();
            //logDTO.LogTypeID = Constant.LOG_TYPE_CHINH_SUA_LOAI_XE;

            //string defaultNoteValue = Constant.LOG_NOTE_CHINH_SUA_LOAI_XE + " -Mã loại xe: " + oldPartDTO.Id;
            //logDTO.Note = Constant.LOG_NOTE_CHINH_SUA_LOAI_XE + " -Mã loại xe: " + oldPartDTO.Id;
            //if (!oldPartDTO.Name.Equals(newPartDTO.Name))
            //{
            //    logDTO.Note += " -Tên loại xe: " + oldPartDTO.Name + " -> " + newPartDTO.Name;
            //}
            //if (!oldPartDTO.Sign.Equals(newPartDTO.Sign))
            //{
            //    logDTO.Note += " -Ký hiệu: " + oldPartDTO.Sign + " -> " + newPartDTO.Sign;
            //}
            //if (!oldUserDTO.Password.Equals(newUserDTO.Password))
            //{
            //    logDTO.Note += " -Mật khẩu: " + oldUserDTO.Password + " -> " + newUserDTO.Password;
            //}
            //if (!oldUserDTO.FunctionId.Equals(newUserDTO.FunctionId))
            //{
            //    logDTO.Note += " -Chức vụ: " + FunctionalDAO.GetFunctionNameByID(oldUserDTO.FunctionId) + " -> " + FunctionalDAO.GetFunctionNameByID(newUserDTO.FunctionId);
            //}
            //if (!oldUserDTO.SexId.Equals(newUserDTO.SexId))
            //{
            //    logDTO.Note += " -Giới tính: " + SexDAO.GetSexNameByID(oldUserDTO.SexId) + " -> " + SexDAO.GetSexNameByID(newUserDTO.SexId);
            //}
            //if (logDTO.Note.Equals(defaultNoteValue))
            //{
            //    return;
            //}
            //addLog(logDTO);
        }
    }
}
