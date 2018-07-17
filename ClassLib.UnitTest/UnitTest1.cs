using NUnit.Framework;

namespace ClassLib.UnitTest
{
    public class UnitTest1
    {
        [Test]
        public void Test1()
        {
            Fixture.DockerTest(() => Assert.AreEqual(true, true));
        }
    }
}