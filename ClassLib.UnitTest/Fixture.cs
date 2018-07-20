using System.IO;
using DockerLib;
using Microsoft.EntityFrameworkCore;

namespace ClassLib.UnitTest
{
    public static class Fixture
    {
        public static void RunEfMigration(Container container)
        {
            var crmDbContext = new CrmDbContext(container.Port);
            crmDbContext.Database.SetCommandTimeout(500);
            crmDbContext.Database.Migrate();
        }

        public static void RunSqlScriptMigration(Container container)
        {
            var filePath = @"/Users/oomusou/Code/CSharp/NUnitDockerCompose/ClassLib/Migration.sql";
            var sqlScript = File.ReadAllText(filePath);
            
            var crmDbContext = new CrmDbContext(container.Port);
            crmDbContext.Database.SetCommandTimeout(500);
            crmDbContext.Database.ExecuteSqlCommand(sqlScript);
        }
    }
}