using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Process
    {
        private static int nextId = 0;
        public int Id { get; }

        public HashSet<Resource> WaitingFor;
        public Process() {

            Id = Interlocked.Increment(ref nextId);
        }
        public void ReleaseResources()
        {
            // technically should iterate all resources to find where this process 
            // also could add resources the process its using, since we know which wer're releasing
            // overall I don't think this is a part of the assignement so i will not handle
            // releasing the resources although leaving this for possible further expansion
            foreach (var resource in WaitingFor)
            {

            }
        }
    }
}
