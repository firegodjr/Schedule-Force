using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Force
{
    class WorkerSlot
    {
        Worker worker;
        WorkerSlot linkedSlot;
        bool linked;

        public Worker Worker
        {
            get => worker;
        }

        public WorkerSlot() { }

        public WorkerSlot(Worker worker)
        {
            this.worker = worker;
        }

        public WorkerSlot(Worker worker, WorkerSlot linkedSlot)
        {
            this.worker = worker;
            this.linkedSlot = linkedSlot;
        }

        public void LinkSlot(WorkerSlot slot)
        {
            linkedSlot = slot;
            linked = true;
        }

        public void SetWorker(Worker w)
        {
            if(linked)
            {
                linkedSlot.ClearWorker(true);
                Unlink();
            }

            worker = w;
        }

        /// <summary>
        /// Clears the worker from this slot
        /// </summary>
        /// <param name="ignoreLinked">Whether or not this method ignores any linked slots while clearing</param>
        public void ClearWorker(bool ignoreLinked = false)
        {
            if(!ignoreLinked && linked)
            {
                linkedSlot.ClearWorker(true);
                Unlink();
            }

            worker = null;
        }

        /// <summary>
        /// Unlinks this slot from its joined slot and updates the joined slot accordingly
        /// </summary>
        public void Unlink()
        {
            linked = false;

            if (linkedSlot.linked == true)
            {
                linkedSlot.Unlink();
            }

            linkedSlot = null;
        }
    }
}
