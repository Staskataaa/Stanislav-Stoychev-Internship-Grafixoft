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
        private Repository<Artist> artistRepo;
        private Repository<Song> songRepo;
        private Repository<Album> albumRepo;

        //maybe update all used Repos when executing Deletes
        // change entity structure - list<type> to list of string so it only holds reference
        public ArtistProvider()
        {
            artistRepo = new Repository<Artist>();
            songRepo = new Repository<Song>();
            albumRepo = new Repository<Album>();
        }
        public Artist GetArtist(string name)
        {
            return artistRepo.FindTByName(name);   
        }

        public void AddSong(Song song, string artistName)
        {
            songRepo.Save(song);
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            artist.Sogns.Add(song);
            artistRepo.Update(artist);
        }

        public void RemoveSong(string songName, string artistName)
        {
            Song song = songRepo.FindTByName(songName);
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            artist.Sogns.Remove(song);
            artistRepo.Update(artist);
        }

        public void CreateAlbum(Album album, string artistName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            artist.Albums.Add(album);
            artistRepo.Update(artist);
        }

        public void DeleteAlbum(string albumName, string artistName)
        {
            Album album = albumRepo.FindTByName(albumName);
            Artist artist = artistRepo.FindTByName(artistName);
            artist.Albums.Remove(album);
            artistRepo.Update(artist);
        }

        public void AddSongToAlbum(string artistName, string songName, string albumName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            Album album = albumRepo.FindTByName(albumName);          
            Song song = songRepo.FindTByName(songName);
            //very clunky
            Album newAlbum = album;
            newAlbum.Collection.Add(song);
            artist.Albums.Remove(album);
            artist.Albums.Add(newAlbum);
            albumRepo.Update(album);
            artistRepo.Update(artist);
        }

        public void RemoveSongFromAlbum(string artistName, string songName, string albumName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            Album album = albumRepo.FindTByName(albumName);
            Song song = songRepo.FindTByName(songName);
            //very clunky
            Album newAlbum = album;
            if (newAlbum.Collection.Contains(song))
            {
                newAlbum.Collection.Remove(song);
            }
            else
            {
                throw new Exception(ExceptionMessages.EntityDoesNotExist);
            }
            artist.Albums.Remove(album);
            artist.Albums.Add(newAlbum);
            albumRepo.Update(album);
            artistRepo.Update(artist);
        }

        private void LoginCheck(Artist artist)
        {
            if (artist.IsActive == false)
            {
                throw new Exception(ExceptionMessages.EntityIsNotLoggedIn);
            }

        }
    }
}
