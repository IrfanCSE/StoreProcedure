using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace StoreProcedure
{
    public static class StoreProcedureWithEF
    {
        public static Output Execute(this DbContext context, string Store_Procedure_Name, Json Object_To_Json, Param Param, Output Output)
        {
            return Core.PostJson_Method(Store_Procedure_Name, Object_To_Json, Param, Output, context);
        }
        public static void Execute(this DbContext context, string Store_Procedure_Name)
        {
            Core.PostJson_Method(Store_Procedure_Name, default, default, default, context);
        }

        public static Output Execute(this DbContext context, string Store_Procedure_Name, Output Output)
        {
            return Core.PostJson_Method(Store_Procedure_Name, default, default, Output, context);
        }

        public static Output Execute(this DbContext context, string Store_Procedure_Name,Param Param, Output Output)
        {
            return Core.PostJson_Method(Store_Procedure_Name, default, Param, Output, context);
        }
        public static Output Execute(this DbContext context, string Store_Procedure_Name, Json Object_To_Json, Output Output)
        {
            return Core.PostJson_Method(Store_Procedure_Name, Object_To_Json, default, Output, context);
        }

        public static List<T_Dto> Execute<T_Dto>(this DbContext context, string Store_Procedure_Name, Json Object_To_Json, Param Param)
        {
            return Core.GetDataTable_Method<T_Dto>(Store_Procedure_Name, Object_To_Json, Param, context);
        }
        public static List<T_Dto> Execute<T_Dto>(this DbContext context, string Store_Procedure_Name, Param Param)
        {
            return Core.GetDataTable_Method<T_Dto>(Store_Procedure_Name, default, Param, context);
        }
        public static List<T_Dto> Execute<T_Dto>(this DbContext context, string Store_Procedure_Name, Json Object_To_Json)
        {
            return Core.GetDataTable_Method<T_Dto>(Store_Procedure_Name, Object_To_Json, default, context);
        }

        public static DataTable Execute(this DbContext context, string Store_Procedure_Name, Json Object_To_Json, Param Param)
        {
            return Core.GetDataTable_Method(Store_Procedure_Name, Object_To_Json, Param, context);
        }

        public static DataTable Execute(this DbContext context, string Store_Procedure_Name, Param Param)
        {
            return Core.GetDataTable_Method(Store_Procedure_Name, default, Param, context);
        }
        public static DataTable Execute(this DbContext context, string Store_Procedure_Name, Json Object_To_Json)
        {
            return Core.GetDataTable_Method(Store_Procedure_Name, Object_To_Json, default, context);
        }
    }
}