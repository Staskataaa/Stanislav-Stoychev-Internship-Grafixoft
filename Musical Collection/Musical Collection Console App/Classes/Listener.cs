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
        private List<string> _favouriteGenres;
        private List<string> _favouriteSongsNames;
        private List<string> _playlistsNames;

        public Listener(string name, string password, string fullName, string birthDate) : base(name, password, fullName, birthDate)
        {
            
        }

        public List<string> FavouriteGenres 
        {
            get { return _favouriteGenres; }
            set { _favouriteGenres = value; }
        }
        public List<string> FavouriteSongsNames 
        {
            get { return _favouriteSongsNames; }
            set { _favouriteSongsNames = value; }
        }
        public List<string> PlaylistsNames
        {
            get { return _playlistsNames; }
            set { _playlistsNames = value; }
        }
    }
}
