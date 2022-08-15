using Moq;
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
    public class ArtistProviderTests
    {
        private ArtistProvider artistProvider;
        private Artist artist;
        private Mock<EntityRepository<Artist>> mockArtistRepo;

        [SetUp]
        public void SetUp()
        {
            mockArtistRepo = new Mock<EntityRepository<Artist>>();
            artistProvider = new ArtistProvider(mockArtistRepo.Object);
            artist = new Artist("Galena", "123456", "Galina Gencheva", "15.08.1987");
            mockArtistRepo.Setup(x => x.Save(artist)).Verifiable();
            mockArtistRepo.Setup(x => x.FindTByName(artist.Name)).Returns(artist);
            mockArtistRepo.Setup(x => x.Update(artist)).Verifiable();
        }

        [Test]
        public void Register_Successful()
        {
            //act
            artistProvider.Register(artist);

            //assert
            mockArtistRepo.Verify(mock => mock.Save(artist), Times.Once);
        }

        [Test]
        public void Register_Unsuccessful()
        {
            //asssign
            mockArtistRepo.Setup(x => x.Save(artist)).Throws<Exception>(
                () => throw new Exception(ExceptionMessagesRepositoryMessages.IsNotUnique));

            //act and assert
            Assert.Throws<Exception>(() => artistProvider.Register(artist));
        }

        [Test]
        public void Login_Successful()
        {
            //act
            artistProvider.Login(artist.Name, artist.Password);

            //assert
            mockArtistRepo.Verify(mock => mock.Update(artist), Times.Once);
            mockArtistRepo.Verify(mock => mock.FindTByName(artist.Name), Times.Once);
        }

        [Test]
        public void Login_Unsuccessful_AleadyLoggedIn()
        {
            //assign 
            artist.IsActive = true;
           
            //act and assert
            Assert.Throws<Exception>(() => artistProvider.Login(artist.Name, artist.Password));
        }

        [Test]
        public void Login_Unsuccessful_InvalidPassword()
        {
            //assign 
            string password = "Invalid Password";

            //act and assert
            Assert.Throws<Exception>(() => artistProvider.Login(artist.Name, password));
        }

        [Test]
        public void Logout_Successful()
        {
            //assign 
            artist.IsActive = true;
           
            //act
            artistProvider.Logout(artist.Name);

            //assert
            mockArtistRepo.Verify(mock => mock.Update(artist), Times.Once);
            mockArtistRepo.Verify(mock => mock.FindTByName(artist.Name), Times.Once);
        }

        [Test]
        public void Logout_Unsuccessful_NotLoggedIn()
        {
            //act and assert
            Assert.Throws<Exception>(() => artistProvider.Logout(artist.Name));
        }
    }
}
