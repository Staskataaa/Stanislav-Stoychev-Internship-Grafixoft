﻿using Musical_Collection_Console_App.Classes;
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

        /// <summary>
        /// Default ArtistProvider constructor
        /// </summary>
        public ArtistProvider()
        {
            artistRepo = new EntityRepository<Artist>();
            songProvider = new SongProvider();
            albumProvider = new AlbumProvider();
        }
        
        /// <summary>
        /// Constructor specifically used by the unit test. Its main purpose 
        /// is that its parameters are mocked repositories
        /// </summary>
        /// <param name="newArtistRepo"></param>
        public ArtistProvider(EntityRepository<Artist> newArtistRepo)
        {
            artistRepo = newArtistRepo;
        }

        /// <summary>
        /// Gets the artist from the respective JSON 
        /// file based on the provided album name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Artist GetArtist(string name)
        {
            return artistRepo.FindTByName(name);
        }

        /// <summary>
        /// adds song to the respective JSON file and creates dependency with the Artist.
        /// </summary>
        /// <param name="song"></param>
        /// <param name="artistName"></param>
        public void ArtistAddSong(Song song, string artistName)
         {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            songProvider.CreateSong(song);
            artist.SognsNames.ToList().Add(song.Name);
            artistRepo.Update(artist);
        }

        /// <summary>
        /// removes song from the respective JSON file and removes dependency with the Artist.
        /// </summary>
        /// <param name="songName"></param>
        /// <param name="artistName"></param>
        public void ArtistRemoveSong(string songName, string artistName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            artist.SognsNames.ToList().Remove(songName);
            songProvider.RemoveSong(songName);
            artistRepo.Update(artist);
        }

        /// <summary>
        /// creates album to the respective JSON file and creates dependency with the Artist.
        /// </summary>
        /// <param name="album"></param>
        /// <param name="artistName"></param>
        public void CreateAlbum(Album album, string artistName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            albumProvider.CreateAlbum(album);
            artist.AlbumsNames.ToList().Add(album.Name);
            artistRepo.Update(artist);
        }

        /// <summary>
        /// deletes album to the respective JSON file and removes dependency with the Artist.
        /// </summary>
        /// <param name="albumName"></param>
        /// <param name="artistName"></param>
        public void DeleteAlbum(string albumName, string artistName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            artist.AlbumsNames.ToList().Remove(albumName);
            albumProvider.DeleteAlbum(albumName);
            artistRepo.Update(artist);
        }

        /// <summary>
        /// finds the song and album based on the provided names and the 
        /// artist and creates dependency between song and album 
        /// </summary>
        /// <param name="artistName"></param>
        /// <param name="songName"></param>
        /// <param name="albumName"></param>
        public void ArtistAddSongToAlbum(string artistName, string songName, string albumName)
        {
            Artist artist = artistRepo.FindTByName(artistName);
            LoginCheck(artist);
            OwnershipCheck(artistName, songName);
            albumProvider.AddSongToAlbum(songName, albumName);
        }

        /// <summary>
        /// removes the song from the album based on the provided names and the 
        /// artist and removes the dependency between song and album 
        /// </summary>
        /// <param name="artistName"></param>
        /// <param name="songName"></param>
        /// <param name="albumName"></param>
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
                throw new ArgumentException(ExceptionMessagesProvider.EntityIsNotLoggedIn);
            }
        }

        /// <summary>
        /// Login the artist based on the provided name and password
        /// </summary>
        /// <param name="artistName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool Login(string artistName, string password)
        {
            Artist artist = GetArtist(artistName);
            if (artist.Password != password)
            {
                throw new ArgumentException(ExceptionMessagesConstructorParams.InvalidPassword);
            }
            if (artist.IsActive == true)
            {
                throw new ArgumentException(ExceptionMessagesProvider.InvalidLogin);
            }       
            artist.IsActive = true;
            artistRepo.Update(artist);
            return true;
        }

        /// <summary>
        /// Registers the artist based on the provided Artist object
        /// </summary>
        /// <param name="artist"></param>
        public void Register(Artist artist)
        {
            artistRepo.Save(artist);
        }


        /// <summary>
        /// Logs out the artist if he is alreadyu logged in
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns></returns>
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
            if (song.Author != authorName)
            {
                throw new ArgumentException(ExceptionMessagesProvider.NoOwnership);
            }
        }
    }
}