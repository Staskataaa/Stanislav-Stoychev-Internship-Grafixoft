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
        private DateTime _releaseDate;

        public Song(string name, string genre, string author, double duration, DateTime releaseDate)
        {
            Name = name;
            Genre = genre;
            Author = author;
            Duration = duration;
            ReleaseDate = releaseDate;
        }

        public string Genre { get; set; }

        public string Author { get; set; }

        public double Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                double secondsDuration = value - Math.Round(value);

                if (secondsDuration > 0.6)
                {
                    throw new ArgumentException(ExceptionMessagesConstructorParams.InvalidSongDuration);
                }

                _duration = value;
            }
        }

        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = DateTime.Parse(value.ToString());
            }
        }

        public string Name { get; set; }
    }
}
