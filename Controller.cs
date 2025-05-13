using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Controller
    {
        List<Site> sites;

        public Controller(List<Site> s) {
        sites = s;
        }

        public void EvaluateDeadlock()
        {
            Array array;
            foreach (var site in sites)
            {
                foreach(var process in site.processes)
                {
                    // proces ma wfke -> do jednej tab
                    // resource ma locekd by -> do drugien
                    // overlap -> jeśli x blokuje y i czeka na z, a g blokuje z i czeka na y to dl
                }
            }
        }
    }
}
