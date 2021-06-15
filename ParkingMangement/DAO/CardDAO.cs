using Newtonsoft.Json.Linq;
using ParkingMangement.DTO;
using ParkingMangement.Utils;
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
            string sql = "select SmartCard.Identify, SmartCard.ID, SmartCard.IsUsing, Part.PartName, CardType.CardTypeName from SmartCard, Part, CardType where SmartCard.Type = Part.ID and Part.CardTypeID = CardType.CardTypeID and SmartCard.IsDeleted = 0 order by SmartCard.Identify asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetAllNotRegisterMonthlyCardData()
        {
            string sql = "select card.Identify, card.ID, card.IsUsing, Part.PartName, CardType.CardTypeName from Part, CardType, SmartCard card left join TicketMonth monthlyCard on card.ID = monthlyCard.ID " +
                "where monthlyCard.ID IS NULL and card.Type = Part.ID and Part.CardTypeID = CardType.CardTypeID and CardType.CardTypeID = 2 and card.IsDeleted = 0 order by card.Identify asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetAllDataForSync()
        {
            string sql = "select top 50 * from SmartCard where IsSync = 0 order by SmartCard.Identify asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static void UpdateIsSync(string id)
        {
            string sql = "update SmartCard set IsSync = 1 where ID in " + id;
            (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static string GetLastCardIdentify()
        {
            string sql = "select Identify from SmartCard where SmartCard.IsDeleted = 0 order by DayUnlimit desc";
            DataTable dt = (new Database()).ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                string identify = dt.Rows[0].Field<string>("Identify");
                return identify;
            }
            return "";
        }

        public static DataTable GetLostCardData()
        {
            string sql = "select SmartCard.Identify, SmartCard.ID, Part.PartName from SmartCard, Part where SmartCard.IsUsing = '0' and SmartCard.Type = Part.ID and SmartCard.IsDeleted = 0 order by SmartCard.Identify asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static CardDTO getCardFromDataRow(DataRow dataRow)
        {
            CardDTO cardDTO = new CardDTO();
            cardDTO.Identify = dataRow.Field<String>("Identify");
            cardDTO.Id = dataRow.Field<String>("ID");
            cardDTO.Type = dataRow.Field<String>("Type");
            cardDTO.IsUsing = dataRow.Field<String>("IsUsing"); ;
            cardDTO.DayUnlimit = DateTime.Now;
            cardDTO.SystemId = cardDTO.Id;
            return cardDTO;
        }

        public static bool Insert(CardDTO cardDTO)
        {
            HardDeleteIfCardBeDeleted(cardDTO.Id);

            string sql = "insert into SmartCard(SystemID, Identify, ID, IsUsing, IsSync, IsDeleted, Type, DayUnlimit) values ('" + cardDTO.SystemId + "', '" + cardDTO.Identify + "','" + cardDTO.Id + "', '" + cardDTO.IsUsing + "', '" + cardDTO.IsSync + "', '" + cardDTO.IsDeleted + "', '" + cardDTO.Type + "', '" + cardDTO.DayUnlimit.ToString(Constant.sDateTimeFormatForQuery) + "')";
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool Insert(List<CardDTO> listCardDTO)
        {
            string sql = "insert into SmartCard(SystemID, Identify, ID, IsUsing, IsDeleted, Type, DayUnlimit) values ";
            if (listCardDTO.Count > 0)
            {
                for (int i = 0; i < listCardDTO.Count; i++)
                {
                    CardDTO cardDTO = listCardDTO[i];
                    sql += "('" + cardDTO.SystemId + "', '" + cardDTO.Identify + "','" + cardDTO.Id + "', '" + cardDTO.IsUsing + "', '" + cardDTO.IsDeleted + "', '" + cardDTO.Type + "', '" + cardDTO.DayUnlimit.ToString(Constant.sDateTimeFormatForQuery) + "')";
                    if (i < listCardDTO.Count - 1)
                    {
                        sql += ",";
                    }
                }
                return (new Database()).ExcuNonQueryNoErrorMessage(sql);
            }
            return false;
        }

        public static string getUpdateSql(CardDTO cartDTO)
        {
            string sql = "update SmartCard set Identify =('" + cartDTO.Identify + "'), IsUsing =('" + cartDTO.IsUsing + "'), IsSync =('" + cartDTO.IsSync + "'), IsDeleted =('" + cartDTO.IsDeleted + "'), Type =('" + cartDTO.Type + "'), DayUnlimit =('"
                + cartDTO.DayUnlimit.ToString(Constant.sDateTimeFormatForQuery) + "') where ID ='" + cartDTO.Id + "'";
            return sql;
        }

        public static bool UpdateNoErrorMessage(CardDTO cartDTO)
        {
            string sql = getUpdateSql(cartDTO);
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static void Update(CardDTO cartDTO)
        {
            string sql = getUpdateSql(cartDTO);
            (new Database()).ExcuNonQuery(sql);
        }

        public static void UpdateIsUsing(string isUsing, string cardId)
        {
            string sql = "update SmartCard set IsUsing = '" + isUsing + "', IsSync = 0 where ID = '" + cardId + "'";
            (new Database()).ExcuNonQuery(sql);
        }

        public static void lockExpiredCardWithDeposit()
        {
            string sql = "update SmartCard set SmartCard.IsUsing = 0, SmartCard.IsSync = 0 from SmartCard inner join TicketMonth on SmartCard.ID = TicketMonth.ID"
                + " where DATEDIFF(MONTH, DATEADD(DAY, -1, TicketMonth.ExpirationDate), getdate()) >= 2 and DATEDIFF(DAYOFYEAR, TicketMonth.ExpirationDate, getdate()) >= 28 and SmartCard.IsUsing = 1 and TicketMonth.IsDeleted = 0 and SmartCard.IsDeleted = 0";
            (new Database()).ExcuNonQuery(sql);
        }

        public static void lockExpiredCardNoDeposit(int lockCardDate)
        {
            DateTime currentDate = DateTime.Now;
            string sql = "update SmartCard set SmartCard.IsUsing = 0, SmartCard.IsSync = 0 from SmartCard inner join TicketMonth on SmartCard.ID = TicketMonth.ID"
                + " where TicketMonth.ExpirationDate < '" + currentDate.AddDays(-lockCardDate + 1).Date.ToString(Constant.sDateTimeFormatForQuery) + "' and SmartCard.IsUsing = 1 and TicketMonth.IsDeleted = 0 and SmartCard.IsDeleted = 0";
            (new Database()).ExcuNonQuery(sql); 
        }

        public static void UpdateDayUnlimit(DateTime dayUnlimit, string cardId)
        {
            string sql = "update SmartCard set DayUnlimit = '" + dayUnlimit.ToString(Constant.sDateTimeFormatForQuery) + "', SmartCard.IsSync = 0 where ID = '" + cardId + "'";
            (new Database()).ExcuNonQuery(sql);
        }

        public static void UpdateIdentify(string identify, string cardId)
        {
            string sql = "update SmartCard set Identify = '" + identify + "', SmartCard.IsSync = 0 where ID = '" + cardId + "'";
            (new Database()).ExcuNonQuery(sql);
        }

        public static DataTable SearchData(string key)
        {
            string sql = "select SmartCard.Identify, SmartCard.ID, SmartCard.IsUsing, Part.PartName from SmartCard, Part, CardType where SmartCard.Type = Part.ID and Part.CardTypeID = CardType.CardTypeID and "
                + "(SmartCard.Identify like '%" + key + "%' or SmartCard.ID like '%" + key + "%' or Part.PartName like '%" + key + "%') and SmartCard.IsDeleted = 0 order by SmartCard.Identify asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable SearchUsingCardData(string key)
        {
            string sql = "select SmartCard.Identify, SmartCard.ID, Part.PartName from SmartCard, Part where SmartCard.IsUsing = '1' and SmartCard.Type = Part.ID and "
                + "(SmartCard.Identify like '%" + key + "%' or SmartCard.ID like '%" + key + "%' or Part.PartName like '%" + key + "%') and SmartCard.IsDeleted = 0 order by SmartCard.Identify asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable SearchLostCardData(string key)
        {
            string sql = "select SmartCard.Identify, SmartCard.ID, Part.PartName from SmartCard, Part where SmartCard.IsUsing = '0' and SmartCard.Type = Part.ID and "
                + "(SmartCard.Identify like '%" + key + "%' or SmartCard.ID like '%" + key + "%' or Part.PartName like '%" + key + "%') and SmartCard.IsDeleted = 0 order by SmartCard.Identify asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetDataGroupByType()
        {
            string sql = "select Part.PartName, count(Identify) as SumCard from SmartCard, Part where (SmartCard.Type = Part.ID) and (SmartCard.IsUsing = '1') and SmartCard.IsDeleted = 0 group by Part.PartName";
            DataTable data = (new Database()).ExcuQuery(sql);

            data.Columns.Add("IsUsing", typeof(System.String));
            for (int row = 0; row < data.Rows.Count; row++)
            {
                data.Rows[row].SetField("IsUsing", "Dùng");
            }
            return data;
        }

        public static int GetUsingCardCount()
        {
            string sql = "select SmartCard.ID from SmartCard, Part where SmartCard.Type = Part.ID and SmartCard.IsUsing = '1' and SmartCard.IsDeleted = 0";
            DataTable dt = (new Database()).ExcuQuery(sql);
            if (dt != null)
            {
                return dt.Rows.Count;
            }
            return 0;
        }

        public static int GetNotUsingCardCount()
        {
            string sql = "select SmartCard.ID from SmartCard, Part where SmartCard.Type = Part.ID and SmartCard.IsUsing = '0' and SmartCard.IsDeleted = 0";
            DataTable dt = (new Database()).ExcuQuery(sql);
            if (dt != null)
            {
                return dt.Rows.Count;
            }
            return 0;
        }

        public static bool Delete(string id)
        {
            //string sql = "delete from SmartCard where ID = '" + id + "'";
            string sql = "update SmartCard set IsDeleted = 1, IsSync = 0 where ID = '" + id + "'";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool DeleteNoErrorMessage(string id)
        {
            string sql = "update SmartCard set IsDeleted = 1, IsSync = 0 where ID = '" + id + "'";
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool HardDeleteIfCardBeDeleted(string id)
        {
            string sql = "delete from SmartCard where ID = '" + id + "' and IsDeleted = 1";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static string getPartIDByCardID(string cardID)
        {
            string sql = "select Type from SmartCard where ID = '" + cardID + "'";
            DataTable dt = (new Database()).ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("Type");
            }
            return "";
        }

        public static string GetPartName_TypeNameByCardID(string cardID)
        {
            string sql = "select Part.PartName, Type.TypeName from SmartCard, Part, Type where SmartCard.Type = Part.ID"
                + " and Part.TypeID = Type.TypeID and SmartCard.ID = '" + cardID + "'";
            DataTable data = (new Database()).ExcuQuery(sql);
            if (data != null && data.Rows.Count > 0)
            {
                string partName = data.Rows[0].Field<string>("PartName");
                return partName;
                //string typeName = data.Rows[0].Field<string>("TypeName");
                //return partName + " - " + typeName;
            }
            return "";
        }

        public static string getIdentifyByCardID(string cardID)
        {
            string sql = "select Identify from SmartCard where ID = '" + cardID + "' and SmartCard.IsDeleted = 0";
            DataTable dt = (new Database()).ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("Identify");
            }
            return "";
        }

        public static bool isUsingByCardID(string cardID)
        {
            string sql = "select IsUsing from SmartCard where ID = '" + cardID + "' and SmartCard.IsDeleted = 0";
            DataTable dt = (new Database()).ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                string isUsing = dt.Rows[0].Field<string>("IsUsing");
                return isUsing.Equals("1");
            }
            return false;
        }

        public static DataTable GetCardByID(string id)
        {
            string sql = "select * from SmartCard where ID = '" + id + "' and SmartCard.IsDeleted = 0";
            return (new Database()).ExcuQuery(sql);
        }

        public static int GetCardCountByPartId(string partId)
        {
            string sql = "select * from SmartCard where Type = '" + partId + "' and SmartCard.IsDeleted = 0";
            return (new Database()).ExcuQuery(sql).Rows.Count;
        }

        public static DataTable GetNotDeletedCardByID(string id)
        {
            string sql = "select top 1 * from SmartCard where ID = '" + id + "' and IsDeleted = 0";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetNotDeletedCardByIDForCardReader(string id)
        {
            string sql = "select top 1 SmartCard.Identify, SmartCard.IsUsing, SmartCard.Type, SmartCard.IsDeleted, Part.PartName, Part.CardTypeID from SmartCard inner join Part on SmartCard.Type = Part.ID where SmartCard.ID = '" + id + "' and SmartCard.IsDeleted = 0";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetCardByIdentify(string identify)
        {
            string sql = "select * from SmartCard where Identify = '" + identify + "' and SmartCard.IsDeleted = 0";
            return (new Database()).ExcuQuery(sql);
        }

        public static CardDTO GetCardModelByID(string id)
        {
            CardDTO cardDTO = new CardDTO();
            DataTable dt = GetCardByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                cardDTO.Identify = dt.Rows[0].Field<string>("Identify");
                cardDTO.Id = dt.Rows[0].Field<string>("Id");
                cardDTO.IsUsing = dt.Rows[0].Field<string>("IsUsing");
                cardDTO.Type = dt.Rows[0].Field<string>("Type");
                cardDTO.IsSync = dt.Rows[0].Field<Int32>("IsSync") + "";
                cardDTO.IsDeleted = dt.Rows[0].Field<Int32>("IsDeleted") + "";
                if (dt.Rows[0].Field<Object>("DayUnlimit") != null)
                {
                    cardDTO.DayUnlimit = dt.Rows[0].Field<DateTime>("DayUnlimit");
                }
                return cardDTO;
            }
            return null;
        }

        public static CardDTO GetNotDeletedCardModelByID(string id)
        {
            CardDTO cardDTO = null;
            DataTable dt = GetNotDeletedCardByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                cardDTO = new CardDTO();
                cardDTO.Identify = dt.Rows[0].Field<string>("Identify");
                cardDTO.Id = dt.Rows[0].Field<string>("Id");
                cardDTO.IsUsing = dt.Rows[0].Field<string>("IsUsing");
                cardDTO.Type = dt.Rows[0].Field<string>("Type");
                cardDTO.IsSync = dt.Rows[0].Field<Int32>("IsSync") + "";
                cardDTO.IsDeleted = dt.Rows[0].Field<Int32>("IsDeleted") + "";
                if (dt.Rows[0].Field<Object>("DayUnlimit") != null)
                {
                    cardDTO.DayUnlimit = dt.Rows[0].Field<DateTime>("DayUnlimit");
                }
                return cardDTO;
            }
            return null;
        }

        public static CardDTO GetNotDeletedCardModelByIDForReadCard(string id)
        {
            CardDTO cardDTO = null;
            DataTable dt = GetNotDeletedCardByIDForCardReader(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                cardDTO = new CardDTO();
                cardDTO.Identify = dt.Rows[0].Field<string>("Identify");
                cardDTO.IsUsing = dt.Rows[0].Field<string>("IsUsing");
                cardDTO.Type = dt.Rows[0].Field<string>("Type");
                cardDTO.CardTypeID = dt.Rows[0].Field<string>("CardTypeID");
                cardDTO.PartName = dt.Rows[0].Field<string>("PartName");
                return cardDTO;
            }
            return null;
        }

        public static CardDTO GetCardModelByIdentify(string identify)
        {
            CardDTO cardDTO = new CardDTO();
            DataTable dt = GetCardByIdentify(identify);
            if (dt != null && dt.Rows.Count > 0)
            {
                cardDTO.Identify = dt.Rows[0].Field<string>("Identify");
                cardDTO.Id = dt.Rows[0].Field<string>("Id");
                cardDTO.IsUsing = dt.Rows[0].Field<string>("IsUsing");
                cardDTO.Type = dt.Rows[0].Field<string>("Type");
                cardDTO.IsSync = dt.Rows[0].Field<Int32>("IsSync") + "";
                cardDTO.IsDeleted = dt.Rows[0].Field<Int32>("IsDeleted") + "";
                if (dt.Rows[0].Field<Object>("DayUnlimit") != null)
                {
                    cardDTO.DayUnlimit = dt.Rows[0].Field<DateTime>("DayUnlimit");
                }
                return cardDTO;
            }
            return null;
        }

        public static string GetTypeByID(string id)
        {
            string sql = "select Part.TypeID from Part, SmartCard where SmartCard.Type = Part.ID and SmartCard.ID = '" + id + "'";
            DataTable data = (new Database()).ExcuQuery(sql);
            if (data != null && data.Rows.Count > 0)
            {
                return data.Rows[0].Field<string>("TypeID");
            }
            return "";
        }

        public static string GetCardTypeByID(string id)
        {
            string sql = "select Part.CardTypeID from Part, SmartCard where SmartCard.Type = Part.ID and SmartCard.ID = '" + id + "'";
            DataTable data = (new Database()).ExcuQuery(sql);
            if (data != null && data.Rows.Count > 0)
            {
                return data.Rows[0].Field<string>("CardTypeID");
            }
            return "";
        }

        public static void syncFromJson(string json)
        {
            JArray jArray = JArray.Parse(json);
            foreach (JObject jObject in jArray)
            {
                CardDTO cardDTO = new CardDTO();
                cardDTO.SystemId = jObject.GetValue("code").ToString();
                cardDTO.Id = jObject.GetValue("code").ToString();
                cardDTO.IsUsing = jObject.GetValue("disable").ToString() == "0" ? "1" : "0";
                cardDTO.IsDeleted = (bool)jObject.SelectToken("deleted") ? "1" : "0";
                cardDTO.Identify = jObject.GetValue("stt").ToString();
                cardDTO.Type = jObject.GetValue("vehicle_id").ToString();
                cardDTO.DayUnlimit = DateTime.Now;
                cardDTO.IsSync = "1";

                InsertOrUpdate(cardDTO);
            }
        }

        public static void InsertOrUpdate(CardDTO cardDTO)
        {
            if (!Insert(cardDTO))
            {
                UpdateNoErrorMessage(cardDTO);
            }
        }
    }
}
