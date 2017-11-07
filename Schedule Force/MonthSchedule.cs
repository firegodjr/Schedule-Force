using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Force
{
    class MonthSchedule
    {
        List<DaySlot> infantDays = new List<DaySlot>(),
                           toddlerDays = new List<DaySlot>();

        int month, year;

        public int Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }
        public List<DaySlot> InfantDays { get => infantDays; set => infantDays = value; }
        public List<DaySlot> WalkerDays { get => toddlerDays; set => toddlerDays = value; }

        public MonthSchedule(int month) : this(month, DateTime.Now.Year) { }

        public MonthSchedule(int month, int year)
        {
            this.month = month;
            this.year = year;

            for (int day = 1; day < DateTime.DaysInMonth(year, month) + 1; ++day)
            {
                DateTime today = new DateTime(year, month, day);
                switch(today.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        infantDays.Add(new DaySlot(true));
                        toddlerDays.Add(new DaySlot(true));
                        break;
                    case DayOfWeek.Wednesday:
                        infantDays.Add(new DaySlot(false));
                        toddlerDays.Add(new DaySlot(false));
                        break;
                }
            }
        }
    }

    /// <summary>
    /// An abstract schedule containing information on which days, exactly, can be worked by a given worker
    /// </summary>
    class ExclusionMap
    {
        List<DaySlotExclusion> infantDays = new List<DaySlotExclusion>(),
                               toddlerDays = new List<DaySlotExclusion>();

        public List<DaySlotExclusion> InfantDays { get => infantDays; set => infantDays = value; }
        public List<DaySlotExclusion> WalkerDays { get => toddlerDays; set => toddlerDays = value; }

        /// <summary>
        /// Creates a new "empty" exclusion map with all day options set to false.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        public ExclusionMap(int month, int year)
        {
            for (int day = 1; day < DateTime.DaysInMonth(year, month) + 1; ++day)
            {
                DateTime today = new DateTime(year, month, day);
                switch (today.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                    case DayOfWeek.Wednesday:
                        infantDays.Add(new DaySlotExclusion(false, false));
                        toddlerDays.Add(new DaySlotExclusion(false, false));
                        break;
                }
            }
        }

        /// <summary>
        /// Creates a new exclusion map with default day options set based on the worker's preferences.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="worker"></param>
        public ExclusionMap(int month, int year, Worker worker)
        {
            for (int day = 1; day < DateTime.DaysInMonth(year, month) + 1; ++day)
            {
                DateTime today = new DateTime(year, month, day);
                switch (today.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        bool firstService = worker.DoesSundays && worker.DoesFirstService;
                        bool secondService = worker.DoesSundays && worker.DoesSecondService;
                        infantDays.Add(new DaySlotExclusion(firstService, secondService));
                        toddlerDays.Add(new DaySlotExclusion(firstService, secondService));
                        break;
                    case DayOfWeek.Wednesday:
                        bool wed = worker.DoesWednesdays;
                        infantDays.Add(new DaySlotExclusion(wed, wed));
                        toddlerDays.Add(new DaySlotExclusion(wed, wed));
                        break;
                }
            }
        }
    }
}
