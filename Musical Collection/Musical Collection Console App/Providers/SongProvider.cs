using Musical_Collection_Console_App.Classes;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Providers
{
    public class SongProvider
    {
        private Repository<Song> songRepo;

        public SongProvider()
        {
            songRepo = new Repository<Song>();
        }
        public Song getSong(string name)
        {
            return songRepo.FindTByName(name);
        }
        public void AddSong(string name)
        {
            Song song = getSong(name);
            songRepo.Save(song);
        }
        public void RemoveSong(string name)
        {
            songRepo.Delete(name);
        }
    }
}
