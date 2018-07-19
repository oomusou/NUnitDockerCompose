using static DockerLib.Dockery;
using NUnit.Framework;

namespace ClassLib.UnitTest
{
    [SetUpFixture]
    public class UnitTest0
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Migration = Fixture.RunEfMigration;
        }
        
        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            CleanDocker(); 
        }
    }
}