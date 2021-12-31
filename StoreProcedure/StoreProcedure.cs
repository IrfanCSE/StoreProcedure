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
            // TODO:: Check for self Context
            if (_contextW == null)
                _contextW = (T)Activator.CreateInstance(typeof(T));
        }
        public static Output PostJson(string Store_Procedure_Name, Json Object_To_Json, Output Output)
        {
            var connection = new SqlConnection();
            var command = new SqlCommand();

            connection.ConnectionString = _contextW.Database.GetDbConnection().ConnectionString;

            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Store_Procedure_Name;

            Object_To_Json.ForEach(x =>
            {
                var json = JsonConvert.SerializeObject(x.Value);
                var name = x.Key;
                command.Parameters.AddWithValue(name, json);
            });

            foreach (var o in Output)
            {
                SqlDbType type = default;

                var typeName = o.Key.GetType().Name;

                // TODO:: need to add more type check
                if (typeName == "String") type = SqlDbType.VarChar;
                else if (typeName == "Int32") type = SqlDbType.Int;

                command.Parameters.Add(o.Key, type, 100);
                command.Parameters[o.Key].Direction = ParameterDirection.Output;
            }

            connection.Open();

            var i = command.ExecuteNonQuery();

            foreach (var o in Output)
            {
                o.Value = command.Parameters[o.Key].Value;
            }

            connection.Close();

            return Output;
        }
    }
}