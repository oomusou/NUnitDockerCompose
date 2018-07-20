using System;
using System.Threading.Tasks;
using static DockerLib.DockerUtil;

namespace DockerLib
{
    public static class DockerHelper
    {
        public const string DatabaseName = "docker";
        private const string Username = "admin";
        private const string Password = "12345";
        private static string Healthy => "\"healthy\"" + Environment.NewLine;
        private static bool IsPostgresHealthy(string command) => Run(command).Equals(Healthy);
        private static void Sleep(int time) => Task.Delay(time).Wait();

        internal static Container CreateContainer()
        {
            return new Container(RandomPort)
                .DockerComposeUp()
                .WaitForPostgres();
        }

        internal static void DestroyContainer(Container container)
        {
            DockerComposeDown(container);
        }

        internal static void PruneSystem()
        {
            var command = "docker system prune --force --volumes";
            Run(command);
        }

        private static Container DockerComposeUp(this Container container)
        {
            var command =
                $"export POSTGRES_PORT={container.Port} && " +
                $"export POSTGRES_DB={DatabaseName} && " +
                $"export POSTGRES_USER={Username} && " +
                $"export POSTGRES_PASSWORD={Password} && " +
                $"docker-compose -p {container.ProjectName} up -d";

            Run(command);
            return container;
        }

        private static void DockerComposeDown(this Container container)
        {
            var command =
                $"export POSTGRES_PORT={container.Port} && " +
                $"export POSTGRES_DB={DatabaseName} && " +
                $"export POSTGRES_USER={Username} && " +
                $"export POSTGRES_PASSWORD={Password} && " +
                $"docker-compose -p {DatabaseName + container.Port} down";

            Run(command);
        }

        private static Container WaitForPostgres(this Container container)
        {
            var command = 
                "docker inspect --format='{{json .State.Health.Status}}' " + 
                container.ContainerName;

            while (true)
            {
                if (IsPostgresHealthy(command)) break;

                Sleep(1000);
            }
            
            Sleep(3000);
            return container;
        }
    }
}