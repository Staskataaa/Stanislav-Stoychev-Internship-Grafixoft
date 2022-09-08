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
    public class ArtistProvider : UserAuthenticationProvider
    {

        private EntityRepository<Artist> _artistRepo;
        private AlbumProvider _albumProvider;
        private SongProvider _songProvider;

        /// <summary>
        /// Default ArtistProvider constructor
        /// </summary>
        public ArtistProvider()
        {
            _artistRepo = new EntityRepository<Artist>();
            _songProvider = new SongProvider();
            _albumProvider = new AlbumProvider();
        }

        /// <summary>
        /// Constructor specifically used by the unit test. Its main purpose 
        /// is that its parameters are mocked repositories
        /// </summary>
        /// <param name="newArtistRepo"></param>
        public ArtistProvider(EntityRepository<Artist> newArtistRepo)
        {
            _artistRepo = newArtistRepo;
        }

        /// <summary>
        /// Gets the artist from the respective JSON 
        /// file based on the provided album name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Artist GetArtist(string name)
        {
            return _artistRepo.FindByName(name);
        }

        /// <summary>
        /// adds song to the respective JSON file and creates dependency with the Artist.
        /// </summary>
        /// <param name="song"></param>
        /// <param name="artistName"></param>
        public void ArtistAddSong(Song song, string artistName)
        {
            Artist artist = _artistRepo.FindByName(artistName);
            LoginCheck(artist);
            _songProvider.CreateSong(song);
            artist.SognsNames.ToList().Add(song.Name);
            _artistRepo.Update(artist);
        }

        /// <summary>
        /// removes song from the respective JSON file and removes dependency with the Artist.
        /// </summary>
        /// <param name="songName"></param>
        /// <param name="artistName"></param>
        public void ArtistRemoveSong(string songName, string artistName)
        {
            Artist artist = _artistRepo.FindByName(artistName);
            LoginCheck(artist);
            artist.SognsNames.ToList().Remove(songName);
            _songProvider.RemoveSong(songName);
            _artistRepo.Update(artist);
        }

        /// <summary>
        /// creates album to the respective JSON file and creates dependency with the Artist.
        /// </summary>
        /// <param name="album"></param>
        /// <param name="artistName"></param>
        public void CreateAlbum(Album album, string artistName)
        {
            Artist artist = _artistRepo.FindByName(artistName);
            LoginCheck(artist);
            _albumProvider.CreateAlbum(album);
            artist.AlbumsNames.ToList().Add(album.Name);
            _artistRepo.Update(artist);
        }

        /// <summary>
        /// deletes album to the respective JSON file and removes dependency with the Artist.
        /// </summary>
        /// <param name="albumName"></param>
        /// <param name="artistName"></param>
        public void DeleteAlbum(string albumName, string artistName)
        {
            Artist artist = _artistRepo.FindByName(artistName);
            LoginCheck(artist);
            artist.AlbumsNames.ToList().Remove(albumName);
            _albumProvider.DeleteAlbum(albumName);
            _artistRepo.Update(artist);
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
            Artist artist = _artistRepo.FindByName(artistName);
            LoginCheck(artist);
            OwnershipCheck(artistName, songName);
            _albumProvider.AddSongToAlbum(songName, albumName);
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
            Artist artist = _artistRepo.FindByName(artistName);
            LoginCheck(artist);
            OwnershipCheck(artistName, songName);
            _albumProvider.RemoveSongFromAlbum(songName, albumName);
        }

        private void OwnershipCheck(string authorName, string songName)
        {
            Song song = _songProvider.getSong(songName);
            if (song.Author != authorName)
            {
                throw new ArgumentException(ExceptionMessagesProvider.NoOwnership);
            }
        }
    }
}
