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
        private EntityRepository<Song> songRepo;

        /// <summary>
        /// default constructor
        /// </summary>
        public SongProvider()
        {
            songRepo = new EntityRepository<Song>();
        }


        /// <summary>
        /// Constructor specifically used by the unit test. Its main purpose 
        /// is that its parameters are mocked repositories
        /// </summary>
        /// <param name="entityRepository">repository that will be mocked in the unit test. Serves as repo for songs</param>
        public SongProvider(EntityRepository<Song> entityRepository)
        {
            songRepo = entityRepository;
        }

        /// <summary>
        /// finds the song based on its name in the respective JSON file
        /// </summary>
        /// <param name="name">name of the song</param>
        /// <returns></returns>
        public Song getSong(string name)
        {
            return songRepo.FindByName(name);
        }

        /// <summary>
        /// creates the song base on the provided Song object from its respective JSON file
        /// </summary>
        /// <param name="song">song object</param>
        public void CreateSong(Song song)
        {
            songRepo.SaveEntity(song);
        }

        /// <summary>
        /// finds and removes the song from the respective JSON file based on the name
        /// </summary>
        /// <param name="name">name of the song</param>
        public void RemoveSong(string name)
        {
            songRepo.Delete(name);
        }
    }
}
