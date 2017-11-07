using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Force
{
    class MonthSchedule
    {
        List<ScheduleSlot> infantDays = new List<ScheduleSlot>(),
                           toddlerDays = new List<ScheduleSlot>();

        public MonthSchedule(int month) : this(month, DateTime.Now.Year) { }

        public MonthSchedule(int month, int year)
        {
            for (int day = 1; day < DateTime.DaysInMonth(year, month) + 1; ++day)
            {
                DateTime today = new DateTime(year, month, day);
                switch(today.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        infantDays.Add(new ScheduleSlot(true));
                        toddlerDays.Add(new ScheduleSlot(true));
                        break;
                    case DayOfWeek.Wednesday:
                        infantDays.Add(new ScheduleSlot(false));
                        toddlerDays.Add(new ScheduleSlot(false));
                        break;
                }
            }
        }
    }
}
