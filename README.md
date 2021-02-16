# Easy-extension
Here is a sample for how to use


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



            List<Test> lst = new List<Test>();
            for (int i = 0; i < 5; i++)
            {
                lst.Add(new Test() { ID = i.ToString(), Name = $"name{i}", Count = i });
            }

            List<int> filter = lst.ToList(l=>l.Count );
            Console.ReadKey();
        }
    }
    class Test
    {
       public string ID { get; set; }
       public string Name { get; set; }
        public int Count { get; set; }
    }
