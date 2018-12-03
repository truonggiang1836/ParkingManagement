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
        public static DataTable GetAllCommonData()
        {
            string sql = "select Part.ID, Part.PartName, Part.PartID, Part.Sign, Part.Amount, Type.TypeName from [Part], [Type] where Part.TypeID = Type.TypeID and Part.CardTypeID = '1'";
            return Database.ExcuQuery(sql);
        }

        public static string GetPartNameByPartID(string id)
        {
            string sql = "select * from [Part] where ID = '" + id + "'";
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<string>("PartName");
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
            string sql = "insert into Part(ID, PartID, PartName, Sign, Amount, TypeID, CardTypeID) values ('" + partDTO.ID + "', '" + partDTO.PartID + "', '" + partDTO.Name + "', '" +
                partDTO.Sign + "', " + partDTO.Amount + ", '" + partDTO.TypeID + "', '" + partDTO.CardTypeID + "')";
            Database.ExcuNonQuery(sql);
        }

        public static void Update(PartDTO partDTO)
        {
            string sql = "update Part set PartName =('" + partDTO.Name + "'), Sign =('" + partDTO.Sign + "'), Amount =(" + partDTO.Amount + "), TypeID =('" + partDTO.TypeID + "') where PartID = '" + partDTO.PartID + "'";
            Database.ExcuNonQuery(sql);
        }

        public static void Delete(string partID)
        {
            string sql = "delete from [Part] where PartID = '" + partID + "'";
            Database.ExcuNonQuery(sql);
        }

        public static string GetIDByPartIDAndCardTypeID(string partID, string cardTypeID)
        {
            string sql = "select * from [Part] where PartID = '" + partID + "' and CardTypeID = '" + cardTypeID + "'";
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<string>("ID");
            }
            return "";
        }
    }
}
