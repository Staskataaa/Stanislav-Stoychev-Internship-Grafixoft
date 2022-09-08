using Musical_Collection_Console_App.Interfaces.Classes_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Classes
{
    public class Listener : User, IListener
    {
        private IEnumerable<string> _favouriteGenres;
        private IEnumerable<string> _favouriteSongs;
        private IEnumerable<string> _playlistsNames;

        public Listener(string name, string password, string fullName, DateTime birthDate)
            : base(name, password, fullName, birthDate)
        {
            FavouriteGenres = new List<string>();
            FavouriteSongs = new List<string>();
            PlaylistsNames = new List<string>();
        }

        public IEnumerable<string> FavouriteGenres { get; set; }

        public IEnumerable<string> FavouriteSongs { get; set; }

        public IEnumerable<string> PlaylistsNames { get; set; }
    }
}
