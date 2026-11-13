using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUtilitySuite
{
    public class ProcessService
    {
        // TODO 2: Запустить внешнюю утилиту через Process и прочитать результат.
        public void RunCommand(string command, string arguments)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(processInfo);
            if (process != null)
            {
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                Console.WriteLine($"Результат выполнения '{command} {arguments}':\n{output}");
            }
        }
    }
}
