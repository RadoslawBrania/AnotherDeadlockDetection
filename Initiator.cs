using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    static internal class Initiator
    {
        //keeping that just to be able to lock down resources across sites for the simulation
        // accessing them otherwise would be a meanace.
        public static List<Resource> AllResources = [];
        
        public static List<Site> InitSites(List<Site> sites) {

            return sites;
        }

        public static List<Process> InitProcesses(int amm)
        {
            List<Process> processs = [];
            for (int i = 0; i < amm; i++) {
                processs.Add(new Process());
            }
            return processs;
        }

        public static List<Resource> InitResources(int amm)
        {
            List<Resource> values = new List<Resource>();
            for (int i = 0; i < amm; i++)
            {
                Resource resource = new Resource();
                values.Add(resource);
                AllResources.Add(resource);
            }
            return values;
        }
        public static List<Resource> GetRandomResourcesList()
        {
            Random random1 = new Random();
            HashSet<Resource> resources = [];
            for (int i = 0; i < random1.Next(2,4); i++)
            {
                resources.Add(Initiator.AllResources[random1.Next(Resource.GetAmm() - 1)]);
            }
            return resources.ToList();
        }
    }
}
