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
        public const bool IS_SYNC_DATA_APP = false;
        public const bool IS_NEW_CAMERA = true;
        public const bool IS_NAPSHOT_FULL_IMAGE = false;
        public const int AUTO_CLOSE_MESSAGE_BOX_TIME = 2000;
        public const string BREAK_LINE = "\r\n";
        public const string ARROW_STRING = " -> ";
        public const int PROJECT_ID = 2;

        // common
        public static string sHintTextUsername = "User";
        public static string sHintTextPassword = "Password";
        public static string sLabelAlert = "Cảnh báo";
        public static string sLabelXeVao = "XE VÀO";
        public static string sLabelXeRa = "XE RA";
        public static string sLabelXeVaoNguoi = "ẢNH NGƯỜI GỬI VÀO";
        public static string sLabelXeVaoBienSo = "ẢNH XE VÀO";
        public static string sLabelXeRaNguoi = "ẢNH NGƯỜI GỬI RA";
        public static string sLabelXeRaBienSo = "ẢNH XE RA";
        public static string sLabelMoiVao = "Mời vào";
        public static string sLabelMoiRa = "Mời ra";
        public static string sEncodeStart = "<![CDATA[";
        public static string sEncodeEnd = "]]>";
        public static string sButtonEdit = "CHỈNH SỬA";
        public static string sButtonUpdate = "CẬP NHẬT";
        public static string sTitleDelete = "Xóa dữ liệu";
        public static string sButtonDelete = "Xóa";
        public static string sMessageConfirmDelete = "Bạn có muốn xóa không?";
        public static string sMessageExportExcelSuccess = "Xuất file Excel thành công";
        public static string sMessageImportExcelSuccess = "Nhập file Excel hoàn tất";
        public static string sMessageUpdateSuccess = "Cập nhật thành công";
        public static string sMessageCommonError = "Có lỗi xảy ra";
        public static string sMessageDuplicateDataError = "Dữ liệu đã tồn tại";
        public static string sMessageInvalidError = "Dữ liệu không hợp lệ";
        public static string FUNCTION_ID_NHAN_VIEN = "Nh";
        public static string FUNCTION_ID_ADMIN = "Ad";
        public static string sMessageCanNotSeeReport = "Bạn không có quyền xem báo cáo";
        public static string sMessageCanNotSaveLostCard = "Bạn không có quyền lưu mất thẻ";

        // user
        public static string sMessageUpdatePasswordSuccess = "Cập nhật mật khẩu thành công";
        public static string sMessageUserIdNullError = "Mã thẻ không được rỗng";
        public static string sMessageUserNameNullError = "Họ và tên không được rỗng";
        public static string sMessageAccountNullError = "Tài khoản không được rỗng";
        public static string sMessagePasswordNullError = "Mật khẩu không được rỗng";
        public static string sMessageConfirmPasswordError = "Mật khẩu xác nhận không đúng";

        // part
        public static string sMessagePartIdNullError = "Mã loại xe không được rỗng";
        public static string sMessagePartNameNullError = "Tên loại xe không được rỗng";
        public static string sMessagePartAmountNullError = "Tiền thu tháng không được rỗng";
        public static string sMessagePartLimitNullError = "Hạn mức không được rỗng";

        // card
        public static string sMessageConfirmSaveLostCard = "Bạn có muốn lưu mất thẻ?";
        public static string sMessageCardIdNullError = "Mã thẻ chíp không được để trống";
        public static string sMessageCardIdNotExist = "Thẻ chưa được thêm vào hệ thống";
        public static string sMessageCardIsLost = "THẺ ĐÃ BỊ KHÓA";
        public static string sLabelCardUsing = "Dùng";
        public static string sLabelCardNotUsing = "Không dùng";
        public static string sMessageCardIdentifyExisted = "Số thẻ đã tồn tại";
        public static string sMessageCardIdExisted = "Mã thẻ chíp đã tồn tại";

        // car
        public static string sMessageXeDaRaKhoiBai = "Xe này đã ra khỏi bãi";

        // Ticktet month
        public static string sMessageTicketMonthIdentifyNullError = "Số thẻ không được rỗng";
        public static string sMessageTicketMonthIdNullError = "Mã thẻ chíp không được rỗng";
        public static string sMessageTicketMonthIdDuplicateError = "Mã thẻ chíp không được trùng";
        public static string sMessageTicketMonthDigitNullError = "Biển số không được rỗng";
        public static string sMessageNoChooseDataError = "Vui lòng chọn dữ liệu cần xử lý";
        public static string sMessageRenewPlusDateInvalidError = "Số ngày gia hạn không hợp lệ";
        public static string sMessageCardTypeIsNotTicketMonth = "Loại thẻ này không dành cho xe tháng";
        public static string sMessageDigitExisted = "Biển số đã tồn tại";
        public static string sMessageMaxTicketMonthToPrint = "Chỉ được chọn tối đa 6 thẻ tháng";
        public static string sMessageMaxTicketMonthToPrintFeeNotice = "Chỉ được chọn tối đa 6 thẻ tháng";
        public static string sMessageExpiredCard = "Thẻ tháng đã hết hạn!";
        public static string sMessageNearExpiredCard = "Thẻ tháng sắp hết hạn!";

        // File name
        public static string tobeexpired = "tobeexpired.wav";
        public static string expired = "expired.wav";
        public static string notused = "notused.wav";
        public static string locked = "locked.wav";
        public static string goIn = "in.wav";
        public static string goOut = "out.wav";

        public static string number0 = "0.wav";
        public static string number1 = "1.wav";
        public static string number2 = "2.wav";
        public static string number3 = "3.wav";
        public static string number4 = "4.wav";
        public static string number5 = "5.wav";
        public static string number6 = "6.wav";
        public static string number7 = "7.wav";
        public static string number8 = "8.wav";
        public static string number9 = "9.wav";
        public static string ten = "ten.wav";
        public static string hundred = "hundred.wav";
        public static string thousand = "thousand.wav";
        public static string million = "million.wav";
        public static string xteen = "xteen.wav";
        public static string unitonly = "unitonly.wav";
        public static string fivealt = "fivealt.wav";
        public static string currency = "currency.wav";

        // Config
        public static string FOLDER_NAME_IMAGES = "Images";
        public static string FOLDER_NAME_CAR_NUMBER = "HinhBienSo";
        public static string FOLDER_NAME_PARKING_MANAGEMENT = "ParkingManagement";
        public static string LOCAL_ROOT_FOLDER = Application.StartupPath + @"\" + FOLDER_NAME_PARKING_MANAGEMENT + @"\";
        public static string LOCAL_IMAGE_FOLDER = Application.StartupPath + @"\" + FOLDER_NAME_PARKING_MANAGEMENT + @"\" + FOLDER_NAME_IMAGES + @"\";
        public const int LOG_TYPE_CREATE_TICKET_MONTH = 1;
        public const int LOG_TYPE_UPDATE_TICKET_MONTH = 2;
        public const int LOG_TYPE_DELETE_TICKET_MONTH = 3;


        public const int LOG_TYPE_DANG_NHAP = 6;
        public const int LOG_TYPE_DANG_XUAT = 7;

        public const int LOG_TYPE_TAO_MOI_NHAN_VIEN = 9;
        public const int LOG_TYPE_CHINH_SUA_NHAN_VIEN = 10;
        public const int LOG_TYPE_XOA_NHAN_VIEN = 11;

        public const int LOG_TYPE_CHINH_SUA_GIA_TIEN_GUI_XE = 17;

        public const int LOG_TYPE_TAO_MOI_THE = 20;
        public const int LOG_TYPE_CHINH_SUA_THE = 21;
        public const int LOG_TYPE_XOA_THE = 22;

        public const int LOG_TYPE_TAO_MOI_LOAI_XE = 25;
        public const int LOG_TYPE_CHINH_SUA_LOAI_XE = 26;
        public const int LOG_TYPE_XOA_LOAI_XE = 27;


        public const string LOG_NOTE_DANG_NHAP = "Đăng nhập hệ thống";
        public const string LOG_NOTE_DANG_XUAT = "Đăng xuất hệ thống";

        public const string LOG_NOTE_TAO_MOI_NHAN_VIEN = "Tạo mới nhân viên";
        public const string LOG_NOTE_CHINH_SUA_NHAN_VIEN = "Chỉnh sửa nhân viên";
        public const string LOG_NOTE_XOA_NHAN_VIEN = "Xóa nhân viên";

        public const string LOG_NOTE_TAO_MOI_THE = "Tạo mới thẻ chip";
        public const string LOG_NOTE_CHINH_SUA_THE = "Chỉnh sửa thẻ chip";
        public const string LOG_NOTE_XOA_THE = "Xóa thẻ chip";

        public const string LOG_NOTE_CHINH_SUA_GIA_TIEN_GUI_XE = "Chỉnh sửa giá tiền gửi xe";

        public const string LOG_NOTE_TAO_MOI_LOAI_XE = "Tạo mới loại xe";
        public const string LOG_NOTE_CHINH_SUA_LOAI_XE = "Chỉnh sửa loại xe";
        public const string LOG_NOTE_XOA_LOAI_XE = "Xóa loại xe";


        public const int LOAI_GIU_XE_MIEN_PHI = 0;
        public const int LOAI_GIU_XE_THEO_CONG_VAN = 1;
        public const int LOAI_GIU_XE_LUY_TIEN = 2;
        public const int LOAI_GIU_XE_TONG_HOP = 3;
        public const int LOAI_GIU_XE_TONG_HOP_THEO_NGAY_DEM = 4;

        public const int LOAI_HET_HAN_TINH_TIEN_NHU_VANG_LAI = 0;
        public const int LOAI_HET_HAN_CHI_CANH_BAO_HET_HAN = 1;

        public const string TINH_TIEN_LUY_TIEN_KHONG_CONG = "0";
        public const string TINH_TIEN_LUY_TIEN_CONG_1_MOC = "1";
        public const string TINH_TIEN_LUY_TIEN_CONG_2_MOC = "2";

        // Node Phan quyen truy cap
        public const string NODE_NAME = "NodeName";
        public const int NODE_VALUE_THONG_TIN_NHAN_SU = 1;
        public const int NODE_VALUE_DO_BANG_CHAM_CONG = 2;
        public const int NODE_VALUE_XEM_THONG_KE = 3;
        public const int NODE_VALUE_DIEU_CHINH_CONG_THUC_TINH_TIEN = 4;
        public const int NODE_VALUE_QUAN_LY_LOAI_XE = 5;
        public const int NODE_VALUE_QUAN_LY_THE_XE = 6;
        public const int NODE_VALUE_KHOA_THE = 23;
        public const int NODE_VALUE_KICH_HOAT_THE = 7;
        public const int NODE_VALUE_NHAT_KY_VE_THANG = 8;
        public const int NODE_VALUE_CAP_NHAT_THONG_TIN_VE_THANG = 9;
        public const int NODE_VALUE_GIA_HAN_VE_THANG = 10;
        public const int NODE_VALUE_MAT_THE_THANG = 11;
        public const int NODE_VALUE_KHOA_VE_THANG = 24;
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

        // path file
        public static String sFileNameConfig = "Config.xml";

        public static String sDateTimeFormatForQuery = "yyyy-MM-dd HH:mm:ss";
        public static String sDateTimeFormatForAPI = "yyyy-MM-dd HH:mm";
        public static String sDateTimeFormatForScreen = "dd-MM-yyyy HH:mm:ss";

        public static string getSharedImageFolder()
        {
            string path = @"\\" + Util.getConfigFile().computerName + @"\" + Util.getConfigFile().folderRoot + @"\" + FOLDER_NAME_IMAGES + @"\";
            //path = @"D:\\PHAN MEM BAI XE\\HINH ANH\\ParkingManagement\Images";
            return path;
        }

        public static string getCarNumberImageFolder()
        {
            //string path = @"\\" + Util.getConfigFile().computerName + @"\" + Util.getConfigFile().folderRoot + @"\" + FOLDER_NAME_IMAGES + @"\" + FOLDER_NAME_CAR_NUMBER + @"\";
            string path = @"D:\HINH_BIEN_SO\";
            return path;
        }

        public static string getCurrentDateString()
        {
            return DateTime.Now.ToString("yyyy.MM.dd");
        }

        public static string getDateOnLastMonthString()
        {
            return DateTime.Now.AddDays(-30).ToString("yyyyMMdd");
        }

        public static string getSharedParkingManagementFolder()
        {
            return @"\\" + Util.getConfigFile().computerName + @"\" + Util.getConfigFile().folderRoot + @"\";
        }

        public static string getSharedRootFolder()
        {
            return @"\\" + Util.getConfigFile().computerName + @"\";
        }
    }
}
