using NUnit.Framework;

namespace ClassLib.UnitTest
{
    public class UnitTest4
    {
        [Test]
        public void Test1()
        {
            Fixture.DockerTest(() => Assert.AreEqual(true, true));
        }

        [Test]
        public void Test2()
        {
            Fixture.DockerTest(() => Assert.AreEqual(true, true));
        }

        [Test]
        public void Test3()
        {
            Fixture.DockerTest(() => Assert.AreEqual(true, true));
        }

        [Test]
        public void Test4()
        {
            Fixture.DockerTest(() => Assert.AreEqual(true, true));
        }
    }
}