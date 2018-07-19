namespace DockerLib
{
    public class ContainerInfo
    {
        public readonly string Port;
        public string ProjectName => Dockery.DatabaseName + Port;
        public string ContainerName => Dockery.DatabaseName + Port + "_postgres_1";

        public ContainerInfo(string port) => Port = port;
    }
}