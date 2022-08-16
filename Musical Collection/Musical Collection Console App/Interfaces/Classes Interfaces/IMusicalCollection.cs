using Musical_Collection_Console_App.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Interfaces.Classes_Interfaces
{
    public interface IMusicalCollection : IEntity
    {
        double Duration { get; }  
        List<Song> Collection { get; set; }
        List<string> Genres { get; }
    }
}
