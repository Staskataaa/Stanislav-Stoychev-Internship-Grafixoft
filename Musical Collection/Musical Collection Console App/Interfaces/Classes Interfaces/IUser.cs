using Musical_Collection_Console_App.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Interfaces.Classes_Interfaces
{
    public interface IUser : IEntity
    {
        string Password { get; set; }
        string FullName { get; set; }
        string BirthDate { get; set; }
        bool IsActive { get; set; }
    }
}
