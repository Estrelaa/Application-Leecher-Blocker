using ApplicationLeecherBlocker.Json_Parser;
using System.Collections.Generic;
using System.Diagnostics;

namespace ApplicationLeecherBlocker.Processes
{
    interface IProcessHandler
    {
        void ScanAndKillBlockedProcesses(ProcessesModel ListOfBlockedProcesses);
        List<Process> GetListOfBlockedProcessesThatAreRunning(List<string> ProcessesToBlock);
        void KillBlockedProcesses(List<Process> ProcessesToKill);
    }
}
