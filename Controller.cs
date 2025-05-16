using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Controller
    {
        List<Site> sites;
        // List<Row> matrix;
        Dictionary<Process, List<Process>> dict;
        public Controller(List<Site> s) {
        sites = s;
        dict = [];
        }
        
        public void PrintMatrix()
        {
            foreach (var site in dict)
            {
                string result = string.Join(", ", site.Value);
                Console.WriteLine($"{site.Key} awaits : {result}");
            }
        }
        public void EvaluateDeadlock()
        {
            foreach (var site in sites)
            {
                // I figured it could be done multiple ways depending on the exact goal,
                // first would be to modify the programm from 1st lab a bit and see if we can reach the node from itself
                // the 2nd one would be to build the wait for graph more extensively, meaning we iterate through every site, and every process
                // and for each of the processes we go deeper the waiting list, but adding each process only once. Then if we turn that into a matrix
                // it has this cool property where if [x][y] == [y][x] == 1 then we have a deadlock. Nonetheless while having a matrix with this property
                // would be very fun it seems like not the fastest approach
                // 3rd would be to just call the function from previous assignement
                // and lastly if we just want to check if there is a deadlock ( not all the deadlocks ) we could create a wait for hash set for every node and once
                // add returns 0 we know we have a deadlock
                foreach (var process in site.processes)
                {
                    //  Row row = new Row([], process);
                    HashSet<Process> list = [];
                    foreach (var resource in process.WaitingFor)
                    {
                    //    row.list.Add(resource.LockedBy);
                        list.Add(resource.LockedBy);
                    }
                    dict.Add(process, list.ToList());
                }
            }
            PrintMatrix();
            
            foreach (var listProc in dict)
            {
                CanReachP(listProc.Value, listProc.Key, []);
            }
            dict = [];
           
        }
        public bool CanReachP(List<Process> mainArr, Process p, HashSet<Process> canReach)
        {
            // Note: I'm only bothering to print the deadlocked nodes
            // I.E if we have a queue like  9-5-4-9 so we have a deadlock 
            // and then lets say 1 is waiting for 9 then I'm not bothering to print that 1 is deadlocked
            // since it's not the origin of the problem and then
            // every member of that queue would be marked as deadlocked which most of the time
            // would be simpl unreadable and provide us no useful information,
            // the 9-5-4-9 queue is the issue so these nodes will be caught as deadlocked
            // and this way every deadlock is still found just not multiple time by every member of the queue
            // this is an intentional feature, the reason why im passing the origin process p
            foreach (var process in mainArr)
            {
                if (process != null)
                {
                    if (process == p)
                    {
                        Console.WriteLine($"Deadlock detected, {p} ran into a loop");
                        return true;
                    }
                    if (canReach.Add(process))
                    {
                        if (dict.TryGetValue(process, out var list))
                        {
                            CanReachP(list, p, canReach);
                        }
                    }
                }
            }
            return false;
        }
    }
       
}
