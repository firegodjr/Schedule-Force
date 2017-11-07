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
    class ScheduleSlot
    {
        bool locked;
        bool isSunday;
        Worker[] workers;

        public bool IsSunday
        {
            get { return isSunday; }
        }

        public Worker[] Workers
        {
            get { return workers; }
        }

        public ScheduleSlot(bool isSunday)
        {

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
}
