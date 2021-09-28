using System;

namespace PlanningRead
{
    public class DateTime
    {
        private readonly int day;
        private readonly int month;
        private readonly int year;
        private readonly int hour;
        private readonly int minute;
        private readonly int second;

        public DateTime()
        {
            System.DateTime dateTimeNow = System.DateTime.Now;
            this.day = dateTimeNow.Day;
            this.month = dateTimeNow.Month;
            this.year = dateTimeNow.Year;

            this.second = 0;
            this.minute = 0;
            this.hour = 0;
        }

        public DateTime(int day, int month, int year)
        {
            System.DateTime dateTimeNow = System.DateTime.Now;
            this.day = day;
            this.month = month;
            this.year = year;

            this.second = 0;
            this.minute = 0;
            this.hour = 0;
        }

        public DateTime(String datetime, int utc)
        {
            this.day = int.Parse(datetime.Substring(6, 2));
            this.month = int.Parse(datetime.Substring(4, 2));
            this.year = int.Parse(datetime.Substring(0, 4));

            if (datetime.Length <= 9)
            {
                this.second = 0;
                this.minute = 0;
                this.hour = 0;
            }
            else
            {
                this.second = int.Parse(datetime.Substring(13, 2));
                this.minute = int.Parse(datetime.Substring(11, 2));
                this.hour = int.Parse(datetime.Substring(9, 2)) + utc;
            }
        }

        public int TimeBetween(DateTime dateTime)
        {
            return Math.Abs((dateTime.GetHour() * 60 + dateTime.GetMinute()) - (hour * 60 + minute));
        }

        public bool SameDate(DateTime dateTime)
        {
            return SameDate(dateTime.GetDay(), dateTime.GetMonth(), dateTime.GetYear());
        }

        public bool SameDate(int day, int month, int year)
        {
            return this.day == day && this.month == month && this.year == year;
        }

        public bool SameTime(int hour, int minute, int second)
        {
            return this.hour == hour && this.minute == minute && this.second == second;
        }

        public bool SameDateTime(int day, int month, int year, int hour, int minute, int second)
        {
            return SameDate(day, month, year) && SameTime(hour, minute, second);
        }

        public int GetDay()
        {
            return day;
        }

        public int GetMonth()
        {
            return month;
        }

        public int GetYear()
        {
            return year;
        }

        public int GetHour()
        {
            return hour;
        }

        public int GetMinute()
        {
            return minute;
        }

        public int GetSecond()
        {
            return second;
        }

        public String MonthToString()
        {
            return month switch
            {
                1 => "Janvier",
                2 => "Fevrier",
                3 => "Mars",
                4 => "Avril",
                5 => "Mai",
                6 => "Juin",
                7 => "Juillet",
                8 => "Aout",
                9 => "Septembre",
                10 => "Octobre",
                11 => "Novembre",
                12 => "Decembre",
                _ => "<inconnu>",
            };
        }

        public string DayToString()
        {
            System.DateTime dateTime = new(year, month, day);
            return dateTime.DayOfWeek switch
            {
                DayOfWeek.Sunday => "Dimanche",
                DayOfWeek.Monday => "Lundi",
                DayOfWeek.Tuesday => "Mardi",
                DayOfWeek.Wednesday => "Mercredi",
                DayOfWeek.Thursday => "Jeudi",
                DayOfWeek.Friday => "Vendredi",
                DayOfWeek.Saturday => "Samedi",
                _ => "<inconnu>",
            };
        }

        public String HourMinuteToString()
        {
            return hour + ":" + minute;
        }

        public String DateToString()
        {
            return hour + ":" + minute;
        }

        public override String ToString()
        {
            return "<" + day + "/" + month + "/" + year + " - " + hour + ":" + minute + ":" + second + ">";
        }
    }
}
