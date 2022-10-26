using Musical_Collection_Console_App.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Interfaces.Classes_Interfaces
{
    public interface IArtist : IEntity
    {
        IEnumerable<string> AlbumsNames { get; set; }
        IEnumerable<string> SognsNames { get; set; }
    }
}

