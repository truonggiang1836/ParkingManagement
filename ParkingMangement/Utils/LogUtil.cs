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

        public static void addLogXoaThe(int identidy, string cardId)
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

            logDTO.Note = Constant.LOG_NOTE_TAO_MOI_THE + " -Mã loại xe: " + partDTO.Id + " -Tên loại xe: " + partDTO.Name + " -Ký hiệu: " + partDTO.Sign
                 + " -Tiền thu tháng: " + partDTO.Amount + " -Hạn mức: " + partDTO.Limit;
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
