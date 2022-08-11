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
        private List<IArtist> artists;
        public Album(string name, List<ISong> collection, List<string> genres) : base(name, collection, genres)
        {
            Name = name;
        }
        public List<IArtist> Authors { get; set; }
    }
}
