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
            song1 = new Song("Ti ne si za men", "Chalga", "Galena", 3.35, "24.05.2021");
            song2 = new Song("Euphoria", "Chalga", "Galena", 4.14, "07.05.2022");
            song3 = new Song("moro mou", "Chalga", "Galena", 3.56, "11.08.2018");
            List<ISong> songs = new List<ISong>();
            songs.Add(song1);
            songs.Add(song2);
            playlist = new Playlist("Chalga Galena");
            mockPlaylistRepo.Setup(x => x.FindTByName(playlist.Name)).Returns(playlist);
            mockPlaylistRepo.Setup(x => x.Save(playlist)).Verifiable();
            mockPlaylistRepo.Setup(x => x.Update(playlist)).Verifiable();
            mockPlaylistRepo.Setup(x => x.Delete(playlist.Name)).Verifiable();
            mockSongRepo.Setup(x => x.FindTByName(song3.Name)).Returns(song3);
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
            mockPlaylistRepo.Verify(mock => mock.FindTByName(playlist.Name), Times.Once);
            mockPlaylistRepo.Verify(mock => mock.Update(playlist), Times.Once);
        }

        [Test]
        public void RemoveSongToPlaylist_Correct()
        {
            //act
            playlistProvider.RemoveSongFromPlaylist(song2.Name, playlist.Name);

            //assert
            mockPlaylistRepo.Verify(mock => mock.FindTByName(playlist.Name), Times.Once);
            mockPlaylistRepo.Verify(mock => mock.Update(playlist), Times.Once);
        }

        [Test]
        public void AddSongToPlaylist_Incorrect()
        {
            //arrange
            mockPlaylistRepo.Setup(x => x.FindTByName(playlist.Name)).Throws<Exception>(
                () => throw new Exception(ExceptionMessagesRepositoryMessages.NotFound));
            mockPlaylistRepo.Setup(x => x.Update(playlist)).Verifiable();
            mockSongRepo.Setup(x => x.FindTByName(song2.Name)).Throws<Exception>(
                () => throw new Exception(ExceptionMessagesRepositoryMessages.NotFound));

            //assert
            Assert.Throws<Exception>(() => playlistProvider.AddSongToPlaylist(song2.Name, playlist.Name));
        }


        [Test]
        public void RemoveSongToPlaylist_Incorrect()
        {
            //arrange
            mockPlaylistRepo.Setup(x => x.FindTByName(playlist.Name)).Throws<Exception>(
                () => throw new Exception(ExceptionMessagesRepositoryMessages.NotFound));
            mockPlaylistRepo.Setup(x => x.Update(playlist)).Verifiable();
            mockSongRepo.Setup(x => x.FindTByName(song2.Name)).Throws<Exception>(
                () => throw new Exception(ExceptionMessagesRepositoryMessages.NotFound));

            //assert
            Assert.Throws<Exception>(() => playlistProvider.RemoveSongFromPlaylist(song2.Name, playlist.Name));
        }
    }
}
