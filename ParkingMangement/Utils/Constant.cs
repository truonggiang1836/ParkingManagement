using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingMangement.Utils
{
    class Constant
    {
        // common
        public static string sMessageCommonError = "Có lỗi xảy ra";
        public static string sMessageDuplicateDataError = "Dữ liệu đã tồn tại";
        public static string sMessageInvalidError = "Dữ liệu không hợp lệ";
        public static string FUNCTION_ID_NHAN_VIEN = "Nh";

        // user
        public static string sMessageUserIdNullError = "Mã thẻ không được rỗng";
        public static string sMessageUserNameNullError = "Họ và tên không được rỗng";
        public static string sMessageAccountNullError = "Tài khoản không được rỗng";
        public static string sMessagePasswordNullError = "Mật khẩu không được rỗng";

        // part
        public static string sMessagePartIdNullError = "Mã loại xe không được rỗng";
        public static string sMessagePartNameNullError = "Tên loại xe không được rỗng";
        public static string sMessagePartAmountNullError = "Tiền thu tháng không được rỗng";
        public static string sMessagePartLimitNullError = "Hạn mức không được rỗng";

        // card
        public static string sMessageCardIdNullError = "Mã thẻ chíp không được để trống";
        public static string sLabelCardUsing = "Dùng";
        public static string sLabelCardNotUsing = "Không dùng";

        // Ticktet month
        public static string sMessageTicketMonthIdNullError = "Mã thẻ không được rỗng";
        public static string sMessageTicketMonthIdDuplicateError = "Mã thẻ không được trùng";
        public static string sMessageTicketMonthDigitNullError = "Biển số không được rỗng";
        public static string sMessageNoChooseTicketMonthError = "Vui lòng chọn vé tháng cần gia hạn";
        public static string sMessageRenewPlusDateInvalidError = "Số ngày gia hạn không hợp lệ";

        // Config
        public static string IMAGE_FOLDER = Application.StartupPath + @"\Images\";
        public const int LOG_TYPE_CREATE_TICKET_MONTH = 1;
        public const int LOG_TYPE_UPDATE_TICKET_MONTH = 2;
        public const int LOG_TYPE_DELETE_TICKET_MONTH = 3;
        public const int LOG_TYPE_LOGIN = 6;
        public const int LOG_TYPE_LOGOUT = 7;

        public const int LOAI_GIU_XE_MIEN_PHI = 0;
        public const int LOAI_GIU_XE_THEO_CONG_VAN = 1;
        public const int LOAI_GIU_XE_LUY_TIEN = 2;
        public const int LOAI_GIU_XE_MTONG_HOP = 3;

        // Node Phan quyen truy cap
        public const string NODE_NAME = "NodeName";
        public const int NODE_VALUE_THONG_TIN_NHAN_SU = 1;
        public const int NODE_VALUE_DO_BANG_CHAM_CONG = 2;
        public const int NODE_VALUE_XEM_THONG_KE = 3;
        public const int NODE_VALUE_DIEU_CHINH_CONG_THUC_TINH_TIEN = 4;
        public const int NODE_VALUE_QUAN_LY_LOAI_XE = 5;
        public const int NODE_VALUE_QUAN_LY_THE_XE = 6;
        public const int NODE_VALUE_KICH_HOAT_THE = 7;
        public const int NODE_VALUE_NHAT_KY_VE_THANG = 8;
        public const int NODE_VALUE_CAP_NHAT_THONG_TIN_VE_THANG = 9;
        public const int NODE_VALUE_GIA_HAN_VE_THANG = 10;
        public const int NODE_VALUE_MAT_THE_THANG = 11;
        public const int NODE_VALUE_KICH_HOAT_VE_THANG = 12;
        public const int NODE_VALUE_CAU_HINH_CO_BAN = 13;
        public const int NODE_VALUE_QUAN_LY_TIEN_THU = 14;
        public const int NODE_VALUE_PHAN_QUYEN_TRUY_CAP = 15;
        public const int NODE_VALUE_NHAT_KY_HE_THONG = 16;
        public const int NODE_VALUE_THIET_LAP_RA_VAO = 17;
        public const int NODE_VALUE_TRA_CUU_VAO_RA = 18;
        public const int NODE_VALUE_TRA_CUU_VAO_RA_VE_THANG = 19;
        public const int NODE_VALUE_XEM_HOP_DEN = 20;
        public const int NODE_VALUE_LUU_MAT_THE = 21;
        public const int NODE_VALUE_XEM_BAO_CAO_F7 = 22;

    }
}
