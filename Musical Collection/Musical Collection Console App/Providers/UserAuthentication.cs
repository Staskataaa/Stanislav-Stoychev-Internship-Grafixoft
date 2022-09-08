using Musical_Collection_Console_App.Classes;
using Musical_Collection_Console_App.Utils.Exception_Messages;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Providers
{
    public class UserAuthenticationProvider
    {
        private EntityRepository<User> _userRepo;

        /// <summary>
        /// Constructor specifically used by the unit test. Its main purpose 
        /// is that its parameters are mocked repositories
        /// </summary>
        /// <param name="userRepo">repository that will be mocked for users no matter their type</param>
        public UserAuthenticationProvider(EntityRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserAuthenticationProvider()
        {
            _userRepo = new EntityRepository<User>();
        }

        /// <summary>
        /// checks whether the user is already logged in
        /// </summary>
        /// <param name="user">object of type user</param>
        /// <exception cref="ArgumentException"></exception>
        private protected void LoginCheck(User user)
        {
            if (user.IsActive == false)
            {
                throw new ArgumentException(ExceptionMessagesProvider.EntityIsNotLoggedIn);
            }
        }

        /// <summary>
        /// Login the artist based on the provided name and password
        /// </summary>
        /// <param name="name">name of the user</param>
        /// <param name="password">password of the user</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool Login(string name, string password)
        {
            User user = _userRepo.FindByName(name);

            if (user.Password != password)
            {
                throw new ArgumentException(ExceptionMessagesConstructorParams.InvalidPassword);
            }

            if (user.IsActive == true)
            {
                throw new ArgumentException(ExceptionMessagesProvider.InvalidLogin);
            }

            user.IsActive = true;
            _userRepo.Update(user);
            return true;
        }

        /// <summary>
        /// Registers the artist based on the provided Artist object
        /// </summary>
        /// <param name="user">object of type User</param>
        public void Register(User user)
        {
            _userRepo.SaveEntity(user);
        }

        /// <summary>
        /// Logs out the artist if he is alreadyu logged in
        /// </summary>
        /// <param name="name">name of the user that wants to log out</param>
        /// <returns></returns>
        public bool Logout(string name)
        {
            User user = _userRepo.FindByName(name);
            LoginCheck(user);
            user.IsActive = false;
            _userRepo.Update(user);
            return true;
        }

    }
}
