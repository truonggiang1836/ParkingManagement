using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class ReceiptLogDTO
    {
        public static int NO_COST = 0;
        public static int HAS_COST = 1;

        public long ID { get; set; }

        public int? ReceiptType { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string Reason { get; set; }

        public int Cost { get; set; }

        public int? ReceiptNumber { get; set; }

        public DateTime? ReceiptBook { get; set; }

        public DateTime PrintDate { get; set; }

        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }

        public int IsCostExtendCard { get; set; } = 0;

        public int IsCostCreateCard { get; set; } = 0;

        public int IsCostDepositCard { get; set; } = 0;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
