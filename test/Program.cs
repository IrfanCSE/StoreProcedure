using System;
using StoreProcedure;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test_PostJson();
            Test_PostDatatable();
        }

        #region Test_PostJson             
        static void Test_PostJson()
        {
            using (var context = new AppDbContext())
            {
                var obj = new { sms = "irfan", sms2 = "ul" };
                var obj2 = new { sms = "ul", sms2 = "fsfa" };

                var sp = "dbo.spPostJson";
                var json = new Json();
                json.Add("@Json", obj);
                json.Add("@Json2", obj2);
                var output = new Output();
                output.Add("@Output");

                var result = StoreProcedure<AppDbContext>.PostJson(sp, json, default, output);
                // var result = StoreProcedure<AppDbContext>.PostJson(sp, json, default, output);
                // var result2 = StoreProcedure<AppDbContextcopy>.PostJson(sp, json, output);

                var r = result.Find(x => x.Key == "@Output").Value.ToString();
                // var r2 = result2.Find(x => x.Key == "@Output").Value.ToString();

                System.Console.WriteLine($"Output is :-> {r}");
                // System.Console.WriteLine($"Output is :-> {r2}");
            }
        }
        #endregion

         #region Test_Post_Datatable             
        static void Test_PostDatatable()
        {
            using (var context = new AppDbContext())
            {
                var obj = new { sms = "irfan", sms2 = "ul" };
                var obj2 = new { sms = "ul", sms2 = "fsfa" };

                var data = new object[] { obj, obj2 };
                var sp = "dbo.spPostDatatable";
                var json = new Json();
                json.Add("@Json", data);
                // json.Add("@Json2", obj2);
                // var output = new Output();
                // output.Add("@Output");                

                // var result = StoreProcedure<AppDbContext>.GetDataTable(sp, json, default);
                var result = StoreProcedure<AppDbContext>.GetDataTable<obj>(sp, json, default);

                // var r = result.Find(x => x.Key == "@Output").Value.ToString();
                // var r2 = result2.Find(x => x.Key == "@Output").Value.ToString();

                System.Console.WriteLine($"Output is :-> {result}");
                // System.Console.WriteLine($"Output is :-> {r2}");
            }
        }
        #endregion

    }

    class obj
    {
        public string sms { get; set; }
        public string sms2 { get; set; }
    }
}
