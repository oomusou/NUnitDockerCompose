using System;
using System.Diagnostics;

namespace DockerLib
{
    public static class DockerHelper
    {
        public static string RandomPort
        {
            get
            {
                // Todo : 使 random port 從 0 開始，並且更加 unique
                const int minPort = 1000;
                const int maxPort = 9999;
                var random = new Random();
                return random.Next(minPort, maxPort).ToString();
            }
        }

        public static string RunCommand(string command)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{command}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }
    }
}