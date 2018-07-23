using System;
using System.Diagnostics;

namespace DockerLib
{
    public static class DockerUtil
    {
        private const int MinValue = 1000;
        private const int MaxValue = 9999;

        internal static string RandomPort => new Random().Next(MinValue, MaxValue).ToString();

        internal static string Run(string command)
        {
            string output;
            
            using (var process = new Process {StartInfo = GetStartInfo(command)})
            {
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }

            return output;
        }

        private static ProcessStartInfo GetStartInfo(string command)
        {
            return new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"-c \"{command}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }
    }
}