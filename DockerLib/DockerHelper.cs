using System;
using System.Threading.Tasks;

namespace DockerLib
{
    public static class DockerHelper
    {
        private const string Username = "admin";
        private const string Password = "12345";
        private const int NewLineAscii = 10;
        private static string Healthy => "\"healthy\"" + Convert.ToChar(NewLineAscii);
        
        internal static ContainerInfo CreateContainer()
        {
            var containerInfo = new ContainerInfo(DockerUtil.RandomPort);
            DockerComposeUp(containerInfo);
            WaitForPostgres(containerInfo);

            return containerInfo;
        }

        internal static void DestroyContainer(ContainerInfo containerInfo)
        {
            DockerComposeDown(containerInfo);
        }
        
        internal static void PruneSystem()
        {
            var command = "docker system prune --force";
            DockerUtil.RunCommand(command);
        }

        internal static void CleanVolumn()
        {
            var command = "docker volume rm $(docker volume ls |awk '{print $2}')";
            DockerUtil.RunCommand(command);
        }

        private static void DockerComposeUp(ContainerInfo containerInfo)
        {
            var command =
                $"export POSTGRES_PORT={containerInfo.Port} && " +
                $"export POSTGRES_DB={Dockery.DatabaseName} && " +
                $"export POSTGRES_USER={Username} && " +
                $"export POSTGRES_PASSWORD={Password} && " +
                $"docker-compose -p {containerInfo.ProjectName} up -d";

            DockerUtil.RunCommand(command);
        }

        private static void DockerComposeDown(ContainerInfo containerInfo)
        {
            var command =
                $"export POSTGRES_PORT={containerInfo.Port} && " +
                $"export POSTGRES_DB={Dockery.DatabaseName} && " +
                $"export POSTGRES_USER={Username} && " +
                $"export POSTGRES_PASSWORD={Password} && " +
                $"docker-compose -p {Dockery.DatabaseName + containerInfo.Port} down";

            DockerUtil.RunCommand(command);
        }

        private static void WaitForPostgres(ContainerInfo containerInfo)
        {
            var command = "docker inspect --format='{{json .State.Health.Status}}' " + $"{containerInfo.ContainerName}";

            while (true)
            {
                var output = DockerUtil.RunCommand(command);

                if (output.Equals(Healthy))
                {
                    break;
                }

                Task.Delay(1000).Wait();
            }

            Task.Delay(2000).Wait();
        }
    }
}