using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRead
{
    public class PlanningReader
    {
        private static String cacheFolder = "cache";

        public static String GetIcalContent(String url)
        {
            if (!Directory.Exists(cacheFolder))
                Directory.CreateDirectory(cacheFolder);

            String icalPath = cacheFolder + "/" + "0.ical";

            using (var client = new WebClient())
            {
                client.DownloadFile(url, icalPath);
            }

            return File.ReadAllText(icalPath);
        }

        public static String GetAllFields(String ical)
        {
            String[] splitIcal = ical.Split("\n");
            String start = "BEGIN:VEVENT";
            String end = "END:VEVENT";

            String fields = "";
            bool exportData = false;
            for (int i = 0; i < splitIcal.Length; i++)
            {
                if (splitIcal[i].Contains(end))
                    exportData = false;
                if (exportData)
                {
                    String[] splitField = splitIcal[i].Split(":");
                    fields += splitField[0] + "\n";
                }
                if (splitIcal[i].Contains(start))
                    exportData = true;
            }

            return fields;
        }

        public static List<Subject> GetAllSubject(String ical)
        {
            List<Subject> subjects = new List<Subject>();
            String[] splitIcal = ical.Split("\n");
            String start = "BEGIN:VEVENT";
            String end = "END:VEVENT";

            bool exportData = false;
            Subject subject = null;
            for (int i = 0; i < splitIcal.Length; i++)
            {
                if (splitIcal[i].Contains(end))
                {
                    exportData = false;
                    subjects.Add(subject);
                }
                if (exportData)
                {
                    String[] splitField = splitIcal[i].Split(":");
                    subject.SetField(splitField[0], splitField[1]);
                }
                if (splitIcal[i].Contains(start))
                {
                    exportData = true;
                    subject = new Subject();
                }
            }

            return subjects;
        }
    }
}
