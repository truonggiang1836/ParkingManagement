using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class ReceiptLogDetailDTO
    {
        public long ID { get; set; }

        public long? ReceiptLogID { get; set; }

        public string CustomerName { get; set; }

        public string CardIdentify { get; set; }

        public string CardID { get; set; }

        public string Digit { get; set; }

        public string PartID { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public int Cost { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime PrintDate { get; set; }

        public DateTime? ReceiptBook { get; set; }

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
