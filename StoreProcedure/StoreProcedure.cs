using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace StoreProcedure
{
    public static class StoreProcedure<T> where T : DbContext
    {
        private static T _contextW;
        static StoreProcedure()
        {
            if (_contextW == null)
                _contextW = (T)Activator.CreateInstance(typeof(T));
        }
        public static List<KeyValue> PostJson(string StoredProcedure, List<KeyValue> JsonObject, List<KeyValue> Output)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = _contextW.Database.GetDbConnection().ConnectionString;
            // conn.ConnectionString = _contextW.Database.GetConnectionString();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedure;

            JsonObject.ForEach(x =>
            {
                var json = JsonConvert.SerializeObject(x.Value);
                var name = x.Key;
                cmd.Parameters.AddWithValue(name, json);
            });

            foreach (var o in Output)
            {
                var typeName = o.Key.GetType().Name;
                SqlDbType type = SqlDbType.VarChar;

                if (typeName == "String") type = SqlDbType.VarChar;
                else if (typeName == "Int32") type = SqlDbType.Int;

                cmd.Parameters.Add(o.Key, type, 100);
                cmd.Parameters[o.Key].Direction = ParameterDirection.Output;
            }

            conn.Open();
            int i = cmd.ExecuteNonQuery();

            foreach (var o in Output)
            {
                o.Value = cmd.Parameters[o.Key].Value;
            }

            conn.Close();

            return Output;
        }
    }
}