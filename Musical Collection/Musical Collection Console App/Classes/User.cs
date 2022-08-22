using Musical_Collection_Console_App.Interfaces.Classes_Interfaces;
using Musical_Collection_Console_App.Utils.Exception_Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Classes
{
    public abstract class User : IUser
    {
        private string _name;
        private string _password;
        private string _fullName;
        private DateTime _birthDate;
        private bool _isActive;

        public User(string name, string password, string fullName, DateTime birthDate)
        {
            Name = name;
            Password = password;
            FullName = fullName;
            BirthDate = birthDate;
            IsActive = false;
        }

        public string Password { get; set; }
        public string FullName 
        {
            get
            {
                return _fullName;
            }
            set
            {
                string[] array = value.Split(' ').ToArray();
                if (array.Length <= 0 || array.Length > 2)
                {
                    throw new ArgumentException(ExceptionMessagesConstructorParams.InvalidFullName);
                }
                _fullName = value;
            }
        }
        public DateTime BirthDate { get; set; }

        public bool IsActive { get; set; }

        public string Name { get; set; }
    }
}
