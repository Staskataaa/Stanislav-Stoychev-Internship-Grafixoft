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
        private Repository<Listener> listenerRepo;
        private SongProvider songProvider;
        private PlaylistProvider playlistProvider;
        private AlbumProvider albumProvider;
        //maybe update all used Repos when executing Deletes
        // change entity structure - list<type> to list of string so it only holds reference
        public ListenerProvider()
        {
            listenerRepo = new Repository<Listener>();
            playlistProvider = new PlaylistProvider();
            songProvider = new SongProvider();
            albumProvider = new AlbumProvider();
        }

        public  Listener GetListener(string ListenerName)
        {
            return listenerRepo.FindTByName(ListenerName);
        }

        public void AddSongGenreToFavoutiteGenres(string listenerName, string songName)
        {
            Listener listener = listenerRepo.FindTByName(listenerName);
            Song song = songProvider.getSong(songName);
            if (listener.IsActive != false)
            {
                listener.FavouriteGenres.Add(song.Genre);
                listenerRepo.Update(listener);
            }
            else
            {
                throw new Exception(ConsoleMessages.InvalidAction);
            }
        }

        public void AddAllFromAlbumToFavourite(string listenerName, string albumName)
        {
            Listener listener = listenerRepo.FindTByName(listenerName);
            Album album = albumProvider.getAlbum(albumName);
            if (listener.IsActive != false)
            {
                    listener.FavouriteSongs = album.Collection;
                    listener.FavouriteGenres = album.Genres;
                foreach (Song song in album.Collection)
                {
                    //distinct the list for both properties
                    listener.FavouriteGenres.Distinct().Add(song.Genre).

                }
                listenerRepo.Update(listener);
            }
            else
            {
                throw new Exception(ConsoleMessages.InvalidAction);
            }
        }

        public void AddAllFromAlbumToPlaylist(string listenerName, string albumName, string targetPlaylist)
        {
            Album album = albumRepo.FindTByName(Albumname);
            Listener listener = GetListener(ListenerName);
            Playlist playlist = playlistRepo.FindTByName(targetPlaylist);
            foreach (Song songInAlbum in album.Collection)
            {
                playlist.Collection.Add(songInAlbum);
            }
            //very clunky
            listener.Playlists.Remove(playlist);
            listener.Playlists.Add(playlist);
            playlistRepo.Update(playlist);
            listenerRepo.Update(listener);
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
                throw new Exception(ExceptionMessages.InvalidLogin);
            }
            if (listener.Password != password)
            {
                throw new Exception(ExceptionMessages.InvalidPassword);
            }
            listener.IsActive = true;
            listenerRepo.Update(listener);
            return true;
        }

        public bool Logout(string ListenerName)
        {
            Listener listener = GetListener(ListenerName);
            if (listener.IsActive == false)
            {
                throw new Exception(ExceptionMessages.InvalidLogout);
            }
            listener.IsActive = false;
            listenerRepo.Update(listener);
            return true;
        }
    }
}
