using ParkingMangement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class PartDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select Part.ID, Part.PartName, Part.Sign, Part.Amount, Type.TypeName, CardType.CardTypeName from [Part], [Type], [CardType] where Part.TypeID = Type.TypeID and Part.CardTypeID = CardType.CardTypeID";
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetAllTicketMonthData()
        {
            string sql = "select Part.ID, Part.PartName, Part.Sign, Part.Amount, Type.TypeName, CardType.CardTypeName from [Part], [Type], [CardType] where Part.TypeID = Type.TypeID and Part.CardTypeID = CardType.CardTypeID and Part.CardTypeID = '1'";
            return Database.ExcuQuery(sql);
        }

        public static string GetPartNameByPartID(string id)
        {
            string sql = "select * from [Part] where ID = '" + id + "'";
            DataTable data = Database.ExcuQuery(sql);
            if (data != null && data.Rows.Count > 0)
            {
                return data.Rows[0].Field<string>("PartName");
            }
            return "";
        }

        public static string GetSignByPartID(string id)
        {
            string sql = "select * from [Part] where ID = '" + id + "'";
            DataTable data = Database.ExcuQuery(sql);
            if (data != null && data.Rows.Count > 0)
            {
                return data.Rows[0].Field<string>("Sign");
            }
            return "";
        }

        public static string GetCardTypeByID(string id)
        {
            string sql = "select * from [Part] where ID = '" + id + "'";
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<string>("CardTypeID");
            }
            return "";
        }

        public static int GetAmountByPartID(string id)
        {
            string sql = "select * from [Part] where ID = '" + id + "'";
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<int>("Amount");
            }
            return 0;
        }

        public static void Insert(PartDTO partDTO)
        {
            string sql = "insert into Part(ID, PartName, Sign, Amount, TypeID, CardTypeID) values ('" + partDTO.ID + "', '" + partDTO.Name + "', '" +
                partDTO.Sign + "', " + partDTO.Amount + ", '" + partDTO.TypeID + "', '" + partDTO.CardTypeID + "')";
            Database.ExcuNonQuery(sql);
        }

        public static void Update(PartDTO partDTO)
        {
            string sql = "update Part set PartName =('" + partDTO.Name + "'), Sign =('" + partDTO.Sign + "'), Amount =(" + partDTO.Amount + "), TypeID =('" + partDTO.TypeID + "'), CardTypeID =('" + partDTO.CardTypeID + "') where ID = '" + partDTO.ID + "'";
            Database.ExcuNonQuery(sql);
        }

        public static void Delete(string partID)
        {
            string sql = "delete from [Part] where ID = '" + partID + "'";
            Database.ExcuNonQuery(sql);
        }
    }
}
