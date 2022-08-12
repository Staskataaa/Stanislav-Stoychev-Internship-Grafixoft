using Musical_Collection_Console_App.Classes;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Providers
{
    internal class PlaylistProvider
    {
        private Repository<Playlist> playlistRepo;
        private SongProvider songProvider;

        public PlaylistProvider()
        {
            playlistRepo = new Repository<Playlist>();
            songProvider = new SongProvider();
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
            Song song = songProvider.getSong(songName);
            Playlist playlist = playlistRepo.FindTByName(albumName);
            playlist.Collection.Add(song);
            playlistRepo.Update(playlist);
        }
        public void RemoveSongFromPlaylist(string songName, string albumName)
        {
            Song song = songProvider.getSong(songName);
            Playlist playlist = playlistRepo.FindTByName(albumName);
            playlist.Collection.Remove(song);
            playlistRepo.Update(playlist);
        }
    }
}
