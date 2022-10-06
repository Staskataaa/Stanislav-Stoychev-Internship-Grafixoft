using Musical_Collection_Console_App.Classes;
using Musical_Collection_Console_App.Interfaces.Classes_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Interfaces
{
    public interface IAlbum : IEntity
    {
        IEnumerable<string> Authors { get; set; }
    }
}
