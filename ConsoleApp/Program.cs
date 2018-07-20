using System;
using System.Linq;
using ClassLib;
using DockerLib;
using static DockerLib.Dockery;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    internal static class Program
    {
        private static void Main()
        {
            void RunEachDockerTest(int i) 
                => DockerTest(() => Console.WriteLine(i + " pass"));

            Enumerable.Range(0, 16).ForEach(RunEachDockerTest);
        }

        private static void DockerTest(Action testing)
        {
            Migration = RunMigration;
            var containerInfo = BeginTest();
            testing();
            EndTest(containerInfo);
        }

        private static void RunMigration(Container container)
        {
            var crmDbContext = new CrmDbContext(container.Port);
            crmDbContext.Database.SetCommandTimeout(300);
            crmDbContext.Database.Migrate();
        }
    }
}