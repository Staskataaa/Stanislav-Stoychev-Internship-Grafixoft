using Musical_Collection_Console_App.Interfaces.File_System_Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Musical_Collection_Console_App.Classes.File_System_Classes
{
    internal class Writer : IWriter
    {
        public Writer()
        {
            
        }

        public void WriteLineToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteJsonToFile(object objToBeAdded)
        {
            string objectType = objToBeAdded.GetType().Name;
            string path = $@"D:\Git\Internship_working\Musical Collection\Musical Collection Console App\JSONFileSystem\{objectType}.json";
            string json = File.ReadAllText(path);
            var objectList = JsonConvert.DeserializeObject<List<object>>(json);
            objectList.Add(objToBeAdded);
            objectList.Distinct().ToList();
            var newJson = JsonConvert.SerializeObject(objToBeAdded);
            File.WriteAllText(path, newJson);
        }
    }
}
