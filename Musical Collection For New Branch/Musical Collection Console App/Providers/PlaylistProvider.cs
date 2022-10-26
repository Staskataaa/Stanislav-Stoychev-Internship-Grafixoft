using Musical_Collection_Console_App.Classes;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Providers
{
    public class PlaylistProvider
    {

        private EntityRepository<Playlist> playlistRepo;
        private EntityRepository<Song> songRepo;

        /// <summary>
        /// default PlaylistProviderConstructor
        /// </summary>
        public PlaylistProvider()
        {
            playlistRepo = new EntityRepository<Playlist>();
            songRepo = new EntityRepository<Song>();
        }

        /// <summary>
        /// Constructor specifically used by the unit test. Its main purpose 
        /// is that its parameters are mocked repositories
        /// <summary>
        /// <param name="newPlaylistRepo">repository that will be mocked in the unit test. Serves as repo for playlist objects</param>
        /// <param name="newSongRepo">repository that will be mocked in the unit test. Serves as repo for songs</param>
        public PlaylistProvider(EntityRepository<Playlist> newPlaylistRepo, EntityRepository<Song> newSongRepo)
        {
            playlistRepo = newPlaylistRepo;
            songRepo = newSongRepo;
        }

        /// <summary>
        /// Finds the playlist if it exists in the database
        /// </summary>
        /// <param name="name">name of the plalist</param>
        /// <returns></returns>
        public Playlist getPlaylist(string name)
        {
            return playlistRepo.FindByName(name);
        }

        /// <summary>
        /// saves playlist ti its designated JSON file 
        /// based on the provided JSON object
        /// </summary>
        /// <param name="playlist">playlist object</param>
        public void CreatePlaylist(Playlist playlist)
        {
            playlistRepo.SaveEntity(playlist);
        }

        /// <summary>
        /// finds the playlist based on the playlist's name 
        /// property and replaces it with the provided Playlist object
        /// </summary>
        /// <param name="playlist">playlist object</param>
        public void UpdatePlaylist(Playlist playlist)
        {
            playlistRepo.Update(playlist);
        }

        /// <summary>
        /// finds the playlist based on its name and deletes it from the JOSN file
        /// </summary>
        /// <param name="name">name of the playlist</param>
        public void DeletePlaylist(string name)
        {
            playlistRepo.Delete(name);
        }

        /// <summary>
        /// finds the song and the playlist based on their names from the respective 
        /// JSON file adds the song to the playlist and creates
        /// dependency between the song and the playlist
        /// </summary>
        /// <param name="songName">name of the song</param>
        /// <param name="albumName">name of the album</param>
        public void AddSongToPlaylist(string songName, string albumName)
        {
            Song song = songRepo.FindByName(songName);
            Playlist playlist = playlistRepo.FindByName(albumName);
            playlist.Collection.ToList().Add(song);
            playlistRepo.Update(playlist);
        }

        /// <summary>
        /// finds the song and the playlist based on their names from the respective 
        /// JSON file removes the song from the playlist and removes the 
        /// dependency between the song and the playlist
        /// </summary>
        /// <param name="songName">name of the song</param>
        /// <param name="albumName">name of the album</param>
        public void RemoveSongFromPlaylist(string songName, string albumName)
        {
            Song song = songRepo.FindByName(songName);
            Playlist playlist = playlistRepo.FindByName(albumName);
            playlist.Collection.ToList().Remove(song);
            playlistRepo.Update(playlist);
        }
    }
}
