using System.IO;
using DockerLib;
using Microsoft.EntityFrameworkCore;

namespace ClassLib.UnitTest
{
    public static class Fixture
    {
        public static void RunEfMigration(ContainerInfo containerInfo)
        {
            var crmDbContext = new CrmDbContext(containerInfo.Port);
            crmDbContext.Database.SetCommandTimeout(500);
            crmDbContext.Database.Migrate();
        }

        public static void RunSqlMigration(ContainerInfo containerInfo)
        {
            var workingDirectory = "/Users/oomusou/Code/CSharp/NUnitDockerCompose/ClassLib";
            var command = "dotnet ef migrations script";
            var sqlScript = DockerUtil.RunCommand(command, workingDirectory);

            var crmDbContext = new CrmDbContext(containerInfo.Port);
            crmDbContext.Database.SetCommandTimeout(300);
            crmDbContext.Database.ExecuteSqlCommand(sqlScript);
        }

        public static void RunSqlScriptMigration(ContainerInfo containerInfo)
        {
            var filePath = @"/Users/oomusou/Code/CSharp/NUnitDockerCompose/ClassLib/Migration.sql";
            var sqlScript = File.ReadAllText(filePath);
            
            var crmDbContext = new CrmDbContext(containerInfo.Port);
            crmDbContext.Database.SetCommandTimeout(300);
            crmDbContext.Database.ExecuteSqlCommand(sqlScript);
        }
    }
}