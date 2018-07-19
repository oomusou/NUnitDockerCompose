namespace DockerLib
{
    public class ContainerInfo
    {
        public readonly string Port;
        public string ProjectName => DockerHelper.DatabaseName + Port;
        public string ContainerName => DockerHelper.DatabaseName + Port + "_postgres_1";

        public ContainerInfo(string port) => Port = port;
    }
}