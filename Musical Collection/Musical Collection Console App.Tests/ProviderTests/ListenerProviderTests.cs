using Moq;
using Musical_Collection_Console_App.Utils.Exception_Messages;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Tests.ProviderTests
{
    public class ListenerProviderTests
    {
        private ListenerProvider listenerProvider;
        private Mock<EntityRepository<Listener>> mockListernerRepo;
        private Listener listener;

        [SetUp]
        public void SetUp()
        {
            mockListernerRepo = new Mock<EntityRepository<Listener>>();
            listenerProvider = new ListenerProvider(mockListernerRepo.Object);
            listener = new Listener("Staskata01", "123456789", "Stanislav Stoychev", new DateTime(1987, 08, 15));
            mockListernerRepo.Setup(x => x.Save(listener)).Verifiable();
            mockListernerRepo.Setup(x => x.FindTByName(listener.Name)).Returns(listener);
            mockListernerRepo.Setup(x => x.Update(listener)).Verifiable();
        }

        [Test]
        public void Register_Successful()
        {
            //act
            listenerProvider.Register(listener);

            //assert
            mockListernerRepo.Verify(mock => mock.Save(listener), Times.Once);
        }

        [Test]
        public void Register_Unsuccessful()
        {
            //asssign
            mockListernerRepo.Setup(x => x.Save(listener)).Throws<ArgumentException>(
                () => throw new ArgumentException(ExceptionMessagesRepositoryMessages.IsNotUnique));

            //act and assert
            Assert.Throws<ArgumentException>(() => listenerProvider.Register(listener));
        }

        [Test]
        public void Login_Successful()
        { 
            //act
            listenerProvider.Login(listener.Name, listener.Password);

            //assert
            mockListernerRepo.Verify(mock => mock.Update(listener), Times.Once);
            mockListernerRepo.Verify(mock => mock.FindTByName(listener.Name), Times.Once);
        }

        [Test]
        public void Login_Unsuccessful_AleadyLoggedIn()
        {
            //assign 
            listener.IsActive = true;

            //act and assert
            Assert.Throws<ArgumentException>(() => listenerProvider.Login(listener.Name, listener.Password));
        }

        [Test]
        public void Login_Unsuccessful_InvalidPassword()
        {
            //assign 
            string password = "Invalid Password";

            //act and assert
            Assert.Throws<ArgumentException>(() => listenerProvider.Login(listener.Name, password));
        }

        [Test]
        public void Logout_Successful()
        {
            //assign 
            listener.IsActive = true;

            //act
            listenerProvider.Logout(listener.Name);

            //assert
            mockListernerRepo.Verify(mock => mock.Update(listener), Times.Once);
            mockListernerRepo.Verify(mock => mock.FindTByName(listener.Name), Times.Once);
        }

        [Test]
        public void Logout_Unsuccessful_NotLoggedIn()
        {
            //act and assert
            Assert.Throws<ArgumentException>(() => listenerProvider.Logout(listener.Name));
        }
    }
}
