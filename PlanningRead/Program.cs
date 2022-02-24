using System;
using System.IO;

namespace PlanningRead
{
    class Program
    {
        static void Main(string[] args)
        {


            foreach (var item in PlanningReader.GetAllValue(File.ReadAllText("cache/0.ical", System.Text.Encoding.UTF8), "DESCRIPTION;LANGUAGE=fr"))
            {
                String[] split0 = item.Split("\\n");
                foreach (var i in split0)   
                {
                    Console.WriteLine(i);
                }
            }


        }
    }
}
