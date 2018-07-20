using System.Collections.Generic;
using DockerLib;
using NUnit.Framework;

namespace ClassLib.UnitTest
{
    public class DockerTest
    {
        private readonly Dictionary<string, Container> _containerInfos = new Dictionary<string, Container>();
        private static string TestFullName => TestContext.CurrentContext.Test.FullName;

        [SetUp]
        public void Setup() => _containerInfos[TestFullName] = Dockery.BeginTest();

        [TearDown]
        public void TearDown() => Dockery.EndTest(_containerInfos[TestFullName]);
    }
}