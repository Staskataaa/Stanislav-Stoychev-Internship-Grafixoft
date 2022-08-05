using Musical_Collection_Console_App.Interfaces.File_System_Interfaces;
using Musical_Collection_Console_App.Utils.Exception_Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Classes.File_System_Classes
{
    public class Reader : IReader
    {
        
        public Reader()
        {
            
        }

        public string ReadLineFromConsole()
        {
            var result = "";
            if (!string.IsNullOrWhiteSpace(result))
            {
                result = Console.ReadLine();
            }
            else 
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidInput);
            }
            return result;
        }

        public string ReadLineFromFile()
        {
            throw new NotImplementedException();
        }
    }
}
