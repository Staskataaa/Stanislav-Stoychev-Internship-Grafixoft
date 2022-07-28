using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_of_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a:");
            var a = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Input b:");
            var b = decimal.Parse(Console.ReadLine());
            decimal result = a * b;
            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}
