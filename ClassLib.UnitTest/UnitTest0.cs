using System.IO;
using DockerLib;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ClassLib.UnitTest
{
    [SetUpFixture]
    public class UnitTest0
    {
        [OneTimeSetUp]
        public void GlobalSetup() => Dockery.Migration = RunEfMigration;
        
        [OneTimeTearDown]
        public void GlobalTearDown() => Dockery.CleanContainer();
        
        public static void RunEfMigration(Container container)
        {
            var crmDbContext = new CrmDbContext(container.Port);
            crmDbContext.Database.SetCommandTimeout(500);
            crmDbContext.Database.Migrate();
        }
        
        public static void RunSqlMigration(Container container)
        {
            var filePath = @"/Users/oomusou/Code/CSharp/NUnitDockerCompose/ClassLib/Migration.sql";
            var sqlScript = File.ReadAllText(filePath);
            
            var crmDbContext = new CrmDbContext(container.Port);
            crmDbContext.Database.SetCommandTimeout(500);
            crmDbContext.Database.ExecuteSqlCommand(sqlScript);
        }
    }
}