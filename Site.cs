using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Prng;

namespace ConsoleApp4
{
    internal class Site
    {
        // I'm assuming that every site has it's own processes and resources, but the nodes
        // can communicate and the processes can request resources from other sites. 
        public List<Process> processes;
        public List<Resource> resources;

        public Site()
        {
            Random random1 = new Random();
            processes = Initiator.InitProcesses(random1.Next(2, 3));
            resources = Initiator.InitResources(random1.Next(6, 20));
            Console.WriteLine($"Created a new site with {processes.Count} processes and {resources.Count} resources");
        }
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
                    if (r.LockedBy == null)
                    {
                        r.LockedBy = proc;
                        Console.WriteLine($"{proc} has locked down {r}");
                    }
                    else if(r.LockedBy!= proc)
                    {
                        proc.WaitingFor.Add(r);
                        Console.WriteLine($"{proc} awaits for {r}");
                    }
                }
            }
        }
        






    }
}
