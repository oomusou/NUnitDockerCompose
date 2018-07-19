using System;
using static DockerLib.Dockery;
using NUnit.Framework;

namespace ClassLib.UnitTest
{
    public class UnitTest2
    {
        [Test]
        public void Test1()
        {
            Action action = () =>
            {
                // Arrange
                
                // Act 
                
                // Assert
                Assert.AreEqual(true, true);
            };

            DockerTest(action);
        }

        [Test]
        public void Test2()
        {
            Action action = () =>
            {
                // Arrange
                
                // Act 
                
                // Assert
                Assert.AreEqual(true, true);
            };

            DockerTest(action);
        }

        [Test]
        public void Test3()
        {
            Action action = () =>
            {
                // Arrange
                
                // Act 
                
                // Assert
                Assert.AreEqual(true, true);
            };

            DockerTest(action);
        }

        [Test]
        public void Test4()
        {
            Action action = () =>
            {
                // Arrange
                
                // Act 
                
                // Assert
                Assert.AreEqual(true, true);
            };

            DockerTest(action);
        }
    }
}