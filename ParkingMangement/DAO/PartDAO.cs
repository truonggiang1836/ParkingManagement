﻿using Newtonsoft.Json.Linq;
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
            string sql = "select Part.ID, Part.PartName, Part.Sign, Part.Amount, Type.TypeName, CardType.CardTypeName from Part, Type, CardType where Part.TypeID = Type.TypeID and Part.CardTypeID = CardType.CardTypeID order by Part.ID asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetAllDataForSync()
        {
            string sql = "select * from Part where IsSync = 0";
            return (new Database()).ExcuQuery(sql);
        }

        public static void UpdateIsSync(string id)
        {
            string sql = "update Part set IsSync = 1 where ID in " + id;
            (new Database()).ExcuNonQuery(sql);
        }

        public static DataTable GetAllTicketCommonData()
        {
            string sql = "select Part.ID, Part.PartName, Part.Sign, Part.Amount, Type.TypeName, CardType.CardTypeName from Part, Type, CardType where Part.TypeID = Type.TypeID and Part.CardTypeID = CardType.CardTypeID and Part.CardTypeID = '1'";
            return (new Database()).ExcuQuery(sql);
        }

        public static string GetPartNameByPartID(string id)
        {
            string sql = "select PartName from Part where ID = '" + id + "'";
            DataTable data = (new Database()).ExcuQuery(sql);
            if (data != null && data.Rows.Count > 0)
            {
                return data.Rows[0].Field<string>("PartName");
            }
            return "";
        }

        public static string GetSignByPartID(string id)
        {
            string sql = "select Sign from Part where ID = '" + id + "'";
            DataTable data = (new Database()).ExcuQuery(sql);
            if (data != null && data.Rows.Count > 0)
            {
                return data.Rows[0].Field<string>("Sign");
            }
            return "";
        }

        public static string GetCardTypeByID(string id)
        {
            string sql = "select CardTypeID from Part where ID = '" + id + "'";
            DataTable data = (new Database()).ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<string>("CardTypeID");
            }
            return "";
        }

        public static string GetTypeByID(string id)
        {
            string sql = "select TypeID from Part where ID = '" + id + "'";
            DataTable data = (new Database()).ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<string>("TypeID");
            }
            return "";
        }

        public static int GetAmountByPartID(string id)
        {
            string sql = "select Amount from Part where ID = '" + id + "'";
            DataTable data = (new Database()).ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<int>("Amount");
            }
            return 0;
        }

        public static string getInsertSql(PartDTO partDTO)
        {
            string sql = "insert into Part(ID, PartName, Sign, Amount, TypeID, CardTypeID, IsSync, IsDeleted) values ('" + partDTO.ID + "', '" + partDTO.Name + "', '" +
                partDTO.Sign + "', " + partDTO.Amount + ", '" + partDTO.TypeID + "', '" + partDTO.CardTypeID + "', " + partDTO.IsSync + ", " + partDTO.IsDeleted + ")";
            return sql;
        }

        public static string getUpdateSql(PartDTO partDTO)
        {
            string sql = "update Part set PartName =('" + partDTO.Name + "'), Sign =('" + partDTO.Sign + "'), Amount =(" + partDTO.Amount + "), TypeID =('" + 
                partDTO.TypeID + "'), CardTypeID =('" + partDTO.CardTypeID + "'), IsSync =(" + partDTO.IsSync + "), IsDeleted =(" + partDTO.IsDeleted + ") where ID = '" + partDTO.ID + "'";
            return sql;
        }

        public static void Insert(PartDTO partDTO)
        {
            string sql = getInsertSql(partDTO);
            (new Database()).ExcuNonQuery(sql);
        }

        public static void Update(PartDTO partDTO)
        {
            string sql = getUpdateSql(partDTO);
            (new Database()).ExcuNonQuery(sql);
        }

        public static bool InsertNoErrorMessage(PartDTO partDTO)
        {
            string sql = getInsertSql(partDTO);
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool UpdateNoErrorMessage(PartDTO partDTO)
        {
            string sql = getUpdateSql(partDTO);
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static void Delete(string partID)
        {
            string sql = "delete from Part where ID = '" + partID + "'";
            (new Database()).ExcuNonQuery(sql);
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
                partDTO.Amount = (int)jObject.SelectToken("monthly_cost");
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
