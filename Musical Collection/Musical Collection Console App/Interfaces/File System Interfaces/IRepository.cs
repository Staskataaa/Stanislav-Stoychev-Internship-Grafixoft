using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Interfaces.File_System_Interfaces
{
    internal interface IRepository<T>
    {
        void Save(T myObject);
        void Update(T newObject);
        T FindTByName(string name);
        void Delete(string name);
        List<T> GetAll();
    }
}
