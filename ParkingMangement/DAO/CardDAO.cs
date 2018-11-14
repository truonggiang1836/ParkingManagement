using ParkingMangement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class CardDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select SmartCard.Identify, SmartCard.ID, SmartCard.IsUsing, Part.PartName from [SmartCard], [Part] where SmartCard.Type = Part.PartID order by SmartCard.Identify asc";
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetLostCardData()
        {
            string sql = "select SmartCard.Identify, SmartCard.ID, Part.PartName from [SmartCard], [Part] where SmartCard.IsUsing = '0' and SmartCard.Type = Part.PartID order by SmartCard.Identify asc";
            return Database.ExcuQuery(sql);
        }

        public static bool Insert(CardDTO cardDTO)
        {
            string sql = "insert into SmartCard(SystemID, Identify, ID, IsUsing, Type, DayUnlimit) values ('" + cardDTO.SystemId + "', " + cardDTO.Identify + ",'" + cardDTO.Id + "', '" + cardDTO.IsUsing + "', " + cardDTO.Type + ", '" + cardDTO.DayUnlimit + "')";
            return Database.ExcuNonQueryNoErrorMessage(sql);
        }

        public static void Update(CardDTO cartDTO)
        {
            string sql = "update [SmartCard] set Identify =(" + cartDTO.Identify + "), IsUsing =('" + cartDTO.IsUsing + "'), Type =(" + cartDTO.Type + "), DayUnlimit =('"
                + cartDTO.DayUnlimit + "') where ID ='" + cartDTO.Id + "'";
            Database.ExcuNonQuery(sql);
        }

        public static void UpdateIsUsing(string isUsing, string cardId)
        {
            string sql = "update [SmartCard] set IsUsing = '" + isUsing + "' where ID = '" + cardId + "'";
            Database.ExcuNonQuery(sql);
        }

        public static void UpdateDayUnlimit(DateTime dayUnlimit, string cardId)
        {
            string sql = "update [SmartCard] set DayUnlimit = '" + dayUnlimit + "' where ID = '" + cardId + "'";
            Database.ExcuNonQuery(sql);
        }

        public static DataTable SearchData(string key)
        {
            string sql = "select SmartCard.Identify, SmartCard.ID, SmartCard.IsUsing, Part.PartName from [SmartCard], [Part] where SmartCard.Type = Part.PartID and "
                + "(SmartCard.Identify like '%" + key + "%' or SmartCard.ID like '%" + key + "%' or Part.PartName like '%" + key + "%') order by SmartCard.Identify asc";
            return Database.ExcuQuery(sql);
        }

        public static DataTable SearchLostCardData(string key)
        {
            string sql = "select SmartCard.Identify, SmartCard.ID, Part.PartName from [SmartCard], [Part] where SmartCard.IsUsing = '0' and SmartCard.Type = Part.PartID and "
                + "(SmartCard.Identify like '%" + key + "%' or SmartCard.ID like '%" + key + "%' or Part.PartName like '%" + key + "%') order by SmartCard.Identify asc";
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetDataGroupByType()
        {
            string sql = "select Part.PartName, count(Identify) as SumCard from [SmartCard], [Part] where (SmartCard.Type = Part.PartID) and (SmartCard.IsUsing = '1') group by Part.PartName";
            DataTable data = Database.ExcuQuery(sql);

            data.Columns.Add("IsUsing", typeof(System.String));
            for (int row = 0; row < data.Rows.Count; row++)
            {
                data.Rows[row].SetField("IsUsing", "Dùng");
            }
            return data;
        }

        public static int GetCardCount()
        {
            return GetAllData().Rows.Count;
        }

        public static int GetUsingCardCount()
        {
            string sql = "select * from [SmartCard] where SmartCard.IsUsing = '1'";
            return Database.ExcuQuery(sql).Rows.Count;
        }

        public static int GetNotUsingCardCount()
        {
            string sql = "select * from [SmartCard] where SmartCard.IsUsing = '0'";
            return Database.ExcuQuery(sql).Rows.Count;
        }

        public static bool Delete(string userID)
        {
            string sql = "delete from [SmartCard] where ID = '" + userID + "'";
            return Database.ExcuNonQuery(sql);
        }

        public static string getPartIDByCardID(string cardID)
        {
            string sql = "select * from [SmartCard] where ID = '" + cardID + "'";
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("Type");
            }
            return "";
        }

        public static int getIdentifyByCardID(string cardID)
        {
            string sql = "select * from [SmartCard] where ID = '" + cardID + "'";
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("Identify");
            }
            return 0;
        }

        public static bool isUsingByCardID(string cardID)
        {
            string sql = "select * from [SmartCard] where ID = '" + cardID + "'";
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                string isUsing = dt.Rows[0].Field<string>("IsUsing");
                return isUsing.Equals("1");
            }
            return false;
        }

        public static DataTable GetCardByID(string id)
        {
            string sql = "select * from [SmartCard] where ID = '" + id + "'";
            return Database.ExcuQuery(sql);
        }

        public static CardDTO GetCardModelByID(string id)
        {
            CardDTO cardDTO = new CardDTO();
            DataTable dt = GetCardByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                cardDTO.Identify = dt.Rows[0].Field<int>("Identify");
                cardDTO.Id = dt.Rows[0].Field<string>("Id");
                cardDTO.IsUsing = dt.Rows[0].Field<string>("IsUsing");
                cardDTO.Type = dt.Rows[0].Field<int>("Type");
                cardDTO.DayUnlimit = dt.Rows[0].Field<DateTime>("DayUnlimit");
            }
            return cardDTO;
        }
    }
}
