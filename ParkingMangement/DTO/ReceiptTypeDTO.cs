using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class ReceiptTypeDTO
    {
        public static int TYPE_PHIEU_THU_TIEN_MAT = 1;
        public static int TYPE_PHIEU_CHI_TIEN_MAT = 2;
        public static int TYPE_PHIEU_CHUYEN_KHOAN = 3;

        public int TypeID { get; set; }

        public string TypeName { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
