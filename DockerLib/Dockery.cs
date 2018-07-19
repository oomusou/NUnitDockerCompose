using System;
using System.Threading.Tasks;

namespace DockerLib
{
    public static class Dockery
    {
        public const string DatabaseName = "docker";
        private const string Username = "admin";
        private const string Password = "12345";
        private const int NewLineAscii = 10;
        private static string Healthy => "\"healthy\"" + Convert.ToChar(NewLineAscii);
        public static Action<ContainerInfo> Migration;

        public static void DockerTest(Action testing)
        {
            var containerInfo = CreateContainer();
            Migration.Invoke(containerInfo);
            testing.Invoke();
            DestroyContainer(containerInfo);
        }
        
        public static void CleanDocker()
        {
            PruneSystem();
            CleanVolumn();
        } 
       
        private static ContainerInfo CreateContainer()
        {
            var containerInfo = new ContainerInfo(DockerHelper.RandomPort);
            DockerComposeUp(containerInfo);
            WaitForPostgres(containerInfo);

            return containerInfo;
        }

        private static void DestroyContainer(ContainerInfo containerInfo)
        {
            DockerComposeDown(containerInfo);
        }

        private static void DockerComposeUp(ContainerInfo containerInfo)
        {
            var command =
                $"export POSTGRES_PORT={containerInfo.Port} && " +
                $"export POSTGRES_DB={DatabaseName} && " +
                $"export POSTGRES_USER={Username} && " +
                $"export POSTGRES_PASSWORD={Password} && " +
                $"docker-compose -p {containerInfo.ProjectName} up -d";

            DockerHelper.RunCommand(command);
        }

        private static void DockerComposeDown(ContainerInfo containerInfo)
        {
            var command =
                $"export POSTGRES_PORT={containerInfo.Port} && " +
                $"export POSTGRES_DB={DatabaseName} && " +
                $"export POSTGRES_USER={Username} && " +
                $"export POSTGRES_PASSWORD={Password} && " +
                $"docker-compose -p {DatabaseName + containerInfo.Port} down";

            DockerHelper.RunCommand(command);
        }

        private static void WaitForPostgres(ContainerInfo containerInfo)
        {
            var command = "docker inspect --format='{{json .State.Health.Status}}' " + $"{containerInfo.ContainerName}";

            while (true)
            {
                var output = DockerHelper.RunCommand(command);

                if (output.Equals(Healthy))
                {
                    break;
                }

                Task.Delay(1000).Wait();
            }

            Task.Delay(2000).Wait();
        }

        private static void PruneSystem()
        {
            var command = "docker system prune --force";
            DockerHelper.RunCommand(command);
        }

        private static void CleanVolumn()
        {
            var command = "docker volume rm $(docker volume ls |awk '{print $2}')";
            DockerHelper.RunCommand(command);
        }
    }
}