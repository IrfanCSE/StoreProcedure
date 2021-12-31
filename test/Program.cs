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
                var obj = new { sms = "irfan" };

                var sp = "dbo.spPostJson";
                var json = new Json();
                json.Add("@Json", obj);
                var output = new Output();
                output.Add("@Output");

                var result = StoreProcedure<AppDbContext>.PostJson(sp, json, output);

                var r = result.Find(x => x.Key == "@Output").Value.ToString();

                System.Console.WriteLine($"Output is :-> {r}");
            }
        }
        #endregion

    }
}
