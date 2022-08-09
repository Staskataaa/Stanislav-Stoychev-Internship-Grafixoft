using Musical_Collection_Console_App.Constants;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Musical_Collection_Console_App.Tests.Classes_Tests
{
    public class Reader_Test
    {
        private ReaderRepository<TestObject> readerRepository;
        private WriterRepository<TestObject> writerRepository;
        private TestObject testObject;

        [SetUp]
        public void SetUp()
        {
            testObject = new TestObject("Test 1", "123");
            writerRepository = new WriterRepository<TestObject>(Paths.testPath);
            readerRepository = new ReaderRepository<TestObject>(Paths.testPath);     
        }

        [Test]
        public void readFromFile()
        {
            //assignment
            string path = WriterRepository<TestObject>.Path;
            writerRepository.AddJsonToFile(testObject);
            bool expected = true;
            bool result = readerRepository.IsTInFile(testObject);
            Assert.AreEqual(expected, result);
        }
    }
}
