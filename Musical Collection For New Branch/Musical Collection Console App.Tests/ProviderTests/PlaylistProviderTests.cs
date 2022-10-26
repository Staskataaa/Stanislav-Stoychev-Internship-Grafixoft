using Moq;
using Musical_Collection_Console_App.Interfaces.Classes_Interfaces;
using Musical_Collection_Console_App.Providers;
using Musical_Collection_Console_App.Utils.Exception_Messages;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Tests.ProviderTests
{
    public class PlaylistProviderTests
    {

        private PlaylistProvider playlistProvider;
        private Mock<EntityRepository<Song>> mockSongRepo;
        private Mock<EntityRepository<Playlist>> mockPlaylistRepo;
        private Playlist playlist;
        private Song song1;
        private Song song2;
        private Song song3;

        [SetUp]
        public void SetUp()
        {
            mockSongRepo = new Mock<EntityRepository<Song>>();
            mockPlaylistRepo = new Mock<EntityRepository<Playlist>>();
            playlistProvider = new PlaylistProvider(mockPlaylistRepo.Object, mockSongRepo.Object);

            song1 = new Song("Ti ne si za men", "Chalga", "Galena", 3.35, new DateTime(2021, 05, 24));
            song2 = new Song("Euphoria", "Chalga", "Galena", 4.14, new DateTime(2022, 05, 07));
            song3 = new Song("moro mou", "Chalga", "Galena", 3.56, new DateTime(2018, 08, 11));
            List<ISong> songs = new List<ISong>();
            songs.Add(song1);
            songs.Add(song2);

            playlist = new Playlist("Chalga Galena");

            mockPlaylistRepo.Setup(x => x.FindByName(playlist.Name)).Returns(playlist);
            mockPlaylistRepo.Setup(x => x.SaveEntity(playlist)).Verifiable();
            mockPlaylistRepo.Setup(x => x.Update(playlist)).Verifiable();
            mockPlaylistRepo.Setup(x => x.Delete(playlist.Name)).Verifiable();
            mockSongRepo.Setup(x => x.FindByName(song3.Name)).Returns(song3);
        }

        [Test]
        public void getPlaylist_Correct()
        {
            //act
            Playlist resultPlaylist = playlistProvider.getPlaylist(playlist.Name);

            //assert
            Assert.AreEqual(playlist.Name, resultPlaylist.Name);
            Assert.AreEqual(playlist.Duration, resultPlaylist.Duration);
            Assert.AreEqual(playlist.Collection.Count(), resultPlaylist.Collection.Count());
            Assert.AreEqual(playlist.Genres.Count(), resultPlaylist.Genres.Count());
            Assert.AreEqual(playlist.CreatorName, resultPlaylist.CreatorName);
        }


        [Test]
        public void AddSongToPlaylist_Correct()
        {
            //act
            playlistProvider.AddSongToPlaylist(song3.Name, playlist.Name);

            //assert
            mockPlaylistRepo.Verify(mock => mock.FindByName(playlist.Name), Times.Once);
            mockPlaylistRepo.Verify(mock => mock.Update(playlist), Times.Once);
        }

        [Test]
        public void RemoveSongToPlaylist_Correct()
        {
            //act
            playlistProvider.RemoveSongFromPlaylist(song2.Name, playlist.Name);

            //assert
            mockPlaylistRepo.Verify(mock => mock.FindByName(playlist.Name), Times.Once);
            mockPlaylistRepo.Verify(mock => mock.Update(playlist), Times.Once);
        }

        [Test]
        public void AddSongToPlaylist_Incorrect()
        {
            //arrange
            mockPlaylistRepo.Setup(x => x.FindByName(playlist.Name)).Throws<ArgumentException>(
                () => throw new ArgumentException(ExceptionMessagesRepositoryMessages.NotFound));
            mockPlaylistRepo.Setup(x => x.Update(playlist)).Verifiable();
            mockSongRepo.Setup(x => x.FindByName(song2.Name)).Throws<ArgumentException>(
                () => throw new ArgumentException(ExceptionMessagesRepositoryMessages.NotFound));

            //assert
            Assert.Throws<ArgumentException>(() => playlistProvider.AddSongToPlaylist(song2.Name, playlist.Name));
        }


        [Test]
        public void RemoveSongToPlaylist_Incorrect()
        {
            //arrange
            mockPlaylistRepo.Setup(x => x.FindByName(playlist.Name)).Throws<ArgumentException>(
                () => throw new ArgumentException(ExceptionMessagesRepositoryMessages.NotFound));
            mockPlaylistRepo.Setup(x => x.Update(playlist)).Verifiable();
            mockSongRepo.Setup(x => x.FindByName(song2.Name)).Throws<ArgumentException>(
                () => throw new ArgumentException(ExceptionMessagesRepositoryMessages.NotFound));

            //assert
            Assert.Throws<ArgumentException>(() => playlistProvider.RemoveSongFromPlaylist(song2.Name, playlist.Name));
        }
    }
}
