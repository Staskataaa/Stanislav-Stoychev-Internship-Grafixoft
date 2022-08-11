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
        private IArtist _author;
        private double _duration;
        private string _releaseDate;

        public Song(string name, string genre, IArtist author, double duration, string releaseDate)
        {
            Name = name;
            Genre = genre;
            Author = author;
            Duration = duration;
            ReleaseDate = releaseDate;
        }

        public string Genre { get; set; }
        public IArtist Author { get; set; }
        public double Duration { get; set; }
        public string ReleaseDate { get; set; }
        public string Name { get; set; }
    }
}
