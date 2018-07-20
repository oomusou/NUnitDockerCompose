using static DockerLib.DockerHelper;

namespace DockerLib
{
    public class Container
    {
        public readonly string Port;
        public string ProjectName => DatabaseName + Port;
        public string ContainerName => ProjectName + "_postgres_1";

        public Container(string port) => Port = port;
    }
}