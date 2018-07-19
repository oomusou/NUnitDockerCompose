using System;
using System.Linq;
using ClassLib;
using DockerLib;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            void RunEachDockerTest(int i) => DockerTest(() => Console.WriteLine(i + " pass"));
            
            Enumerable.Range(0, 16).ToList()
                .ForEach(RunEachDockerTest);
        }

        private static void DockerTest(Action testing)
        {
            Dockery.Migration = RunMigration;
            var containerInfo = Dockery.DockerBeginTest();
            testing.Invoke();
            Dockery.DockerEndTest(containerInfo);
        }

        private static void RunMigration(ContainerInfo containerInfo)
        {
            var crmDbContext = new CrmDbContext(containerInfo.Port);
            crmDbContext.Database.SetCommandTimeout(300);
            crmDbContext.Database.Migrate();
        }
    }
}