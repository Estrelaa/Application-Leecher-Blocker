using System.Collections.Generic;
using System.Diagnostics;

namespace ApplicationLeacherBlocker.ProcessesController
{
    class ProcessScaner
    {
        public List<Process> FindBlockedProcesses(List<string> ProcessesToBlock)
        {
            List<Process> RunningProcessesThatAreBlocked = new List<Process>();

            foreach (var process in ProcessesToBlock)
            {
                RunningProcessesThatAreBlocked.AddRange(Process.GetProcessesByName(process));
            }
            return RunningProcessesThatAreBlocked;
        }
    }
}
