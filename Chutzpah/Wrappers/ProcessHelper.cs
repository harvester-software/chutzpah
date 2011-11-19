﻿using System.Diagnostics;
using Chutzpah.Models;

namespace Chutzpah.Wrappers
{
    public class ProcessHelper : IProcessHelper
    {
        public ProcessResult RunExecutableAndCaptureOutput(string exePath, string arguments)
        {
            var p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = exePath;
            p.StartInfo.Arguments = arguments;
            p.Start();
            var output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return new ProcessResult(p.ExitCode, output);
        }

        public void LaunchFileInBrowser(string file)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.Verb = "Open";
            startInfo.FileName = file;
            Process.Start(startInfo);
        }
    }
}