using Moq;
using Musical_Collection_Console_App.Constants;
using Musical_Collection_Console_App.Interfaces.File_System_Interfaces;
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
    public class SongProviderTests
    {
        private SongProvider songProvider;
        Mock<EntityRepository<Song>> songRepoMock;
        private Song song;

        [SetUp]
        public void SetUp()
        {
            songRepoMock = new Mock<EntityRepository<Song>>();
            songProvider = new SongProvider(songRepoMock.Object);
            song = new Song("Ti ne si za men", "Chalga", "Galena", 3.35, new DateTime(2021, 05, 24));
            songRepoMock.Setup(x => x.FindByName(song.Name)).Returns(song);
            songRepoMock.Setup(x => x.Delete(song.Name)).Verifiable();
            songRepoMock.Setup(x => x.SaveEntity(song)).Verifiable();
        }

        //The following tests also cover the .Get, .Create and .Delete methods for all the providers
        [Test]
        public void getSong_Incorrect()
        {
            songRepoMock.Setup(x => x.FindByName(song.Name)).Throws<ArgumentException>(
                () => throw new ArgumentException(ExceptionMessagesRepositoryMessages.NotFound));
            Assert.Throws<ArgumentException>(() => songProvider.getSong(song.Name));
        }

        [Test]
        public void getSong_Correct()
        {
            //act
            Song result = songProvider.getSong(song.Name);

            //assert
            Assert.AreEqual(song.Name, result.Name);
            Assert.AreEqual(song.Duration, result.Duration);
            Assert.AreEqual(song.Author, result.Author);
            Assert.AreEqual(song.ReleaseDate, result.ReleaseDate);
            Assert.AreEqual(song.Genre, result.Genre);
        }

        [Test]
        public void RemoveSong_Correct()
        {
            //act
            songProvider.RemoveSong(song.Name);

            //assert
            songRepoMock.Verify(mock => mock.Delete(song.Name), Times.Once());
        }

        [Test]
        public void CreateSong_Correct()
        {
            //act
            songProvider.CreateSong(song);

            //assert
            songRepoMock.Verify(mock => mock.SaveEntity(song), Times.Once);
        }

        [Test]
        public void Createsong_Incorrect()
        {
            //arrange
            songRepoMock.Setup(x => x.SaveEntity(song)).Throws<ArgumentException>(
                () => throw new ArgumentException(ExceptionMessagesRepositoryMessages.IsNotUnique));

            //act and assert
            Assert.Throws<ArgumentException>(() => songProvider.CreateSong(song));
        }

    }
}
