using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Utils.Exception_Messages
{
    public static class ExceptionMessagesProvider
    {
        public const string InvalidLogin = "Already logged in.";
        public const string InvalidLogout = "Cannot log out because you need to be logged in first.";
        public const string EntityIsNotLoggedIn = "Entity need to log in first to execute operation";
        public const string InvalidAction = "The following action is not valid";
        public const string NoOwnership = "The author does not have ownership of the song.";
    }
}
