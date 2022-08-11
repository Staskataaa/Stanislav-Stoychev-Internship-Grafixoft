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
        private List<ISong> _favouriteSongs;
        private List<IPlaylist> _playlists;

        public Listener(string name, string password, string fullName, string birthDate) : base(name, password, fullName, birthDate)
        {
            
        }

        public List<string> FavouriteGenres 
        {
            get { return _favouriteGenres; }
            set { _favouriteGenres = value; }
        }
        public List<ISong> FavouriteSongs 
        {
            get { return _favouriteSongs; }
            set { _favouriteSongs = value; }
        }
        public List<IPlaylist> Playlists 
        {
            get { return _playlists; }
            set { _playlists = value; }
        }
    }
}
