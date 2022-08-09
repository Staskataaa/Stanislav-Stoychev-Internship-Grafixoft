using Musical_Collection_Console_App.Constants;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Tests.Classes_Tests
{
    public class Writer_Test
    {
        private WriterRepository<TestObject> writerRepository;
        private TestObject testObject;

        //partial or fully asserted
        [SetUp]
        public void SetUp()
        {
            testObject = new TestObject("Test name", "123");
            writerRepository = new WriterRepository<TestObject>(MyConstants.basePath);
        }

        [Test]
        public void AddJSONToFile_Correct()
        {
            string path = WriterRepository<TestObject>.Path;
            string expected = @"{
                                  ""name"": ""Test name"",
                                  ""value"": ""123""
                                }";
            writerRepository.AddJsonToFile(testObject);
            string result = File.ReadAllText(path);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ConstructorCheckTestObject()
        {
            Assert.AreEqual("Test name", testObject.Name);
            Assert.AreEqual("123", testObject.Value);
        }

        [Test]
        public void ConstructorChevkWriterRepositoty()
        {
            string path = WriterRepository<TestObject>.Path;
            Assert.AreEqual(@"D:\Git\Internship_working\Musical Collection\Musical Collection Console App\JSONFileSystem\TestObject.json", path);
        }
    }
}
