using ApplicationLeacherBlocker.ListOfItemsToBlock;
using ApplicationLeecherBlocker.Json_Parser;
using ApplicationLeecherBlocker.Processes;
using System.Collections.Generic;
using System.Diagnostics;

namespace ApplicationLeacherBlocker.Processes
{
    public class ProcessHandler : IProcessHandler
    {
        public void ScanAndKillBlockedProcesses(ProcessesModel ListOfBlockedProcesses)
        {
            KillBlockedProcesses(GetListOfBlockedProcessesThatAreRunning(ListOfBlockedProcesses.ProcessesToBeBlocked));
        }

        public List<Process> GetListOfBlockedProcessesThatAreRunning(List<string> ProcessesToBlock)
        {
            List<Process> RunningProcessesThatAreBlocked = new List<Process>();

            foreach (var process in ProcessesToBlock)
            {
                RunningProcessesThatAreBlocked.AddRange(Process.GetProcessesByName(process));
            }
            return RunningProcessesThatAreBlocked;
        }

        public void KillBlockedProcesses(List<Process> ProcessesToKill)
        {
            var killedProcesses = new List<string>();
            foreach (var process in ProcessesToKill)
            {
                process.Kill(true);
                killedProcesses.Add(process.ProcessName);
            }

            foreach (var process in killedProcesses)
            {
                Logging.LogToLoggingTextBoxInUI($"Found and killed process '{process}'");
            }
        }
    }
}
