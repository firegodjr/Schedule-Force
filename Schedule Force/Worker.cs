using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * What days available
 * How many days they want
 * Whether or not those days are set in stone
 * First or second service
 * Infants or walkers
 * Some only work together
*/

namespace Schedule_Force
{
    class Worker
    {
        int dayCountLimit;
        bool doesFirstService, doesSecondService;
        bool doesInfants, doesWalkers;
        bool doesSundays, doesWednesdays;
        Worker linkedWorker;
        ExclusionMap exclusion;

        public int DayCountLimit { get => dayCountLimit; set => dayCountLimit = value; }
        public bool DoesFirstService { get => doesFirstService; set => doesFirstService = value; }
        public bool DoesSecondService { get => doesSecondService; set => doesSecondService = value; }
        public bool DoesInfants { get => doesInfants; set => doesInfants = value; }
        public bool DoesWalkers { get => doesWalkers; set => doesWalkers = value; }
        public bool DoesSundays { get => doesSundays; set => doesSundays = value; }
        public bool DoesWednesdays { get => doesWednesdays; set => doesWednesdays = value; }
        public ExclusionMap Exclusion { get => exclusion; set => exclusion = value; }

        /// <summary>
        /// Regenerates this worker's exclusion map to reflect the given month in a given year
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        public void GenerateExclusionMap(int month, int year)
        {
            exclusion = new ExclusionMap(month, year, this);
        }
    }
}
