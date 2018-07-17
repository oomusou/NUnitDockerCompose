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
                var containerInfo = Dockery.CreateContainer();
                RunMigration(containerInfo);
                Dockery.DestroyContainer(containerInfo);
                Console.WriteLine(i + " passed");
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