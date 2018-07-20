using System;
using System.Diagnostics;

namespace DockerLib
{
    public static class DockerUtil
    {
        public static string RandomPort
        {
            get
            {
                const int minPort = 1000;
                const int maxPort = 9999;
                var random = new Random();
                return random.Next(minPort, maxPort).ToString();
            }
        }

        public static string Run(string command, string directory = ".")
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{command}\"",
                    RedirectStandardOutput = true,
                    WorkingDirectory = directory,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }
    }
}