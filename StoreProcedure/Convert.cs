using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace StoreProcedure
{
    public class Convert
    {
        public static List<T> DataTable_To_Object<T>(DataTable dt)
        {
            var data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    Type dType = pro.GetType();

                    if (pro.Name == column.ColumnName)
                    {
                        var value = dr[column.ColumnName] is DBNull ? null : dr[column.ColumnName];
                        pro.SetValue(obj, value, null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }

    }
}