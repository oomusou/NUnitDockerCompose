using System;
using DockerLib;
using Microsoft.EntityFrameworkCore;

namespace ClassLib.UnitTest
{
    public static class Fixture
    {
        public static void DockerTest(Action testing)
        {
            var containerInfo = Dockery.CreateContainer();
            RunEfMigration(containerInfo);
            testing.Invoke();
            Dockery.DestroyContainer(containerInfo);
        }
        
        private static void RunEfMigration(ContainerInfo containerInfo)
        {
            var crmDbContext = new CrmDbContext(containerInfo.Port);
            crmDbContext.Database.SetCommandTimeout(300);
            crmDbContext.Database.Migrate();
        }
    }
}