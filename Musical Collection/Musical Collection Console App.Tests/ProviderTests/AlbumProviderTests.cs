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
    public class AlbumProviderTests
    {
        private AlbumProvider albumProvider;
        private Mock<EntityRepository<Album>> mockAlbumRepository;
        private Mock<EntityRepository<Song>> mockSongRepository;
        private Album album;
        private Song song1;
        private Song song2;
        private Song song3;

        [SetUp]
        public void SetUp()
        {
            mockSongRepository = new Mock<EntityRepository<Song>>();
            mockAlbumRepository = new Mock<EntityRepository<Album>>();
            albumProvider = new AlbumProvider(mockAlbumRepository.Object, mockSongRepository.Object);
            song1 = new Song("Ti ne si za men", "Chalga", "Galena", 3.35, "24.05.2021");
            song2 = new Song("Euphoria", "Chalga", "Galena", 4.14, "07.05.2022");
            song3 = new Song("moro mou", "Chalga", "Galena", 3.56, "11.08.2018");
            List<ISong> songs = new List<ISong>();
            songs.Add(song1);
            songs.Add(song2);
            album = new Album("Chalga Galena");
            mockAlbumRepository.Setup(x => x.Save(album)).Verifiable();
            mockAlbumRepository.Setup(x => x.FindTByName(album.Name)).Returns(album);
            mockAlbumRepository.Setup(x => x.Update(album)).Verifiable();
            mockSongRepository.Setup(x => x.FindTByName(song3.Name)).Returns(song3);
        }

        [Test]
        public void AddSongToAlbum_Correct()
        {
            //act
            albumProvider.AddSongToAlbum(song3.Name, album.Name);

            //assert
            mockAlbumRepository.Verify(mock => mock.FindTByName(album.Name), Times.Once);
            mockAlbumRepository.Verify(mock => mock.Update(album), Times.Once);
        }

        [Test]
        public void RemoveSongFromAlbum_Correct()
        {
            //act
            albumProvider.RemoveSongFromAlbum(song2.Name, album.Name);

            //assert
            mockAlbumRepository.Verify(mock => mock.FindTByName(album.Name), Times.Once);
            mockAlbumRepository.Verify(mock => mock.Update(album), Times.Once);
        }

        [Test]
        public void RemoveSongFromAlbym_Incorrect()
        {
            //arrange
            mockAlbumRepository.Setup(x => x.FindTByName(album.Name)).Throws<Exception>(
                () => throw new Exception(ExceptionMessagesRepositoryMessages.NotFound));
            mockAlbumRepository.Setup(x => x.Update(album)).Verifiable();
            mockSongRepository.Setup(x => x.FindTByName(song2.Name)).Throws<Exception>(
                () => throw new Exception(ExceptionMessagesRepositoryMessages.NotFound));

            //act and assert
            Assert.Throws<Exception>(() => albumProvider.RemoveSongFromAlbum(song2.Name, album.Name));
        }

        [Test]
        public void AddSongToAlbumCorrect()
        {
            //arrange
            mockAlbumRepository.Setup(x => x.FindTByName(album.Name)).Throws<Exception>(
                () => throw new Exception(ExceptionMessagesRepositoryMessages.NotFound));
            mockAlbumRepository.Setup(x => x.Update(album)).Verifiable();
            mockSongRepository.Setup(x => x.FindTByName(song2.Name)).Throws<Exception>(
                () => throw new Exception(ExceptionMessagesRepositoryMessages.NotFound));

            //act and assert
            Assert.Throws<Exception>(() => albumProvider.AddSongToAlbum(song2.Name, album.Name));
        }
    }
}
