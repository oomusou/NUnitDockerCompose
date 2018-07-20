using DockerLib;
using NUnit.Framework;

namespace ClassLib.UnitTest
{
    [SetUpFixture]
    public class UnitTest0
    {
        [OneTimeSetUp]
        public void GlobalSetup() => Dockery.Migration = Fixture.RunEfMigration;
        
        [OneTimeTearDown]
        public void GlobalTearDown() => Dockery.CleanContainer();
    }
}