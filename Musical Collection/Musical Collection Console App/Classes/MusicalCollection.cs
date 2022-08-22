using Musical_Collection_Console_App.Interfaces.Classes_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Classes
{
    public abstract class MusicalCollection : IMusicalCollection
    {
        private string _name;
        private IEnumerable<Song> _collection;
        private IEnumerable<string> _genres;

        public MusicalCollection(string name)
        {
            Name = name;
            Collection = new List<Song>();
        }

        public string Name { get; set; }

        public IEnumerable<Song> Collection { get; set; }

        public IEnumerable<string> Genres => Collection.Select(s => s.Genre).Distinct().ToList();

        public double Duration { get; set; }
    }
}
