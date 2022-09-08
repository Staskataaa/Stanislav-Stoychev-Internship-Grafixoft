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
    public class UserAuthentiactionProviderTests
    {
        private UserAuthenticationProvider _userAuthProvider;
        private Mock<EntityRepository<User>> _mockUserRepo;
        private User user;

        [SetUp]
        public void Set_Up()
        {
            _mockUserRepo = new Mock<EntityRepository<User>>();
            _userAuthProvider = new UserAuthenticationProvider(_mockUserRepo.Object);
            user = new User("Staskata01", "123456789", "Stanislav Stoychev", new DateTime(1987, 08, 15));
            _mockUserRepo.Setup(x => x.SaveEntity(user)).Verifiable();
            _mockUserRepo.Setup(x => x.FindByName(user.Name)).Returns(user);
            _mockUserRepo.Setup(x => x.Update(user)).Verifiable();
        }

        [Test]
        public void Register_Successful()
        {
            //act
            _userAuthProvider.Register(user);

            //assert
            _mockUserRepo.Verify(mock => mock.SaveEntity(user), Times.Once);
        }

        [Test]
        public void Register_Unsuccessful()
        {
            //asssign
            _mockUserRepo.Setup(x => x.SaveEntity(user)).Throws<ArgumentException>(
                () => throw new ArgumentException(ExceptionMessagesRepositoryMessages.IsNotUnique));

            //act and assert
            Assert.Throws<ArgumentException>(() => _userAuthProvider.Register(user));
        }

        [Test]
        public void Login_Successful()
        {
            //act
            _userAuthProvider.Login(user.Name, user.Password);

            //assert
            _mockUserRepo.Verify(mock => mock.Update(user), Times.Once);
            _mockUserRepo.Verify(mock => mock.FindByName(user.Name), Times.Once);
        }

        [Test]
        public void Login_Unsuccessful_AleadyLoggedIn()
        {
            //assign 
            user.IsActive = true;

            //act and assert
            Assert.Throws<ArgumentException>(() => _userAuthProvider.Login(user.Name, user.Password));
        }

        [Test]
        public void Login_Unsuccessful_InvalidPassword()
        {
            //assign 
            string password = "Invalid Password";

            //act and assert
            Assert.Throws<ArgumentException>(() => _userAuthProvider.Login(user.Name, password));
        }

        [Test]
        public void Logout_Successful()
        {
            //assign 
            user.IsActive = true;

            //act
            _userAuthProvider.Logout(user.Name);

            //assert
            _mockUserRepo.Verify(mock => mock.Update(user), Times.Once);
            _mockUserRepo.Verify(mock => mock.FindByName(user.Name), Times.Once);
        }

        [Test]
        public void Logout_Unsuccessful_NotLoggedIn()
        {
            //act and assert
            Assert.Throws<ArgumentException>(() => _userAuthProvider.Logout(user.Name));
        }
    }
}

