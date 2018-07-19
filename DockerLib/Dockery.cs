using System;

namespace DockerLib
{
    public static class Dockery
    {
        public static Action<ContainerInfo> Migration;
        
        public static ContainerInfo DockerBeginTest()
        {
            var containerInfo = DockerHelper.CreateContainer();
            Migration.Invoke(containerInfo);

            return containerInfo;
        }

        public static void DockerEndTest(ContainerInfo containerInfo)
        {
            DockerHelper.DestroyContainer(containerInfo);
        }

        public static void CleanDocker()
        {
            DockerHelper.PruneSystem();
            DockerHelper.CleanVolumn();
        } 
    }
}