using System;
using System.IO;

namespace PlanningRead
{
    class Program
    {
        static void Main(string[] args)
        {
            PlanningReader planningReader = new("Edt_Licence_3_Miashs_parcours_Miage.ics", "2021.0.1.3", "BE5E4C87C66B25F0E3DA315EA60FC275", "643d5b312e2e36325d2666683d3126663d3131303030");
            foreach (var item in PlanningReader.GetAllFields(PlanningReader.GetIcalContent("Edt_Licence_3_Miashs_parcours_Miage.ics", "2021.0.1.3", "BE5E4C87C66B25F0E3DA315EA60FC275", "643d5b312e2e36325d2666683d3126663d3131303030")))
            {
                //Console.WriteLine($"{item}");
            }

            String[] fields = { "CATEGORIES",
"DTSTAMP",
"LAST-MODIFIED",
"UID",
"DTSTART",
"DTEND",
"SUMMARY;LANGUAGE=fr",
"LOCATION;LANGUAGE=fr",
"DESCRIPTION;LANGUAGE=fr",
"X-ALT-DESC;FMTTYPE=text/html",
"DTSTART;VALUE=DATE",
"DTEND;VALUE=DATE"};
            foreach (var field in fields)
            {
                String temp = "";
                foreach (var item in PlanningReader.GetAllValue(PlanningReader.GetIcalContent("Edt_Licence_3_Miashs_parcours_Miage.ics", "2021.0.1.3", "BE5E4C87C66B25F0E3DA315EA60FC275", "643d5b312e2e36325d2666683d3126663d3131303030"), field))
                {
                    Console.WriteLine($"{item}");
                    temp += item + "\n";
                }
                Directory.CreateDirectory("info");
                File.WriteAllText("info/" + field.Replace(";", "-").Replace("/", "-") + ".txt", temp);
            }

        }
    }
}
