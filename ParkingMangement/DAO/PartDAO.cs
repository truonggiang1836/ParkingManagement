using Newtonsoft.Json.Linq;
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
            string sql = "select Part.ID, Part.PartName, Part.Sign, Part.Amount, Type.TypeName, CardType.CardTypeName from Part, Type, CardType where Part.TypeID = Type.TypeID and Part.CardTypeID = CardType.CardTypeID and IsDeleted = 0 order by Part.ID asc";
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetAllDataForSync()
        {
            string sql = "select * from Part where IsDeleted = 0";
            return Database.ExcuQuery(sql);
        }

        public static void UpdateIsSync(string listId)
        {
            string sql = "update Part set IsSync = 1 where ID in " + listId;
            Database.ExcuNonQueryNoErrorMessage(sql);
        }

        public static DataTable GetAllTicketCommonData()
        {
            string sql = "select Part.ID, Part.PartName, Part.Sign, Part.Amount, Type.TypeName, CardType.CardTypeName from Part, Type, CardType where Part.TypeID = Type.TypeID and Part.CardTypeID = CardType.CardTypeID and Part.CardTypeID = '1' and IsDeleted = 0";
            return Database.ExcuQuery(sql);
        }

        public static string GetPartNameByPartID(string id)
        {
            string sql = "select PartName from Part where ID = '" + id + "'";
            DataTable data = Database.ExcuQuery(sql);
            if (data != null && data.Rows.Count > 0)
            {
                return data.Rows[0].Field<string>("PartName");
            }
            return "";
        }

        public static string GetCardTypeByID(string id)
        {
            string sql = "select CardTypeID from Part where ID = '" + id + "'";
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<string>("CardTypeID");
            }
            return "";
        }

        public static string GetTypeByID(string id)
        {
            string sql = "select TypeID from Part where ID = '" + id + "'";
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<string>("TypeID");
            }
            return "";
        }

        public static int GetAmountByPartID(string id)
        {
            string sql = "select Amount from Part where ID = '" + id + "'";
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<int>("Amount");
            }
            return 0;
        }

        public static string getInsertSql(PartDTO partDTO)
        {
            string sql = "insert into Part(ID, PartName, Sign, Amount, TypeID, CardTypeID, IsSync, IsDeleted) values (N'" + partDTO.ID + "', N'" + partDTO.Name + "', N'" +
                partDTO.Sign + "', " + partDTO.Amount + ", '" + partDTO.TypeID + "', '" + partDTO.CardTypeID + "', " + partDTO.IsSync + ", " + partDTO.IsDeleted + ")";
            return sql;
        }

        public static string getUpdateSql(PartDTO partDTO)
        {
            string sql = "update Part set PartName =(N'" + partDTO.Name + "'), Sign =(N'" + partDTO.Sign + "'), Amount =(" + partDTO.Amount + "), TypeID =('" + 
                partDTO.TypeID + "'), CardTypeID =('" + partDTO.CardTypeID + "'), IsSync =(" + partDTO.IsSync + "), IsDeleted =(" + partDTO.IsDeleted + ") where ID = '" + partDTO.ID + "'";
            return sql;
        }

        public static void Insert(PartDTO partDTO)
        {
            string sql = getInsertSql(partDTO);
            Database.ExcuNonQuery(sql);
        }

        public static void Update(PartDTO partDTO)
        {
            string sql = getUpdateSql(partDTO);
            Database.ExcuNonQuery(sql);
        }

        public static bool InsertNoErrorMessage(PartDTO partDTO)
        {
            string sql = getInsertSql(partDTO);
            return Database.ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool UpdateNoErrorMessage(PartDTO partDTO)
        {
            string sql = getUpdateSql(partDTO);
            return Database.ExcuNonQueryNoErrorMessage(sql);
        }

        public static void Delete(string partID)
        {
            //string sql = "delete from Part where ID = '" + partID + "'";
            string sql = "update Part set IsDeleted = 1, IsSync = 0 where ID = '" + partID + "'";
            Database.ExcuNonQuery(sql);
        }

        public static void syncFromJson(string json)
        {
            JArray jArray = JArray.Parse(json);
            foreach (JObject jObject in jArray)
            {
                PartDTO partDTO = new PartDTO();
                partDTO.ID = (string)jObject.SelectToken("vehicel_id");
                partDTO.Name = (string)jObject.SelectToken("name");
                partDTO.Sign = (string)jObject.SelectToken("code");
                int monthlyCost = 0;
                try
                {
                    Int32.TryParse((string)jObject.SelectToken("monthly_cost"), out monthlyCost);
                }
                catch (Exception)
                {

                }
                partDTO.Amount = monthlyCost;
                partDTO.TypeID = (string)jObject.SelectToken("vehicel_type");
                partDTO.CardTypeID = (string)jObject.SelectToken("card_type");
                partDTO.IsSync = "1";
                partDTO.IsDeleted = (bool)jObject.SelectToken("deleted") ? "1" : "0";

                InsertOrUpdate(partDTO);
            }
        }

        public static void InsertOrUpdate(PartDTO partDTO)
        {
            if (!InsertNoErrorMessage(partDTO))
            {
                UpdateNoErrorMessage(partDTO);
            }
        }
    }
}
