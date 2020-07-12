using ApplicationLeecherBlocker.Json_Parser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ApplicationLeecherBlocker.Processes
{
    interface IProcessHandler
    {
        void ScanAndKillBlockedProcesses(ProcessesModel ListOfBlockedProcesses);
        List<Process> GetListOfBlockedProcessesThatAreRunning(List<string> ProcessesToBlock);
        void KillBlockedProcesses(List<Process> ProcessesToKill);
    }
}
