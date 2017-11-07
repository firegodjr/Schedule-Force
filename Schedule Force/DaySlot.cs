using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Sundays have 3 per room
 * Wednesdays have 2 per room
*/

namespace Schedule_Force
{
    class DaySlot
    {
        bool locked;
        bool isSunday;
        ShiftSlot[] shifts;

        public ShiftSlot FirstService
        {
            get => shifts[0];
        }

        public ShiftSlot SecondService
        {
            get => shifts.Length > 1 ? shifts[1] : null;
        }

        public ShiftSlot[] Services
        {
            get => shifts;
        }

        public bool IsSunday
        {
            get { return isSunday; }
        }

        public DaySlot(bool isSunday)
        {
            this.isSunday = isSunday;
            if(isSunday) //Sunday
            {
                shifts = new ShiftSlot[2];
                shifts[0] = new ShiftSlot(isSunday, true);
                shifts[1] = new ShiftSlot(isSunday, false);
            }
            else //Wednesday
            {
                shifts = new ShiftSlot[1];
                shifts[0] = new ShiftSlot(isSunday, true);
            }
        }

        /// <summary>
        /// Locks the slot so no changes can be made algorithmically
        /// </summary>
        public void Lock()
        {
            locked = true;
        }

        /// <summary>
        /// Unlocks the slot to allow algorithmic work
        /// </summary>
        public void Unlock()
        {
            locked = false;
        }
    }

    class DaySlotExclusion
    {
        bool allowFirstService;
        bool allowSecondService;

        public bool AllowFirstService { get => allowFirstService; set => allowFirstService = value; }
        public bool AllowSecondService { get => allowSecondService; set => allowSecondService = value; }

        public DaySlotExclusion(bool allowFirstService, bool allowSecondService)
        {
            this.allowFirstService = allowFirstService;
            this.allowSecondService = allowSecondService;
        }
    }
}
