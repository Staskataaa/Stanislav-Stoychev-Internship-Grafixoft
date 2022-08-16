using Musical_Collection_Console_App.Constants;
using Musical_Collection_Console_App.Interfaces.Classes_Interfaces;
using Musical_Collection_Console_App.Providers;
using Musical_Collection_Console_App.Utils.Exception_Messages;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Classes
{
    public class ListenerProvider 
    {
        private EntityRepository<Listener> listenerRepo;
        private SongProvider songProvider;
        private AlbumProvider albumProvider;
        private PlaylistProvider playlistProvider;

        public ListenerProvider()
        {
            listenerRepo = new EntityRepository<Listener>();
            albumProvider = new AlbumProvider();
            songProvider = new SongProvider();
            playlistProvider = new PlaylistProvider();
            
        }
        public ListenerProvider(EntityRepository<Listener> listenerRepo)
        {
            this.listenerRepo = listenerRepo;
        }

        public Listener GetListener(string ListenerName)
        {
            return listenerRepo.FindTByName(ListenerName);
        }

        public void ListnerCreatePlaylist(Playlist playlist, string listenerName)
        {
            Listener listener = GetListener(listenerName);
            LoginCheck(listener);
            playlistProvider.CreatePlaylist(playlist);
        }

        public void ListnerDeletePlaylist(string playlistName, string listenerName)
        {
            Listener listener = GetListener(listenerName);
            LoginCheck(listener);
            playlistProvider.DeletePlaylist(playlistName);
        }

        public void AddSongGenreToFavoutiteGenres(string listenerName, string songName)
        {
            Listener listener = listenerRepo.FindTByName(listenerName);
            LoginCheck(listener);
            Song song = songProvider.getSong(songName);
            if (listener.IsActive != false)
            {
                listener.FavouriteGenres.Add(song.Genre);
                listenerRepo.Update(listener);
            }
            else
            {
                throw new Exception(ExceptionMessagesProvider.InvalidAction);
            }
        }

        public void AddAllFromAlbumToFavourite(string listenerName, string albumName)
        {
            Listener listener = listenerRepo.FindTByName(listenerName);
            LoginCheck(listener);
            Album album = albumProvider.getAlbum(albumName);
            if (listener.IsActive != false)
            {
                foreach (Song song in album.Collection)
                {
                    listener.FavouriteSongsNames.Add(song.Name);
                    listener.FavouriteGenres.Add(song.Genre);
                }              
            }
            else
            {
                throw new Exception(ExceptionMessagesProvider.InvalidAction);
            }
            listener.FavouriteGenres = listener.FavouriteGenres.Distinct().ToList();
            listener.FavouriteSongsNames = listener.FavouriteSongsNames.Distinct().ToList();
            listenerRepo.Update(listener);
        }

        public void AddAllFromAlbumToPlaylist(string listenerName, string albumName, string targetPlaylist)
        {
            Listener listener = GetListener(listenerName);
            LoginCheck(listener);
            Album album = albumProvider.getAlbum(albumName);
            Playlist playlist = playlistProvider.getPlaylist(targetPlaylist);
            foreach (Song songInAlbum in album.Collection)
            {
                playlist.Collection.Add(songInAlbum);
            }
            playlistProvider.UpdatePlaylist(playlist);
        }

        public void Register(Listener listener)
        {
            listenerRepo.Save(listener);
        }

        public bool Login(string ListenerName, string password)
        {
            Listener listener = GetListener(ListenerName);
            if (listener.IsActive == true)
            {
                throw new Exception(ExceptionMessagesProvider.InvalidLogin);
            }
            if (listener.Password != password)
            {
                throw new Exception(ExceptionMessagesConstructorParams.InvalidPassword);
            }
            listener.IsActive = true;
            listenerRepo.Update(listener);
            return true;
        }

        public bool Logout(string ListenerName)
        {
            Listener listener = GetListener(ListenerName);
            LoginCheck(listener);
            listener.IsActive = false;
            listenerRepo.Update(listener);
            return true;
        }

        private void LoginCheck(Listener listener)
        {
            if (listener.IsActive == false)
            {
                throw new Exception(ExceptionMessagesProvider.EntityIsNotLoggedIn);
            }
        }
    }
}
