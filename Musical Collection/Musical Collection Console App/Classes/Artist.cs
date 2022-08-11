using Musical_Collection_Console_App.Interfaces;
using Musical_Collection_Console_App.Interfaces.Classes_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Classes
{
    public class Artist : User, IArtist
    {

        private List<ISong> _songs;
        private List<IAlbum> _albums;

        public Artist(string username, string password, string fullName, string birthDate) : base(username, password, fullName, birthDate)
        {
            
        }

        public List<IAlbum> Albums { get; set; }
        public List<ISong> Sogns { get; set; }
        public List<string> Genres { get; set; }
    }
}
