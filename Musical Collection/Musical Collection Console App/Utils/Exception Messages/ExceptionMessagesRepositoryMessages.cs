using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Utils.Exception_Messages
{
    public static class ExceptionMessagesRepositoryMessages
    {
        public const string InvalidFilePath = "Specified file path does not exist";
        public const string EmptyFileException = "Specified file is empty";
        public const string InvalidInstantiation = "Cannot Insatntiate abstract class";
        public const string IsNotUnique = "Entity with same unique value already exists";
        public const string NotFound = "Entity is not found";
        public const string EntityDoesNotExist = "Entity does not exist";
    }
}
