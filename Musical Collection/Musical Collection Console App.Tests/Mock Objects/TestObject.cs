using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Tests.Classes_Tests
{
    public class TestObject : IEntity
    {
        public TestObject(string name, string value)
        {
            Name = name;
            Value = value;
            IsActive = false;
        }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
    }
}
