using ApplicationLeacherBlocker;
using ApplicationLeacherBlocker.ListOfItemsToBlock;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApplicationLeecherBlocker.Json_Parser
{
    public class Json_Serializer
    {
        public void SerializeJson()
        {
            ProcessesModel ApplicationToBlock = new ProcessesModel
            {
                ProcessesToBeBlocked = new ProcessesToBlock().Processes
            };
            
            using (StreamWriter file = File.CreateText("ApplicationToBlock.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, ApplicationToBlock);
                Logging.LogToLoggingTextBoxInUI($"Sucessfully copied default list to json file");
            }
        }
        
    }
}
