using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Numbers
{
    internal class Program
    {
        public static  bool ThreeEqualNumbers(int a, int b, int c)
        {
            if (a == b && b == c && c == a)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input first number");
            int one = int.Parse(Console.ReadLine());
            Console.WriteLine("Input second number");
            int two = int.Parse(Console.ReadLine());
            Console.WriteLine("Input thrid number");
            int three = int.Parse(Console.ReadLine());
            bool result = ThreeEqualNumbers(one, two, three);
            if (result == true)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            Console.ReadLine();
        }
    }
}
