using Musical_Collection_Console_App.Classes;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Providers
{
    public class AlbumProvider 
    {
        private EntityRepository<Song> songRepo;
        private EntityRepository<Album> albumRepo;


        /// <summary>
        /// Default AlbumProvider constructor
        /// </summary>
        public AlbumProvider()
        {
            albumRepo = new EntityRepository<Album>();
            songRepo = new EntityRepository<Song>();
        }

        /// <summary>
        /// Constructor specifically used by the unit test. Its main purpose 
        /// is that its parameters are mocked repositories
        /// </summary>
        /// <param name="newAlbumRepo"></param>
        /// <param name="newSongRepo"></param>
        public AlbumProvider(EntityRepository<Album> newAlbumRepo, EntityRepository<Song> newSongRepo)
        {
            albumRepo = newAlbumRepo;
            songRepo = newSongRepo;
        }

        /// <summary>
        /// Gets the album by its name from the respective JSON file
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Album getAlbum(string name)
        {
            return albumRepo.FindTByName(name);   
        }

        /// <summary>
        /// creates the album based on the provided album 
        /// constructor and save it to the respective JSON file
        /// </summary>
        /// <param name="album"></param>
        public void CreateAlbum(Album album)
        {
            albumRepo.Save(album);
        }

        /// <summary>
        /// deletes the ablum base on the provided album 
        /// name and deletes it from the respective JSON file
        /// </summary>
        /// <param name="name"></param>
        public void DeleteAlbum(string name)
        {
            albumRepo.Delete(name);
        }

        /// <summary>
        /// adds song based on the provided song name then adds it to the 
        /// album based on the provided name and updates the respective JSON files
        /// </summary>
        /// <param name="songName"></param>
        /// <param name="albumName"></param>
        public void AddSongToAlbum(string songName, string albumName)
        {
            Song song = songRepo.FindTByName(songName);
            Album album = albumRepo.FindTByName(albumName);
            album.Collection.ToList().Add(song);
            albumRepo.Update(album);
        }

        /// <summary>
        /// removes song based on the provided song name from album 
        /// and updates the respective JSON files
        /// </summary>
        /// <param name="songName"></param>
        /// <param name="albumName"></param>
        public void RemoveSongFromAlbum(string songName, string albumName)
        {
            Song song =songRepo.FindTByName(songName);
            Album album = albumRepo.FindTByName(albumName);
            album.Collection.ToList().Remove(song);
            albumRepo.Update(album);
        }

    }
}
