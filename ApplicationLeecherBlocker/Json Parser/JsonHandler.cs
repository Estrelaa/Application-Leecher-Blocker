using ApplicationLeacherBlocker;
using ApplicationLeacherBlocker.ListOfItemsToBlock;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ApplicationLeecherBlocker.Json_Parser
{
    public class JsonHandler: IJsonHandler
    {
        public void CreateDefaultJsonFile()
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

        public ProcessesModel DeserializeJson()
        {
            ProcessesModel processesToBlock = new ProcessesModel();
            using (StreamReader file = File.OpenText("ApplicationToBlock.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                processesToBlock = (ProcessesModel)serializer.Deserialize(file, typeof(ProcessesModel));
                Logging.LogToLoggingTextBoxInUI($"Sucessfully loaded json file");
            }
            return processesToBlock;
        }

        public ProcessesModel LoadBlockList()
        {
            ProcessesModel processes = new ProcessesModel();
            try
            {
                processes = DeserializeJson();
            }
            catch(Exception ex)
            {
                Logging.LogToLoggingTextBoxInUI($"Failed to load Json: {ex.Message}, reseting file...");
                CreateDefaultJsonFile();
                processes = DeserializeJson();
            }
            return processes;
        }
    }
}
