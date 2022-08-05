using Musical_Collection_Console_App.Classes.File_System_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Writer writer = new Writer();
            string text = ;
            writer.WriteJsonToFile(text);
            Console.ReadLine();
        }
    }
}
