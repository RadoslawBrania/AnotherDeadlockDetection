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
            WaitingFor = [];
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
        //public void LockResources(List<Resource> list, Process proc)
        //{
        //    //   foreach (Resource r in resources)
        //    //     {
        //    foreach (Resource r in list)
        //    {
        //        L
        //    }
        //    // }
        //}
        public static int GetAmm() { return  nextId; }
        public override string ToString()
        {
            return $"Process: {Id}";
        }
    }
}
