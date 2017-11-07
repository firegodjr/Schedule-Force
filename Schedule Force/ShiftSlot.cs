using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Force
{
    class ShiftSlot
    {
        bool isSunday;
        bool isFirstService;
        WorkerSlot[] workers;
        public bool IsFirstService
        {
            get { return isFirstService; }
        }

        public WorkerSlot[] Workers
        {
            get { return workers; }
        }

        public ShiftSlot(bool isSunday, bool isFirstService = true)
        {
            this.isSunday = isSunday;
            if (isSunday)
            {
                workers = new WorkerSlot[3];
            }
            else
            {
                workers = new WorkerSlot[2];
            }
        }

        public void RemoveWorker(Worker w)
        {
            for(int i = 0; i < workers.Length; ++i)
            {
                if (workers[i].Worker == w)
                {
                    workers[i].ClearWorker();
                }
            }
        }

        public void AddWorker(Worker w)
        {
            for(int i = 0; i < workers.Length; ++i)
            {
                if(workers[i].Worker == null)
                {
                    workers[i].SetWorker(w);
                }
            }
        }
    }
}
