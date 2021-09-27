using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRead
{
    public class DateTime
    {
        private int day;
        private int month;
        private int year;
        private int hour;
        private int minute;
        private int second;

        public DateTime(String datetime, int utc)
        {
            //20210926T220237Z
            this.day = Int32.Parse(datetime.Substring(6, 2));
            this.month = Int32.Parse(datetime.Substring(4, 2));
            this.year = Int32.Parse(datetime.Substring(0, 4));

            if (datetime.Length <= 9)
            {
                this.second = 0;
                this.minute = 0;
                this.hour = 0;
            }
            else
            {
                this.second = Int32.Parse(datetime.Substring(13, 2));
                this.minute = Int32.Parse(datetime.Substring(11, 2));
                this.hour = Int32.Parse(datetime.Substring(9, 2)) + utc;
            }
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

        public override String ToString()
        {
            return "<" + day + "/" + month + "/" + year + " - " + hour + ":" + minute + ":" + second + ">";
        }
    }
}
