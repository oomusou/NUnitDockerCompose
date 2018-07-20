using System.Collections.Generic;
using DockerLib;
using NUnit.Framework;
using static DockerLib.Dockery;

namespace ClassLib.UnitTest
{
    public class DockerTest
    {
        private readonly Dictionary<string, Container> _containerInfos = new Dictionary<string, Container>();
        private static string TestFullName => TestContext.CurrentContext.Test.FullName;

        [SetUp]
        public void Setup() => _containerInfos[TestFullName] = BeginTest();

        [TearDown]
        public void TearDown() => EndTest(_containerInfos[TestFullName]);
    }
}