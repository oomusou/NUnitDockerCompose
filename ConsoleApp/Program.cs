using System;
using ClassLib;
using DockerLib;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 16; i++)
            {
                Dockery.Migration = RunMigration;
                var containerInfo = Dockery.DockerBeginTest();
                Console.WriteLine(i + " passed");
                Dockery.DockerEndTest(containerInfo);
            }
        
        }

        private static void RunMigration(ContainerInfo containerInfo)
        {
            var crmDbContext = new CrmDbContext(containerInfo.Port);
            crmDbContext.Database.SetCommandTimeout(300);
            crmDbContext.Database.Migrate();
        }
    }
}