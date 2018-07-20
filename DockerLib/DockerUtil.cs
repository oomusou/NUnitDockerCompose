using System;
using System.Diagnostics;

namespace DockerLib
{
    public static class DockerUtil
    {
        private const int MinValue = 1000;
        private const int MaxValue = 9999;

        internal static string RandomPort => new Random().Next(MinValue, MaxValue).ToString();

        internal static string Run(string command, string directory = ".")
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