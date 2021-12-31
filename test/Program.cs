using System;
using StoreProcedure;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Test_PostJson();
        }

        #region Test_PostJson             
        static void Test_PostJson()
        {
            using (var context = new AppDbContext())
            {
                var obj = new { sms = "irfan",sms2 = "ul" };
                var obj2 = new { sms = "ul",sms2 = "fsfa" };

                var sp = "dbo.spPostJson";
                var json = new Json();
                json.Add("@Json", obj);
                json.Add("@Json2", obj2);
                var output = new Output();
                output.Add("@Output");

                var result = StoreProcedure<AppDbContext>.PostJson(sp, json, output);
                var result2 = StoreProcedure<AppDbContextcopy>.PostJson(sp, json, output);

                var r = result.Find(x => x.Key == "@Output").Value.ToString();
                var r2 = result2.Find(x => x.Key == "@Output").Value.ToString();

                System.Console.WriteLine($"Output is :-> {r}");
                System.Console.WriteLine($"Output is :-> {r2}");
            }
        }
        #endregion

    }
}
