using System.Collections.Generic;
using DockerLib;
using NUnit.Framework;

namespace ClassLib.UnitTest
{
    public class DockerTest
    {
        private readonly Dictionary<string, ContainerInfo> _containerInfos = new Dictionary<string, ContainerInfo>();
        private static string TestFullName => TestContext.CurrentContext.Test.FullName;

        [SetUp]
        public void Setup() => _containerInfos[TestFullName] = Dockery.DockerBeginTest();

        [TearDown]
        public void TearDown() => Dockery.DockerEndTest(_containerInfos[TestFullName]);
    }
}