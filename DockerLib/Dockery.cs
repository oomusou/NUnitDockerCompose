using System;

namespace DockerLib
{
    public static class Dockery
    {
        public const string DatabaseName = "docker";
        public static Action<ContainerInfo> Migration;
        
        public static void DockerTest(Action testing)
        {
            var containerInfo = DockerHelper.CreateContainer();
            Migration.Invoke(containerInfo);
            testing.Invoke();
            DockerHelper.DestroyContainer(containerInfo);
        }
        
        public static void CleanDocker()
        {
            DockerHelper.PruneSystem();
            DockerHelper.CleanVolumn();
        } 
    }
}