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
        private IEnumerable<string> _songsNames;
        private IEnumerable<string> _albumNames;

        public Artist(string username, string password, string fullName, DateTime birthDate)
            : base(username, password, fullName, birthDate)
        {
            SognsNames = new List<string>();
            AlbumsNames = new List<string>();
        }

        public IEnumerable<string> AlbumsNames { get; set; }

        public IEnumerable<string> SognsNames { get; set; }
    }
}
