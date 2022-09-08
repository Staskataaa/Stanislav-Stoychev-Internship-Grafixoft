using Musical_Collection_Console_App.Interfaces.Classes_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Tests.Classes_Tests
{
    internal class EntityConstrucorChecks
    {

        private Artist artist;
        private Album album;
        private Listener listener;
        private Playlist playlist;
        private Song song;
        private Song song2;
        private Song song3;
        private List<Song> songsPlaylist;
        private List<Song> songsAlbum;
        private List<string> genres;
        [SetUp]
        public void SetUp()
        {
            artist = new Artist("Galena", "123456", "Galina Gencheva", new DateTime(1981, 03, 18));
            song = new Song("Ti ne si za men", "Chalga", artist.Name, 3.35, new DateTime(2021, 05, 24));
            song2 = new Song("Welcome to bulgaria", "Chalga", artist.Name, 3.14, new DateTime(2022, 07, 15));
            song3 = new Song("Euphoria", "Balada", artist.Name, 4.14, new DateTime(2022, 01, 11));
            songsAlbum = new List<Song>();
            genres = new List<string>();
            songsPlaylist = new List<Song>();
            listener = new Listener("Staskata01", "123123", "Stanislav Stoychev", new DateTime(2001, 11, 10));
            playlist = new Playlist("chalga mix");
            album = new Album("Mega hitove");
        }

        [Test]
        public void TestArtistConstrucor_Valid()
        {
            Assert.AreEqual("Galena", artist.Name);
            Assert.AreEqual("123456", artist.Password);
            Assert.AreEqual("Galina Gencheva", artist.FullName);
            Assert.AreEqual("18/03/1981", artist.BirthDate.ToString("dd/MM/yyyy"));
            Assert.AreEqual(false, artist.IsActive);
        }

        [Test]
        public void TestSongConstructor_Valid()
        {
            Assert.AreEqual("Ti ne si za men", song.Name);
            Assert.AreEqual(true, song.Genre.Contains("Chalga"));
            Assert.AreEqual(artist.Name, song.Author);
            Assert.AreEqual(3.35, song.Duration);
            Assert.AreEqual("24/05/2021", song.ReleaseDate.ToString("dd/MM/yyyy"));
        }
        [Test]
        public void TestListenerConstructor_Valid()
        {
            Assert.AreEqual("Staskata01", listener.Name);
            Assert.AreEqual("123123", listener.Password);
            Assert.AreEqual("Stanislav Stoychev", listener.FullName);
            Assert.AreEqual("10/11/2001", listener.BirthDate.ToString("dd/MM/yyyy"));
        }
        [Test]
        public void TestPlaylistConstructor_Valid()
        {
            Assert.AreEqual("chalga mix", playlist.Name);
            Assert.AreEqual(songsPlaylist, playlist.Collection);
        }

        [Test]
        public void TestAlbumConstructor_Valid()
        {
            genres.Add("Balada");
            Assert.AreEqual("Mega hitove", album.Name);
            Assert.AreEqual(songsAlbum, album.Collection);
        }
    }
}
