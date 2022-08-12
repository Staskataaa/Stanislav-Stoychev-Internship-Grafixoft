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
        private double _duration;
        private List<ISong> _collection;
        private List<string> _genres;
        public MusicalCollection(string name, List<ISong> collection)
        {
            Name = name;
            Collection = collection;
        }

        public string Name { get; set; }
       
        public List<ISong> Collection { get; set; }
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
