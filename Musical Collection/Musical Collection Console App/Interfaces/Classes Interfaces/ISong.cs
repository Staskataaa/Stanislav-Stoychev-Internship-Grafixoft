using Musical_Collection_Console_App.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Interfaces.Classes_Interfaces
{
    public interface ISong : IEntity
    {
        string Genre { get; set; }
        double Duration { get; set; }
        string Author { get; set; }
        DateTime ReleaseDate { get; set; }
    }
}
