using System;
using System.Linq;
using ClassLib;
using DockerLib;
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
            Dockery.Migration = RunMigration;
            var containerInfo = Dockery.BeginTest();
            testing();
            Dockery.EndTest(containerInfo);
        }

        private static void RunMigration(this Container container)
        {
            var crmDbContext = new CrmDbContext(container.Port);
            crmDbContext.Database.SetCommandTimeout(300);
            crmDbContext.Database.Migrate();
        }
    }
}