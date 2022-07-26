using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_in_Figure
{
    internal class Program
    {
        public static void CheckIfPointIsInFigure(int blockSize, int x, int y)
        {
            if (y > blockSize * 4)
                Console.WriteLine("outside");
            else if (x > blockSize * 3)
                Console.WriteLine("Outside");
            else if (x < 0 || y < 0)
                Console.WriteLine("outside");
            else if (x >= 0 && x <= 1)
            {
                if (y >= 0 && y <= 1)
                    Console.WriteLine("inside");
                else
                    Console.WriteLine("outside");
            }
            else if (x >= 2 && x <= 3)
            {
                if (y >= 0 && y <= 1)
                    Console.WriteLine("inside");
                else
                    Console.WriteLine("outside");
  }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input block size");
            int blockSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Input x coordinate");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Input x coordinate");
            int y = int.Parse(Console.ReadLine());
            CheckIfPointIsInFigure(blockSize, x, y);
            Console.ReadLine();
        }
    }
}
