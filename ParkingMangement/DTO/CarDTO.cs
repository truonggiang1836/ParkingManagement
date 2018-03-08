using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class CarDTO
    {
        private int identify = -1;
        private string id;
        private DateTime timeStart;
        private DateTime timeEnd;
        private string digit;
        private string idIn;
        private string idOut;
        private int cost;
        private string part;
        private int seri;
        private string idTicketMonth;
        private string idPart;
        private string images;
        private string images2;
        private string images3;
        private string images4;
        private int islostCard;
        private string computer;
        private string note;
        private string account;
        private int costBefore;
        private DateTime dateUpdate;

        public int Identify { get => identify; set => identify = value; }
        public string Id { get => id; set => id = value; }
        public DateTime TimeStart { get => timeStart; set => timeStart = value; }
        public DateTime TimeEnd { get => timeEnd; set => timeEnd = value; }
        public string Digit { get => digit; set => digit = value; }
        public string IdIn { get => idIn; set => idIn = value; }
        public string IdOut { get => idOut; set => idOut = value; }
        public int Cost { get => cost; set => cost = value; }
        public string Part { get => part; set => part = value; }
        public int Seri { get => seri; set => seri = value; }
        public string IdTicketMonth { get => idTicketMonth; set => idTicketMonth = value; }
        public string IdPart { get => idPart; set => idPart = value; }
        public string Images { get => images; set => images = value; }
        public string Images2 { get => images2; set => images2 = value; }
        public string Images3 { get => images3; set => images3 = value; }
        public string Images4 { get => images4; set => images4 = value; }
        public int IslostCard { get => islostCard; set => islostCard = value; }
        public string Computer { get => computer; set => computer = value; }
        public string Note { get => note; set => note = value; }
        public string Account { get => account; set => account = value; }
        public int CostBefore { get => costBefore; set => costBefore = value; }
        public DateTime DateUpdate { get => dateUpdate; set => dateUpdate = value; }
    }
}
