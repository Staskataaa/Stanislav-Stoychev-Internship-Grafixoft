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
        public double Duration
        {
            get
            {
                TimeSpan totalTime = new TimeSpan();
                foreach (ISong song in Collection)
                {
                    totalTime += TimeSpan.FromMinutes(song.Duration);
                }
                double result = totalTime.Minutes * 60 + totalTime.Seconds;
                return result;
            }
        }
        public List<ISong> Collection { get; set; }

        //make geners total unique genres from every song
        public List<string> Genres { get; set; }
    }
}
