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
        public const string InvalidSongDuration = "Invalid fullname!";
        public const string InvalidBirthDate = "Invalid birthdate";
        public const string InvalidInput = "Invalid console read input";
        public const string InvalidFilePath = "Specified file path does not exist";
        public const string EmptyFileException = "Specified file is empty";
        public const string InvalidInstantiation = "Cannot Insatntiate abstract class";
        public const string InvalidLogin = "Already logged in.";
        public const string InvalidLogout = "Cannot log out because you need to be logged in first.";
        public const string InvalidSongDurationFormat = "Invalid time format";
        public const string IsNotUnique = "Entity with same unique value already exists";
        public const string NotFound = "Entity is not found";
        public const string EntityDoesNotExist = "Entity does not exist";
        public const string EntityIsNotLoggedIn = "Entity need to log in first to execute operation";
    }
}
