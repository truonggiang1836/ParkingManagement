using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class TicketMonthDTO
    {
        private string cardIdentify;
        private string id;
        private DateTime processDate;
        private string digit;
        private string customerName;
        private string cmnd;
        private string company;
        private string email;
        private string address;
        private string carKind;
        private string idPart;
        private DateTime registrationDate;
        private DateTime expirationDate;
        private string note;
        private string chargesAmount;
        private int status;
        private string account;
        private string images;
        private DateTime dayUnlimit;
        private string phone;
        private string isSync = "0";
        private string isDeleted = "0";

        public string CardIdentify { get => cardIdentify; set => cardIdentify = value; }
        public string Id { get => id; set => id = value; }
        public DateTime ProcessDate { get => processDate; set => processDate = value; }
        public string Digit { get => digit; set => digit = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Company { get => company; set => company = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string CarKind { get => carKind; set => carKind = value; }
        public string IdPart { get => idPart; set => idPart = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = value; }
        public string Note { get => note; set => note = value; }
        public string ChargesAmount { get => chargesAmount; set => chargesAmount = value; }
        public int Status { get => status; set => status = value; }
        public string Account { get => account; set => account = value; }
        public string Images { get => images; set => images = value; }
        public DateTime DayUnlimit { get => dayUnlimit; set => dayUnlimit = value; }
        public string Phone { get => phone; set => phone = value; }
        public string IsSync { get => isSync; set => isSync = value; }
        public string IsDeleted { get => isDeleted; set => isDeleted = value; }
    }
}
