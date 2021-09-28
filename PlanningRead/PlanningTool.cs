using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRead
{
    public class PlanningTool
    {
        public static int WorkingTime(List<Subject> subjects)
        {
            int minuteWork = 0;
            foreach (var subject in subjects)
            {
                minuteWork += subject.GetDateStart().TimeBetween(subject.GetDateEnd());
            }

            return minuteWork;
        }

        public static int FreeTime(List<Subject> subjects)
        {
            if (subjects.Count - 1 < 2)
                return 0;

            int minuteFree = 0;
            for (int i = 0; i < subjects.Count - 1; i++)
            {
                minuteFree += subjects[i].GetDateEnd().TimeBetween(subjects[i + 1].GetDateStart());
            }

            return minuteFree;
        }
    }
}
