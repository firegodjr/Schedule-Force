using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Force
{
    static class ScheduleMapper
    {
        public static MonthSchedule MapWorkersToShifts(Worker[] workers, MonthSchedule schedule)
        {
            // A record of if each worker is verified to be in a correct slot or not
            bool[] workerVerified = new bool[workers.Length];
            for(int wi = 0; wi < workers.Length; ++wi)
            {
                
            }

            return schedule;
        }

        private static void doPass(Worker[] workers, int depth, ref MonthSchedule schedule)
        {
            ExclusionMap currExclusion = workers[depth].Exclusion;
            ExclusionMap shiftsScheduled = new ExclusionMap(schedule.Month, schedule.Year, workers[depth]);
            
            if(workers[depth].DoesInfants)
            {
                //TODO: Do this for all available permutations

                for (int di = 0; di < schedule.InfantDays.Count; ++di)
                {
                    if(currExclusion.InfantDays[di].AllowFirstService)
                    {
                        schedule.InfantDays[di].FirstService.AddWorker(workers[depth]);
                        shiftsScheduled.InfantDays[di].AllowFirstService = true;
                    }
                    else if(currExclusion.InfantDays[di].AllowSecondService)
                    {
                        schedule.InfantDays[di].SecondService.AddWorker(workers[depth]);
                        shiftsScheduled.InfantDays[di].AllowSecondService = true;
                    }
                }
            }
            
            if(workers[depth].DoesWalkers)
            {
                for (int di = 0; di < schedule.WalkerDays.Count; ++di)
                {
                    if (currExclusion.WalkerDays[di].AllowFirstService)
                    {
                        if (currExclusion.WalkerDays[di].AllowFirstService)
                        {
                            schedule.WalkerDays[di].FirstService.AddWorker(workers[depth]);
                            shiftsScheduled.WalkerDays[di].AllowFirstService = true;
                        }
                        else if (currExclusion.WalkerDays[di].AllowSecondService)
                        {
                            schedule.WalkerDays[di].FirstService.AddWorker(workers[depth]);
                            shiftsScheduled.WalkerDays[di].AllowSecondService = true;
                        }
                    }
                }
            }

            //TODO: Recurse down with next worker

            //TODO: Reset changes to the schedule
        }
    }
}
