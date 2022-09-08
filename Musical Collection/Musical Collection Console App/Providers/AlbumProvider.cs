using Musical_Collection_Console_App.Classes;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Providers
{
    /// <summary>
    /// The purpose of the class is to provide a object that has structure like Album 
    /// and perform operaations with it
    /// </summary>
    public class AlbumProvider
    {
        private EntityRepository<Song> _songRepo;
        private EntityRepository<Album> _albumRepo;


        /// <summary>
        /// Default AlbumProvider constructor
        /// </summary>
        public AlbumProvider()
        {
            _albumRepo = new EntityRepository<Album>();
            _songRepo = new EntityRepository<Song>();
        }

        /// <summary>
        /// Constructor specifically used by the unit test. Its main purpose 
        /// is that its parameters are mocked repositories
        /// </summary>
        /// <param name="newAlbumRepo">repository that will be mocked for albums</param>
        /// <param name="newSongRepo">repository that will be mocked for songs</param>
        public AlbumProvider(EntityRepository<Album> newAlbumRepo, EntityRepository<Song> newSongRepo)
        {
            _albumRepo = newAlbumRepo;
            _songRepo = newSongRepo;
        }

        /// <summary>
        /// Gets the album by its name from the respective JSON file
        /// </summary>
        /// <param name="name">name of the album</param>
        /// <returns></returns>
        public Album GetAlbum(string name)
        {
            return _albumRepo.FindByName(name);
        }

        /// <summary>
        /// creates the album based on the provided album 
        /// constructor and save it to the respective JSON file
        /// </summary>
        /// <param name="album">album object</param>
        public void CreateAlbum(Album album)
        {
            _albumRepo.SaveEntity(album);
        }

        /// <summary>
        /// deletes the ablum base on the provided album 
        /// name and deletes it from the respective JSON file
        /// </summary>
        /// <param name="name">name of the album</param>
        public void DeleteAlbum(string name)
        {
            _albumRepo.Delete(name);
        }

        /// <summary>
        /// adds song based on the provided song name then adds it to the 
        /// album based on the provided name and updates the respective JSON files
        /// </summary>
        /// <param name="songName">name of the song</param>
        /// <param name="albumName">name of the album</param>
        public virtual void AddSongToAlbum(string songName, string albumName)
        {
            Song song = _songRepo.FindByName(songName);
            Album album = _albumRepo.FindByName(albumName);
            album.Collection.ToList().Add(song);
            _albumRepo.Update(album);
        }

        /// <summary>
        /// removes song based on the provided song name from album 
        /// and updates the respective JSON files
        /// </summary>
        /// <param name="songName">name of the song</param>
        /// <param name="albumName">name of the album</param>
        public void RemoveSongFromAlbum(string songName, string albumName)
        {
            Song song = _songRepo.FindByName(songName);
            Album album = _albumRepo.FindByName(albumName);
            album.Collection.ToList().Remove(song);
            _albumRepo.Update(album);
        }
    }
}
