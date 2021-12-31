﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace StoreProcedure
{
    public static class StoreProcedure<T> where T : DbContext
    {
        private static T _context;
        static StoreProcedure()
        {
            if (_context == null)
                _context = (T)Activator.CreateInstance(typeof(T));
        }

        #region All Public Methods To Use

        public static Output PostJson(string Store_Procedure_Name, Json Object_To_Json, Param Param, Output Output)
        {
            return PostJson_Method(Store_Procedure_Name, Object_To_Json, Param, Output);
        }

        public static List<T_Dto> GetDataTable<T_Dto>(string Store_Procedure_Name, Json Object_To_Json, Param Param)
        {
            return GetDataTable_Method<T_Dto>(Store_Procedure_Name, Object_To_Json, Param);
        }

        public static DataTable GetDataTable(string Store_Procedure_Name, Json Object_To_Json, Param Param)
        {
            return GetDataTable_Method(Store_Procedure_Name, Object_To_Json, Param);
        }

        #endregion

        #region All Privet Methods

        internal static Output PostJson_Method(string Store_Procedure_Name, Json Object_To_Json, Param Param, Output Output)
        {
            var _connection = _context.Database.GetDbConnection().ConnectionString;

            using (var connection = new SqlConnection(_connection))
            {
                string sql = Store_Procedure_Name;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (Object_To_Json != null)
                        Object_To_Json.ForEach(x =>
                        {
                            var json = JsonConvert.SerializeObject(x.Value);
                            var name = x.Key;
                            command.Parameters.AddWithValue(name, json);
                        });

                    if (Param != null)
                        foreach (var input in Param)
                        {
                            command.Parameters.AddWithValue(input.Key, input.Value);
                        }

                    if (Output != null)
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

                    if (Output != null)
                        foreach (var o in Output)
                        {
                            if (command.Parameters[o.Key].Value is DBNull)
                                o.Value = default;
                            else
                                o.Value = command.Parameters[o.Key].Value;
                        }

                    connection.Close();
                }

            }

            return Output;
        }

        internal static List<T_Dto> GetDataTable_Method<T_Dto>(string Store_Procedure_Name, Json Object_To_Json, Param Param)
        {
            var _connection = _context.Database.GetDbConnection().ConnectionString;
            var data = new DataTable();

            using (var connection = new SqlConnection(_connection))
            {
                string sql = Store_Procedure_Name;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (Object_To_Json != null)
                        Object_To_Json.ForEach(x =>
                        {
                            var json = JsonConvert.SerializeObject(x.Value);
                            var name = x.Key;
                            command.Parameters.AddWithValue(name, json);
                        });

                    if (Param != null)
                        foreach (var input in Param)
                        {
                            command.Parameters.AddWithValue(input.Key, input.Value);
                        }

                    connection.Open();
                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(command))
                    {
                        sqlAdapter.Fill(data);
                    }
                    connection.Close();
                }

            }

            return Convert.DataTable_To_Object<T_Dto>(data);
        }

        internal static DataTable GetDataTable_Method(string Store_Procedure_Name, Json Object_To_Json, Param Param)
        {
            var _connection = _context.Database.GetDbConnection().ConnectionString;
            var data = new DataTable();

            using (var connection = new SqlConnection(_connection))
            {
                string sql = Store_Procedure_Name;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (Object_To_Json != null)
                        Object_To_Json.ForEach(x =>
                        {
                            var json = JsonConvert.SerializeObject(x.Value);
                            var name = x.Key;
                            command.Parameters.AddWithValue(name, json);
                        });

                    if (Param != null)
                        foreach (var input in Param)
                        {
                            command.Parameters.AddWithValue(input.Key, input.Value);
                        }

                    connection.Open();
                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(command))
                    {
                        sqlAdapter.Fill(data);
                    }
                    connection.Close();
                }

            }

            return data;
        }

        #endregion
    }
}