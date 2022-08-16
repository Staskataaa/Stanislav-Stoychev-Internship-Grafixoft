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
        private List<Song> _collection;
        private List<string> _genres;
        public MusicalCollection(string name)
        {
            Name = name;
            _collection = new List<Song>();
            _genres = new List<string>();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
       
        public List<Song> Collection 
        {
            get { return _collection; }
            set { _collection = value; }
        }
        public List<string> Genres 
        {
            get
            {
                _genres = Collection.Select(s => s.Genre).Distinct().ToList();
                return _genres;
            }
        }
        public double Duration
        {
            get
            {
                return Collection.Sum(s => s.Duration);
            }
        }
    }
}
