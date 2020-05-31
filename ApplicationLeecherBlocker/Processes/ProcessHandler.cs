using ApplicationLeacherBlocker.ProcessesController;
using System.Collections.Generic;
using System.Diagnostics;

namespace ApplicationLeacherBlocker.Processes
{
    class ProcessHandler
    {
        public void DealWithProcesses()
        {
            ProcessScaner scaner = new ProcessScaner();
            var ProcessesToBlock = ListOfItemsToBlock.ProcessesToBlock.Processes;

            KillProcesses(scaner.FindBlockedProcesses(ProcessesToBlock));
        }

        public void KillProcesses(List<Process> ProcessesToKill)
        {
            ProcessKiller killer = new ProcessKiller();
            var killedProcesses = killer.KillProcesses(ProcessesToKill);

            foreach (var process in killedProcesses)
            {
                Logging.LogToLoggingTextBoxInUI($"Found and killed process '{process}'");
            }
        }
    }
}
