using Musical_Collection_Console_App.Classes;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Providers
{
    public class AlbumProvider : SongProvider
    {
        private EntityRepository<Album> albumRepo;

        public AlbumProvider()
        {
            albumRepo = new EntityRepository<Album>();
        }
        public Album getAlbum(string name)
        {
            return albumRepo.FindTByName(name);   
        }
        public void CreateAlbum(Album album)
        {
            albumRepo.Save(album);
        }
        public void DeleteAlbum(string name)
        {
            albumRepo.Delete(name);
        }
        public void AddSongToAlbum(string songName, string albumName)
        {
            Song song = getSong(songName);
            Album album = albumRepo.FindTByName(albumName);
            album.Collection.Add(song);
            albumRepo.Update(album);
        }
        public void RemoveSongFromAlbum(string songName, string albumName)
        {
            Song song = getSong(songName);
            Album album = albumRepo.FindTByName(albumName);
            album.Collection.Remove(song);
            albumRepo.Update(album);
        }

    }
}
