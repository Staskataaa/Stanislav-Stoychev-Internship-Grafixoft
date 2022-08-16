using Musical_Collection_Console_App.Interfaces;
using Musical_Collection_Console_App.Interfaces.Classes_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Classes
{
    public class Album : MusicalCollection, IAlbum
    {
        private List<string> _authorsNames;
        public Album(string name) : base(name)
        {
            Name = name;
            _authorsNames = new List<string>();
        }
        public List<string> AuthorsNames 
        {
            get { return _authorsNames; }
            set { _authorsNames = value; }
        }
    }
}
