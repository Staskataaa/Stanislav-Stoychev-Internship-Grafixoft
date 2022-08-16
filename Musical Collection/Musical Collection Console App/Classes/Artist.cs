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

        private List<string> _songsNames;
        private List<string> _albumNames;

        public Artist(string username, string password, string fullName, string birthDate) : base(username, password, fullName, birthDate)
        {
            _songsNames = new List<string>();
            _albumNames = new List<string>();
        }

        public List<string> AlbumsNames 
        {
            get { return _albumNames; }
            set { _albumNames = value; }
        }
        public List<string> SognsNames 
        {
            get { return _songsNames; }
            set { _songsNames = value; }
        }
    }
}
