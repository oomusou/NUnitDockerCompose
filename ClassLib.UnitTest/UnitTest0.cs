using NUnit.Framework;
using static DockerLib.Dockery;

namespace ClassLib.UnitTest
{
    [SetUpFixture]
    public class UnitTest0
    {
        [OneTimeSetUp]
        public void GlobalSetup() => Migration = Fixture.RunEfMigration;
        
        [OneTimeTearDown]
        public void GlobalTearDown() => CleanContainer();
    }
}