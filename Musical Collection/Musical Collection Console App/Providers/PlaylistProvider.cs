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

        public PlaylistProvider()
        {
            playlistRepo = new EntityRepository<Playlist>();
            songRepo = new EntityRepository<Song>();
        }

        public PlaylistProvider(EntityRepository<Playlist> newPlaylistRepo, EntityRepository<Song> newSongRepo)
        {
            playlistRepo = newPlaylistRepo;
            songRepo = newSongRepo;
        }

        public Playlist getPlaylist(string name)
        {
            return playlistRepo.FindTByName(name);
        }

        public void CreatePlaylist(Playlist playlist)
        {
            playlistRepo.Save(playlist);
        }

        public void UpdatePlaylist(Playlist playlist)
        {
            playlistRepo.Update(playlist);
        }

        public void DeletePlaylist(string name)
        {
            playlistRepo.Delete(name);
        }
        public void AddSongToPlaylist(string songName, string albumName)
        {
            Song song = songRepo.FindTByName(songName);
            Playlist playlist = playlistRepo.FindTByName(albumName);
            playlist.Collection.Add(song);
            playlistRepo.Update(playlist);
        }
        public void RemoveSongFromPlaylist(string songName, string albumName)
        {
            Song song = songRepo.FindTByName(songName);
            Playlist playlist = playlistRepo.FindTByName(albumName);
            playlist.Collection.Remove(song);
            playlistRepo.Update(playlist);
        }
    }
}
