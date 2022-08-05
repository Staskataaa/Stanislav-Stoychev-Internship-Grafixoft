using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Interfaces.File_System_Interfaces
{
    public interface IReader
    {
        string ReadLineFromConsole();
        string ReadLineFromFile();
    }
}
