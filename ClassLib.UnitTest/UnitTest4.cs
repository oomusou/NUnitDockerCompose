using System;
using static DockerLib.Dockery;
using NUnit.Framework;

namespace ClassLib.UnitTest
{
    public class UnitTest4
    {
        [Test]
        public void Test1()
        {
            Action action = () =>
            {
                // Your test here
                Assert.AreEqual(true, true);
            };

            DockerTest(action);
        }

        [Test]
        public void Test2()
        {
            Action action = () =>
            {
                // Your test here
                Assert.AreEqual(true, true);
            };

            DockerTest(action);
        }

        [Test]
        public void Test3()
        {
            Action action = () =>
            {
                // Your test here
                Assert.AreEqual(true, true);
            };

            DockerTest(action);
        }

        [Test]
        public void Test4()
        {
            Action action = () =>
            {
                // Your test here
                Assert.AreEqual(true, true);
            };

            DockerTest(action);
        }
    }
}