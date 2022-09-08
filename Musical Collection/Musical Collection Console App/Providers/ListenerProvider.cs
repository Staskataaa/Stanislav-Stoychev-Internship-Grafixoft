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
    public class ListenerProvider : UserAuthenticationProvider
    {
        private EntityRepository<Listener> listenerRepo;
        private SongProvider songProvider;
        private AlbumProvider albumProvider;
        private PlaylistProvider playlistProvider;

        /// <summary>
        /// Default ListenerProvider constructor
        /// </summary>
        public ListenerProvider()
        {
            listenerRepo = new EntityRepository<Listener>();
            albumProvider = new AlbumProvider();
            songProvider = new SongProvider();
            playlistProvider = new PlaylistProvider();
        }


        /// <summary>
        /// Constructor specifically used by the unit test. Its main purpose 
        /// is that its parameters are mocked repositories
        /// </summary>
        /// <param name="listenerRepo"></param>
        public ListenerProvider(EntityRepository<Listener> listenerRepo)
        {
            this.listenerRepo = listenerRepo;
        }

        /// <summary>
        /// Gets the listerner if he exists from the respective JSON file based on the provided listener name
        /// </summary>
        /// <param name="ListenerName"></param>
        /// <returns></returns>
        public Listener GetListener(string ListenerName)
        {
            return listenerRepo.FindByName(ListenerName);
        }

        /// <summary>
        /// Creates playlist based on the provided Playlist 
        /// object and creates dependency between Listener and Playlist
        /// </summary>
        /// <param name="playlist"></param>
        /// <param name="listenerName"></param>
        public void ListnerCreatePlaylist(Playlist playlist, string listenerName)
        {
            Listener listener = GetListener(listenerName);
            LoginCheck(listener);
            playlistProvider.CreatePlaylist(playlist);
        }

        /// <summary>
        /// Deletes the playlist based on the provided playlist name 
        /// and removes the dependency between Listener and Playlist
        /// </summary>
        /// <param name="playlistName"></param>
        /// <param name="listenerName"></param>
        public void ListnerDeletePlaylist(string playlistName, string listenerName)
        {
            Listener listener = GetListener(listenerName);
            LoginCheck(listener);
            playlistProvider.DeletePlaylist(playlistName);
        }

        /// <summary>
        /// Finds the song and album from their respective JSON files
        /// and creates dependenct between the song genre and the listener
        /// </summary>
        /// <param name="listenerName"></param>
        /// <param name="songName"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddSongGenreToFavoutiteGenres(string listenerName, string songName)
        {
            Listener listener = listenerRepo.FindByName(listenerName);
            LoginCheck(listener);
            Song song = songProvider.getSong(songName);

            if (listener.IsActive == false)
            {
                throw new ArgumentException(ExceptionMessagesProvider.InvalidAction);
            }

            listener.FavouriteGenres.ToList().Add(song.Genre);
            listenerRepo.Update(listener);
        }

        /// <summary>
        /// Listener finds album and from its respective JSON file based on its names 
        /// and adds all song to the listener's list of favourite songs and 
        /// makes dependency between the songs and the listner
        /// </summary>
        /// <param name="listenerName"></param>
        /// <param name="albumName"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddAllFromAlbumToFavourite(string listenerName, string albumName)
        {
            Listener listener = listenerRepo.FindByName(listenerName);
            LoginCheck(listener);
            Album album = albumProvider.getAlbum(albumName);

            if (listener.IsActive != false)
            {
                foreach (Song song in album.Collection)
                {
                    listener.FavouriteSongs.ToList().Add(song.Name);
                    listener.FavouriteGenres.ToList().Add(song.Genre);
                }
            }

            else
            {
                throw new ArgumentException(ExceptionMessagesProvider.InvalidAction);
            }

            listener.FavouriteGenres = listener.FavouriteGenres.Distinct().ToList();
            listener.FavouriteSongs = listener.FavouriteSongs.Distinct().ToList();
            listenerRepo.Update(listener);
        }

        /// <summary>
        /// Listener finds album and from its respective JSON file based on its names 
        /// and adds all song to the listener's playlist and 
        /// makes dependency between the playlist and the songs
        /// </summary>
        /// <param name="listenerName"></param>
        /// <param name="albumName"></param>
        /// <param name="targetPlaylist"></param>
        public void AddAllFromAlbumToPlaylist(string listenerName, string albumName, string targetPlaylist)
        {
            Listener listener = GetListener(listenerName);
            LoginCheck(listener);
            Album album = albumProvider.getAlbum(albumName);
            Playlist playlist = playlistProvider.getPlaylist(targetPlaylist);

            foreach (Song songInAlbum in album.Collection)
            {
                playlist.Collection.ToList().Add(songInAlbum);
            }

            playlistProvider.UpdatePlaylist(playlist);
        }
    }
}
