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
//            RunEfMigration(containerInfo);
            RunSqlMigration(containerInfo);
            testing.Invoke();
            Dockery.DestroyContainer(containerInfo);
        }
        
        private static void RunEfMigration(ContainerInfo containerInfo)
        {
            var crmDbContext = new CrmDbContext(containerInfo.Port);
            crmDbContext.Database.SetCommandTimeout(500);
            crmDbContext.Database.Migrate();
        }
        
        private static void RunSqlMigration(ContainerInfo containerInfo)
        {
//            var currentDirectory = Directory.GetCurrentDirectory();
//            var parentDirectory = Directory.GetParent(currentDirectory);
//            var workingDirectory = parentDirectory + "/ClassLib";
            var workingDirectory = "/Users/oomusou/Code/CSharp/NUnitDockerCompose/ClassLib";
            var command = "dotnet ef migrations script";
            var sqlScript = DockerHelper.RunCommand(command, workingDirectory);

            var crmDbContext = new CrmDbContext(containerInfo.Port);
            crmDbContext.Database.SetCommandTimeout(300);
            crmDbContext.Database.ExecuteSqlCommand(sqlScript);
        }
    }
}