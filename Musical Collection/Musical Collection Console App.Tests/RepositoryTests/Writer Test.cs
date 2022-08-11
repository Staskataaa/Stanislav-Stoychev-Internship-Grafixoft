using Musical_Collection_Console_App.Constants;
using Musical_Collection_Console_App.Utils.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Tests.Classes_Tests
{
    internal class Writer_Test
    {
        /*private WriterRepository<TestObject> writerRepository;
        private TestObject testObject;

        //partial or fully asserted
        [SetUp]
        public void SetUp()
        {
            testObject = new TestObject("Test name", "123");
            writerRepository = new WriterRepository<TestObject>(Paths.testPath);
        }

        [Test]
        public void AddFirstJSONToFile_Correct()
        {
            string path = WriterRepository<TestObject>.Path;
            string expectedString = @"[{""Name"":""Test name"",""Value"":""123""}]";
            writerRepository.AddJsonToFile(testObject);
            string result = File.ReadAllText(path);
            Assert.AreEqual(expectedString, result);
            File.WriteAllText(path, "");
        }

        [Test]
        public void AddJSONToFile_Correct()
        {
            string path = WriterRepository<TestObject>.Path;
            string expectedString = @"[{""Name"":""Test name"",""Value"":""123""},{""Name"":""test 2"",""Value"":""456""}]";
            writerRepository.AddJsonToFile(testObject);
            TestObject testObject2 = new TestObject("test 2", "456");
            writerRepository.AddJsonToFile(testObject2);
            string result = File.ReadAllText(path);
            Assert.AreEqual(expectedString, result);
            File.WriteAllText(path, "");
        }

        [Test]
        public void ConstructorCheckTestObject()
        {
            Assert.AreEqual("Test name", testObject.Name);
            Assert.AreEqual("123", testObject.Value);
        }

        [Test]
        public void ConstructorCheckWriterRepositoty()
        {
            string path = WriterRepository<TestObject>.Path;
            Assert.AreEqual(@"D:\Git\Internship_working\Musical Collection\Musical Collection Console App.Tests\Test JSONs\TestObject.json", path);
        }*/
    }
}
