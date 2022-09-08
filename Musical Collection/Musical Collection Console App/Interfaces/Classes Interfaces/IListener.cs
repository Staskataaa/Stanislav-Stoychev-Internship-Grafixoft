using Musical_Collection_Console_App.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Interfaces.Classes_Interfaces
{
    public interface IListener : IEntity
    {
        IEnumerable<string> FavouriteGenres { get; set; }

        IEnumerable<string> FavouriteSongs { get; set; }

        IEnumerable<string> PlaylistsNames { get; set; }
    }
}
