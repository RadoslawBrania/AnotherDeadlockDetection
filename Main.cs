using ConsoleApp4;

List<Site> sites = [];

int AmmSites = 5;

Random random = new Random();

for(int i=0; i<AmmSites; i++)
{
    // sites get a random number of processes and resources from 2,8 , 
    // alternatively uncomment the other line and they will have param ammounts
    sites.Add(new Site());
//    sites.Append(new Site(Initiator.InitProcesses(5),Initiator.InitResources(5)));
}
Console.WriteLine(sites.Count);
Controller controller = new(sites);
int iters = 5;
for( int i=0;i<iters; i++)
{
    for (int j = 0; j < 1; j++)
    {
        foreach (var site in sites)
        {
            Process p = site.processes[random.Next(site.processes.Count())];
            foreach (var site2 in sites)
            {
                // We do not know which site holds the resource so we do not know who to ask to lock it down
                // could store the owner or could just check with every site like hey, do you have this resource I'd like to lock it down
                // either way works fine but i'd have to refactor the code 
                site2.LockResources(Initiator.GetRandomResourcesList(), p);
            }
        }
    }
    controller.EvaluateDeadlock();
}