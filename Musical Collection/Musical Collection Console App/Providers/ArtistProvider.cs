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
    public class ArtistProvider
    {
        private EntityRepository<Artist> artistRepo;
        private AlbumProvider albumProvider;
        private SongProvider songProvider;

        public ArtistProvider()
        {
            artistRepo = new EntityRepository<Artist>();
            songProvider = new SongProvider();
            albumProvider = new AlbumProvider();
        }

        public ArtistProvider(EntityRepository<Artist> newArtistRepo)
        {
            artistRepo = newArtistRepo;
        }

        public Artist GetArtist(string name)
        {
            return artistRepo.FindTByName(name);
        }

        public void ArtistAddSong(Song song, string artistName)
         {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            songProvider.CreateSong(song);
            artist.SognsNames.Add(song.Name);
            artistRepo.Update(artist);
        }

        public void ArtistRemoveSong(string songName, string artistName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            artist.SognsNames.Remove(songName);
            songProvider.RemoveSong(songName);
            artistRepo.Update(artist);
        }

        public void CreateAlbum(Album album, string artistName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            albumProvider.CreateAlbum(album);
            artist.AlbumsNames.Add(album.Name);
            artistRepo.Update(artist);
        }
        public void DeleteAlbum(string albumName, string artistName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            artist.AlbumsNames.Remove(albumName);
            albumProvider.DeleteAlbum(albumName);
            artistRepo.Update(artist);
        }

        public void ArtistAddSongToAlbum(string artistName, string songName, string albumName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            OwnershipCheck(artistName, songName);
            albumProvider.AddSongToAlbum(songName, albumName);
        }

        public void RemoveSongFromAlbum(string artistName, string songName, string albumName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            OwnershipCheck(artistName, songName);
            albumProvider.RemoveSongFromAlbum(songName, albumName);
        }

        private void LoginCheck(Artist artist)
        {
            if (artist.IsActive == false)
            {
                throw new Exception(ExceptionMessagesProvider.EntityIsNotLoggedIn);
            }
        }
        public bool Login(string artistName, string password)
        {
            Artist artist = GetArtist(artistName);
            if (artist.Password != password)
            {
                throw new Exception(ExceptionMessagesConstructorParams.InvalidPassword);
            }
            if (artist.IsActive == true)
            {
                throw new Exception(ExceptionMessagesProvider.InvalidLogin);
            }       
            artist.IsActive = true;
            artistRepo.Update(artist);
            return true;
        }

        public void Register(Artist artist)
        {
            artistRepo.Save(artist);
        }

        public bool Logout(string artistName)
        {
            Artist artist = GetArtist(artistName);
            LoginCheck(artist);
            artist.IsActive = false;
            artistRepo.Update(artist);
            return true;
        }

        private void OwnershipCheck(string authorName, string songName)
        {
            Song song = songProvider.getSong(songName);
            if (song.AuthorName != authorName)
            {
                throw new Exception(ExceptionMessagesProvider.NoOwnership);
            }
        }
    }
}
