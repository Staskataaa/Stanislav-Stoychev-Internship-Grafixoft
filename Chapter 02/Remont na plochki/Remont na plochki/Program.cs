using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont_na_plochki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Size of square: ");
            decimal size = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Width of Tile: ");
            decimal TileWidth = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Height of Tile: ");
            decimal TileHeight = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Width of Bench: ");
            decimal BenchWidth = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Height of Bench: ");
            decimal BenchHeight = decimal.Parse(Console.ReadLine());
            decimal area = size * size;
            decimal benchSize = BenchHeight * BenchWidth;
            decimal sizeToCover = area - benchSize;
            decimal requiredTiles = sizeToCover / (TileWidth * TileHeight);
            decimal requiredTime = requiredTiles * (decimal)0.2;
            Console.WriteLine(requiredTime);
            Console.WriteLine(requiredTiles);
            Console.ReadLine();
        }
    }
}
