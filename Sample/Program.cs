using EasyExtension.Data;
using EasyExtension;
using System;
using System.Data;
using System.Collections.Generic;
namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        { 
            //Generate test table
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
            //sample to use datarow extension
            Console.WriteLine("--------DataRow extension-----------");
            Console.WriteLine("DataTable source:");
            foreach (DataColumn item in dt.Columns)
            {
                Console.WriteLine($"ColumnName :{item.ColumnName}\tDataType:{item.DataType.Name}\tValue:{dr[item]}");
            }
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"DataRow(bool) to boolean:\t{dr.ToBoolean("bolean")}");
            Console.WriteLine($"DataRow(int) to boolean:\t{dr.ToBoolean("idx")}");
            Console.WriteLine($"DataRow(string) to boolean:\t{dr.ToBoolean("string")}");
            Console.WriteLine($"DataRow(DateTime) to string:\t{dr.ToDateTimeString("date")}");
            Console.WriteLine($"DataRow(DateTime) to DateTime:\t{dr.ToDateTime("date")}");
            Console.WriteLine();
            Console.WriteLine();
            //datetime extension
            Console.WriteLine("-----Format datetime to string------");
            DateTime date = DateTime.Now;
            Console.WriteLine($"Source :\t{date}");
            Console.WriteLine("----------------------------------------------------------");
            string startDate = date.ToBeginDate();
            string endDate = date.ToEndDate();
            Console.WriteLine($"To begin date string:\t{startDate}");
            Console.WriteLine($"To end date string:\t{endDate}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------Format Date-------------");
            Console.WriteLine($"Source :\t{date}");
            Console.WriteLine("----------------------------------------------------------");
            DateTime dtStartDate = date.FormatBeginDate();
            DateTime dtEndDate = date.FormatEndDate();
            Console.WriteLine($"To begin date :\t{dtStartDate}");
            Console.WriteLine($"To end date :\t{dtEndDate}");

            //others
            List<Test> lst = new List<Test>();
            for (int i = 0; i < 5; i++)
            {
                lst.Add(new Test() { ID = i.ToString(), Name = $"name{i}", Count = i });
            }

            List<int> filter = lst.ToList(l => l.Count);
            string strsample = "ddaasa";
            int mint = strsample.ToInt32(-1);
            ushort mushort = strsample.ToUShort(0);
            Console.ReadKey();
        }
    }
    class Test
    {
       public string ID { get; set; }
       public string Name { get; set; }
        public int Count { get; set; }
    }
}
