using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace PlanningRead
{
    public class PlanningReader
    {
        private static readonly String cacheFolder = "cache";
        private List<Subject> subjects;

        public PlanningReader(String edtIcs, String version, String idCal, String param)
        {
            GetAllSubject(GetIcalContent(edtIcs, version, idCal, param));
        }

        public static String GetIcalContent(String edtIcs, String version, String idCal, String param)
        {
            if (!Directory.Exists(cacheFolder))
                Directory.CreateDirectory(cacheFolder);

            String icalPath = cacheFolder + "/" + "0.ical";
            String url = File.ReadAllText("hyperplanningUrl.var") + edtIcs + "?version=" + version + "&idICal=" + idCal + "&param=" + param;

            using (var client = new WebClient())
            {
                client.DownloadFile(url, icalPath);
            }

            return File.ReadAllText(icalPath);
        }

        public static List<String> GetAllFields(String ical)
        {
            String[] splitIcal = ical.Split("\n");
            String start = "BEGIN:VEVENT";
            String end = "END:VEVENT";

            bool exportData = false;
            List<String> fields = new();
            for (int i = 0; i < splitIcal.Length; i++)
            {
                if (splitIcal[i].Contains(end))
                {
                    exportData = false;
                }
                if (exportData)
                {
                    String[] splitField = splitIcal[i].Split(":");
                        if (!fields.Contains(splitField[0]))
                            fields.Add(splitField[0]);
                }
                if (splitIcal[i].Contains(start))
                {
                    exportData = true;
                }
            }

            return fields;
        }

        public static List<String> GetAllValue(String ical, String fields)
        {
            String[] splitIcal = ical.Split("\n");
            String start = "BEGIN:VEVENT";
            String end = "END:VEVENT";

            bool exportData = false;
            List<String> values = new();
            for (int i = 0; i < splitIcal.Length; i++)
            {
                if (splitIcal[i].Contains(end))
                {
                    exportData = false;
                }
                if (exportData)
                {
                    String[] splitField = splitIcal[i].Split(":");
                    if (splitField[0].Trim().Equals(fields))
                    {
                        if (splitField.Length > 2)
                        {
                            String temp = "";
                            for (int j = 1; j < splitField.Length; j++)
                            {
                                temp += splitField[j];
                            }
                            if (!values.Contains(temp))
                                values.Add(temp);
                        }
                        else
                        {
                            if (!values.Contains(splitField[1]))
                                values.Add(splitField[1]);
                        }
                    }
                }
                if (splitIcal[i].Contains(start))
                {
                    exportData = true;
                }
            }

            return values;
        }

        private void GetAllSubject(String ical)
        {
            List<Subject> subjects = new();
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

            this.subjects = subjects;
        }

        public List<Subject> GetByDate(DateTime dateTime)
        {
            List<Subject> subjectDate = new();

            foreach (var subject in subjects)
            {
                if (subject.GetDateStart().SameDate(dateTime))
                    subjectDate.Add(subject);
            }

            return subjectDate;
        }
    }
}
