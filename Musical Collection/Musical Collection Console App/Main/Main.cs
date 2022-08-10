using Musical_Collection_Console_App.Constants;
using Musical_Collection_Console_App.UserProviders;
using Musical_Collection_Console_App.Utils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Musical_Collection_Console_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*TestObject test = new TestObject("tets 2", "123");
            WriterRepository<TestObject> writerRepository = new WriterRepository<TestObject>(Paths.testPath);
            ReaderRepository<TestObject> readerRepository = new ReaderRepository<TestObject>(Paths.testPath);
            writerRepository.AddJsonToFile(test);
            writerRepository.AddJsonToFile(test);
            bool result = readerRepository.FindObject(test);
            Console.Write(result);
            Console.ReadLine();*/
            double a = 1.77;
            Console.WriteLine(a / (int)a);
            Console.ReadLine();
        }
    }
}
