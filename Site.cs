using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Site
    {
        public List<Process> processes;
        public List<Resource> resources;
        public Site(List<Process> proc, List<Resource> resc)
        {
            processes= proc;
            resources= resc;
        }

        // A process from a dfferent site can ask to lock resources for it
        public void LockResources(List<Resource> list, Process proc)
        {
            foreach (Resource r in resources)
            {
                if (list.Contains(r))
                {
                    if (r.LockedBy!=null)
                    {
                        r.LockedBy = proc;
                    }
                    else
                    {
                        proc.WaitingFor.Add(r);
                    }
                }
            }
        }
        






    }
}
