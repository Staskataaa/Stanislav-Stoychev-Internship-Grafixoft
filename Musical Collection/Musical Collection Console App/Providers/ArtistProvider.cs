using Musical_Collection_Console_App.Classes;
using Musical_Collection_Console_App.Constants;
using Musical_Collection_Console_App.Utils.Exception_Messages;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Providers
{
    public class ArtistProvider : AlbumProvider
    {
        private EntityRepository<Artist> artistRepo;

        public ArtistProvider()
        {
            artistRepo = new EntityRepository<Artist>();
        }
        public Artist GetArtist(string name)
        {
            return artistRepo.FindTByName(name);   
        }

        public void AddSong(Song song, string artistName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            CreateSong(song);
            artist.SognsNames.Add(song.Name);
            artistRepo.Update(artist);
        }

        public void RemoveSong(string songName, string artistName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            artist.SognsNames.Remove(songName);
            RemoveSong(songName);
            artistRepo.Update(artist);
        }

        public void CreateAlbum(Album album, string artistName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            CreateAlbum(album);
            artist.AlbumsNames.Add(album.Name);
            artistRepo.Update(artist);
        }

        public void DeleteAlbum(string albumName, string artistName)
        {
            Artist artist = artistRepo.FindTByName(artistName);         
            LoginCheck(artist);
            artist.AlbumsNames.Remove(albumName);
            DeleteAlbum(albumName);
            artistRepo.Update(artist);
        }

        public void ArtistAddSongToAlbum(string artistName, string songName, string albumName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            AddSongToAlbum(songName, albumName);
        }

        public void RemoveSongFromAlbum(string artistName, string songName, string albumName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            RemoveSongFromAlbum(songName, albumName);
        }

        private void LoginCheck(Artist artist)
        {
            if (artist.IsActive == false)
            {
                throw new Exception(ExceptionMessages.EntityIsNotLoggedIn);
            }
        }

        public bool Login(string artistName, string password)
        {
            Artist artist = GetArtist(artistName);
            if (artist.IsActive == true)
            {
                throw new Exception(ExceptionMessages.InvalidLogin);
            }
            if (artist.Password != password)
            {
                throw new Exception(ExceptionMessages.InvalidPassword);
            }
            artist.IsActive = true;
            artistRepo.Update(artist);
            return true;
        }

        public bool Logout(string artistName)
        {
            Artist artist = GetArtist(artistName);
            LoginCheck(artist);
            artist.IsActive = false;
            artistRepo.Update(artist);
            return true;
        }
    }
}
