using System.Collections.Generic;
using System.Diagnostics;

namespace ApplicationLeacherBlocker.ProcessesController
{
    class ProcessKiller
    {
        public List<string> KillProcesses(List<Process> ProcessesToKill)
        {
            var killedProcesses = new List<string>();
            foreach (var process in ProcessesToKill)
            {
                process.Kill(true);
                killedProcesses.Add(process.ProcessName);
            }
            return killedProcesses;
        }
    }
}
