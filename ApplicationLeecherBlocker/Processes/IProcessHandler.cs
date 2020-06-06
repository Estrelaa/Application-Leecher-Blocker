using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ApplicationLeecherBlocker.Processes
{
    interface IProcessHandler
    {
        void ScanAndKillBlockedProcesses();
        List<string> GetListOfBlockedProcesses();
        List<Process> GetBlockedProcessesThatAreRunning(List<string> ProcessesToBlock);
        void KillBlockedProcesses(List<Process> ProcessesToKill);
    }
}
