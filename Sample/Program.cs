using EasyExtension.Data;
using System;
using System.Data;
namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        { 
            DataTable dt = new DataTable();
            dt.Columns.Add("idx", typeof(int));
            dt.Columns.Add("bolean", typeof(bool));
            dt.Columns.Add("date", typeof(DateTime));
            dt.Columns.Add("string", typeof(string));

            DataRow dr = dt.NewRow();
            dr["idx"] = 0;
            dr["bolean"] = true;
            dr["date"] = DateTime.Now;
            dr["string"] = "asdasd";

            Console.WriteLine(dr.ToBoolean("bolean"));
            Console.WriteLine(dr.ToBoolean("idx"));
            Console.WriteLine(dr.ToBoolean("string"));
            Console.WriteLine(dr.ToDateTimeString("date"));
            Console.ReadKey();
        }
    }
}
