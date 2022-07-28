using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _55_stars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stars = "";
            string to_be_added = "*";
            for (int i = 0; i < 9; i++)
            {
                stars += to_be_added;
                Console.WriteLine(stars);
            }

            Console.ReadLine();
        }
    }
}
