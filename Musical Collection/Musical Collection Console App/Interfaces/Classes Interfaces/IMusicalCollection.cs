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

        IEnumerable<Song> Collection { get; set; }

        IEnumerable<string> Genres { get; }
    }
}
