using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Row
    {

        public List<Process> list;
        public Process origin;
        public Row(List<Process> matrix, Process origin)
        {
            this.list = matrix;
            this.origin = origin;
        }
    }
}
