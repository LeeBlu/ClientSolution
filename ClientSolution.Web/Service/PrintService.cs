using ClientSolution.Web.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSolution.Web.Service
{
    public static class PrintService 
    {
        public static void WriteToFile<T>(List<T> data) where T :class
        {
           
            string filepath =$@"C:\Temp\{data.GetType()}.txt";

            try
            {
                List<string> lines = new List<string>();
                StringBuilder line = new StringBuilder();

               // if (data == null || data.Count == 0)
                    //return false;

                var cols = data[0].GetType().GetProperties();

                foreach (var col in cols)
                {
                    line.Append(col.Name);
                    line.Append(",");
                }

                lines.Add(line.ToString().Substring(0, line.Length - 1));

                foreach (var row in data)
                {
                    line = new StringBuilder();
                    foreach (var col in cols)
                    {
                        line.Append(col.GetValue(row));
                        line.Append(",");
                    }

                    lines.Add(line.ToString().Substring(0, line.Length - 1));
                }
                System.IO.File.WriteAllLines(filepath, lines);

               // return true;
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }
    }
}
