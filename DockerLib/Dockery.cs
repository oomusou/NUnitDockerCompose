using System;
using static DockerLib.DockerHelper;

namespace DockerLib
{
    public static class Dockery
    {
        public static Action<Container> Migration;
        public static Container BeginTest() => CreateContainer().RunMigration();
        public static void EndTest(Container container) => DestroyContainer(container);
        public static void CleanContainer() => PruneSystem();

        private static Container RunMigration(this Container container)
        {
            Migration(container);
            return container;
        }
    }
}