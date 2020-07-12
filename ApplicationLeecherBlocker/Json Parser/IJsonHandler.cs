using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLeecherBlocker.Json_Parser
{
    interface IJsonHandler
    {
        public void CreateDefaultJsonFile();
        public ProcessesModel DeserializeJson();
        public ProcessesModel LoadBlockList();
    }
}
