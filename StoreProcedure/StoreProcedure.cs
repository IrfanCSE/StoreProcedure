using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace StoreProcedure
{
    internal static class StoreProcedure<T> where T : DbContext
    {
        private static T _context;
        static StoreProcedure()
        {
            if (_context == null)
                _context = (T)Activator.CreateInstance(typeof(T));
        }

        #region All Public Methods To Use

        public static Output Execute(string Store_Procedure_Name, Json Object_To_Json, Param Param, Output Output)
        {
            return Core.PostJson_Method(Store_Procedure_Name, Object_To_Json, Param, Output,_context);
        }

        public static List<T_Dto> Execute<T_Dto>(string Store_Procedure_Name, Json Object_To_Json, Param Param)
        {
            return Core.GetDataTable_Method<T_Dto>(Store_Procedure_Name, Object_To_Json, Param,_context);
        }

        public static DataTable Execute(string Store_Procedure_Name, Json Object_To_Json, Param Param)
        {
            return Core.GetDataTable_Method(Store_Procedure_Name, Object_To_Json, Param,_context);
        }

        #endregion
    }
}