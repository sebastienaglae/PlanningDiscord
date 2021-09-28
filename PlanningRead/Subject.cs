using System;

namespace PlanningRead
{
    public class Subject
    {
        private String categories;
        private DateTime lastMofified;
        private String uid;
        private DateTime dateStart;
        private DateTime dateEnd;
        private String summary;
        private String location;
        private String description;

        public void SetField(String field, String value)
        {
            if (field.Contains("CATEGORIES"))
            {
                SetCategories(value);
            }
            else if (field.Contains("LAST-MODIFIED"))
            {
                SetLastMofified(new DateTime(value, 2));
            }
            else if (field.Contains("UID"))
            {
                SetUid(value);
            }
            else if (field.Contains("DTSTART"))
            {
                SetDateStart(new DateTime(value, 2));
            }
            else if (field.Contains("DTEND"))
            {
                SetDateEnd(new DateTime(value, 2));
            }
            else if (field.Contains("SUMMARY"))
            {
                SetSummary(value);
            }
            else if (field.Contains("LOCATION"))
            {
                SetLocation(value);
            }
            else if (field.Contains("DESCRIPTION"))
            {
                SetDescription(value);
            }
        }

        public void SetCategories(String categories)
        {
            this.categories = categories;
        }

        public void SetLastMofified(DateTime lastMofified)
        {
            this.lastMofified = lastMofified;
        }

        public void SetUid(String uid)
        {
            this.uid = uid;
        }

        public void SetDateStart(DateTime dateStart)
        {
            this.dateStart = dateStart;
        }

        public void SetDateEnd(DateTime dateEnd)
        {
            this.dateEnd = dateEnd;
        }

        public void SetSummary(String summary)
        {
            this.summary = summary;
        }

        public void SetLocation(String location)
        {
            this.location = location;
        }

        public void SetDescription(String description)
        {
            this.description = description;
        }

        public String GetCategories()
        {
            return this.categories;
        }

        public DateTime GetLastMofified()
        {
            return this.lastMofified;
        }

        public String GetUid()
        {
            return this.uid;
        }

        public DateTime GetDateStart()
        {
            return this.dateStart;
        }

        public DateTime GetDateEnd()
        {
            return this.dateEnd;
        }

        public String GetSummary()
        {
            return this.summary;
        }

        public String GetLocation()
        {
            return this.location;
        }

        public String GetDescription()
        {
            return this.description;
        }
    }
}
