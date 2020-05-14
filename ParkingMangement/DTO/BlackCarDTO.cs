﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DTO
{
    class BlackCarDTO
    {
        private string isSync = "0";
        private string isDeleted = "0";
        public string Digit { get; set; }
        public string IsDeleted { get => isDeleted; set => isDeleted = value; }
        public string IsSync { get => isSync; set => isSync = value; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
