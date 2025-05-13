using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Resource
    {
        private static int nextId = 0;
        public int Id { get; }

        public Process LockedBy;
        public Resource() {

            Id = Interlocked.Increment(ref nextId);
        }
    }
}
