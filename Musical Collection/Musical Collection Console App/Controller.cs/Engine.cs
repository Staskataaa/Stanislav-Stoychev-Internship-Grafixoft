using Musical_Collection_Console_App.Classes;
using Musical_Collection_Console_App.Constants;
using Musical_Collection_Console_App.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Controller.cs
{
    public class Engine
    {
        private ArtistProvider artistProvider;
        private ListenerProvider listenerProvider;

        public Engine()
        {
            artistProvider = new ArtistProvider();
            listenerProvider = new ListenerProvider();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "Quit")
                {
                    Environment.Exit(0);
                }
                //input[0] is the name of the user that makes the action
                try
                {
                    if (input[0] == "Register" && input[1] == "Artist")
                    {
                        Console.WriteLine("Username: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        string password = Console.ReadLine();
                        Console.WriteLine("Fullname: ");
                        string fullName = Console.ReadLine();
                        Console.WriteLine("Birth date: ");
                        string birthDate = Console.ReadLine();
                        Artist artist = new Artist(name, password, fullName, birthDate);
                        artistProvider.Register(artist);
                        Console.WriteLine(ConsoleMessages.SuccessfulRegister);
                    }
                    else if (input[0] == "Login" && input[1] == "Artist")
                    {
                        Console.WriteLine("Username: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        string password = Console.ReadLine();
                        artistProvider.Login(name, password);
                        Console.WriteLine(ConsoleMessages.SuccessfulLogin);
                    }
                    else if (input[0] == "Logout" && input[1] == "Artist" && !string.IsNullOrWhiteSpace(input[2]))
                    {
                        artistProvider.Logout(input[2]);
                        Console.WriteLine(ConsoleMessages.SuccessfulLogout);
                    }
                    if (input[0] == "Register" && input[1] == "Listener")
                    {
                        Console.WriteLine("Username: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        string password = Console.ReadLine();
                        Console.WriteLine("Fullname: ");
                        string fullName = Console.ReadLine();
                        Console.WriteLine("Birth date: ");
                        string birthDate = Console.ReadLine();
                        Listener listener = new Listener(name, password, fullName, birthDate);
                        listenerProvider.Register(listener);
                        Console.WriteLine(ConsoleMessages.SuccessfulRegister);
                    }
                    else if (input[0] == "Login" && input[1] == "Listener")
                    {
                        Console.WriteLine("Username: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        string password = Console.ReadLine();
                        listenerProvider.Login(name, password);
                        Console.WriteLine(ConsoleMessages.SuccessfulLogin);
                    }
                    else if (input[0] == "Logout" && input[1] == "Listener" && !string.IsNullOrWhiteSpace(input[2]))
                    {
                        artistProvider.Logout(input[2]);
                        Console.WriteLine(ConsoleMessages.SuccessfulLogout);
                    }
                    else if (input[1] == "Add" && input[2] == "Song" && input[3] == "Single")
                    {
                        Console.WriteLine("Song name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Song genre: ");
                        string genre = Console.ReadLine();
                        Console.WriteLine("Duration: ");
                        double duration = double.Parse(Console.ReadLine());
                        Song song = new Song(name, genre, input[0], duration, DateTime.Now.ToString());
                        artistProvider.ArtistAddSong(song, input[0]);
                        Console.WriteLine(ConsoleMessages.AddedSongSuccessfully);
                    }
                    else if (input[1] == "Remove" && input[2] == "Song" && input[3] == "Single")
                    {
                        Console.WriteLine("Song name: ");
                        string name = Console.ReadLine();
                        artistProvider.ArtistRemoveSong(name, input[0]);
                        Console.WriteLine(ConsoleMessages.RemoveSongSuccessfully);
                    }
                    else if (input[1] == "Create" && input[2] == "Album")
                    {
                        Console.WriteLine("Album name: ");
                        string name = Console.ReadLine();
                        Album album = new Album(name);
                        artistProvider.CreateAlbum(album, input[0]);
                        Console.WriteLine(ConsoleMessages.CreatedAlbumSuccessfully);
                    }
                    else if (input[1] == "Delete" && input[2] == "Album")
                    {
                        Console.WriteLine("Album name: ");
                        string name = Console.ReadLine();
                        artistProvider.DeleteAlbum(name, input[0]);
                        Console.WriteLine(ConsoleMessages.DeletedAlbumSuccessfully);
                    }
                    else if (input[1] == "Add" && input[2] == "Song" && input[3] == "To" && input[4] == "Album")
                    {
                        Console.WriteLine("Album name: ");
                        string albumName = Console.ReadLine();
                        Console.WriteLine("Song name: ");
                        string songName = Console.ReadLine();
                        artistProvider.ArtistAddSongToAlbum(input[0], songName, albumName);
                        Console.WriteLine(ConsoleMessages.AddedSongToAlbumSuccessfully);
                    }
                    else if (input[1] == "Remove" && input[2] == "Song" && input[3] == "From" && input[4] == "Album")
                    {
                        Console.WriteLine("Album name: ");
                        string albumName = Console.ReadLine();
                        Console.WriteLine("Song name: ");
                        string songName = Console.ReadLine();
                        artistProvider.RemoveSongFromAlbum(input[0], songName, albumName);
                        Console.WriteLine(ConsoleMessages.RemovedSongFromAlbumSuccessfully);
                    }
                    else if (input[1] == "Create" && input[2] == "Playlist")
                    {
                        Console.WriteLine("Playlist name: ");
                        string playlistName = Console.ReadLine();
                        Playlist playlist = new Playlist(playlistName);
                        listenerProvider.ListnerCreatePlaylist(playlist, input[0]);
                        Console.WriteLine(ConsoleMessages.CreatedPlaylistSuccessfully);
                    }
                    else if (input[1] == "Delete" && input[2] == "Playlist")
                    {
                        Console.WriteLine("Playlist name: ");
                        string playlistName = Console.ReadLine();
                        listenerProvider.ListnerDeletePlaylist(playlistName, input[0]);
                        Console.WriteLine(ConsoleMessages.DeletedPlaylistSuccessfully);
                    }
                    else if (input[1] == "Add" && input[2] == "Song" && input[3] == "Genre" && input[4] == "To" && input[5] == "Favourite")
                    {
                        Console.WriteLine("Song name: ");
                        string songName = Console.ReadLine();
                        listenerProvider.AddSongGenreToFavoutiteGenres(input[0], songName);
                        Console.WriteLine(ConsoleMessages.AddSongGenreToFavouriteSuccessfully);
                    }
                    else if (input[1] == "Add" && input[2] == "All" && input[3] == "From"
                        && input[4] == "Album" && input[5] == "To" && input[6] == "Favourite")
                    {
                        Console.WriteLine("Album name: ");
                        string albumName = Console.ReadLine();
                        listenerProvider.AddAllFromAlbumToFavourite(input[0], albumName);
                        Console.WriteLine(ConsoleMessages.AddAllGenresFromAlbumToFavouriteSuccessfully);
                    }
                    else if (input[1] == "Add" && input[2] == "All" && input[3] == "From"
                        && input[4] == "Album" && input[5] == "To" && input[6] == "Playlist")
                    {
                        Console.WriteLine("Album name: ");
                        string albumName = Console.ReadLine();
                        Console.WriteLine("Playlist name: ");
                        string playlistName = Console.ReadLine();
                        listenerProvider.AddAllFromAlbumToPlaylist(input[0], albumName, playlistName);
                        Console.WriteLine(ConsoleMessages.AddAllSongsFromAlbumToPlaylistSuccessfully);
                    }
                    else 
                    {
                        Console.WriteLine(ConsoleMessages.CommandDoesNotExist);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
