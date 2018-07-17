using DockerLib;
using NUnit.Framework;

namespace ClassLib.UnitTest
{
    [SetUpFixture]
    public class UnitTest0
    {
        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            Dockery.CleanDocker(); 
        }
    }
}