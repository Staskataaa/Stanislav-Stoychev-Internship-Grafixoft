using Musical_Collection_Console_App.Interfaces.Classes_Interfaces;
using Musical_Collection_Console_App.Utils.Exception_Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Classes
{
    public class Song : ISong

    {
        private string _name;
        private string _genre;
        private string _authorName;
        private double _duration;
        private string _releaseDate;

        public Song(string name, string genre, string author, double duration, string releaseDate)
        {
            Name = name;
            Genre = genre;
            AuthorName = author;
            Duration = duration;
            ReleaseDate = releaseDate;
        }

        public string Genre { get; set; }
        public string AuthorName { get; set; }
        public double Duration { 
            get
            {
                return _duration;
            }
            set
            {
                double secondsDuration = value - Math.Round(value);
                if (secondsDuration > 0.6)
                {
                    throw new Exception(ExceptionMessages.InvalidSongDuration);
                }
                _duration = value;
            }
        }
        public string ReleaseDate {
            get 
            {
                return _releaseDate;
            }
            set
            {
                string[] array = value.Split('.').ToArray();
                if (array.Length <= 0 || array.Length > 3)
                {
                    throw new Exception(ExceptionMessages.InvalidReleaseDate);
                }
                _releaseDate = value;
            }
        }
        public string Name { get; set; }
    }
}
