using Musical_Collection_Console_App.Interfaces.Classes_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Classes
{
    public class Playlist : MusicalCollection, IPlaylist 
    {
        private string creator;

        public Playlist(string name, List<ISong> collection) : base(name, collection)
        {

        }
        public IUser Creator { get; set; }
    }
}
