using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Utils.Exception_Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidUsername = "Invalid username!";
        public const string InvalidPassword = "Invalid password!";
        public const string InvalidFullName = "Invalid fullname!";
        public const string InvalidBirthDate = "Invalid birthdate";
        public const string InvalidInput = "Invalid console read input";
        public const string InvalidFilePath = "Specified file path does not exist";
        public const string EmptyFileException = "Specified file is empty";
        public const string InvalidInstantiation = "Cannot Insatntiate abstract class";
        public const string InvalidLogin = "Already logged in.";
        public const string InvalidLogout = "Cannot log out because you need to be logged in first.";
    }
}
