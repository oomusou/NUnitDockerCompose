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
                Action action = () => Console.WriteLine(i + " passed");
                Dockery.DockerTest(action);
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