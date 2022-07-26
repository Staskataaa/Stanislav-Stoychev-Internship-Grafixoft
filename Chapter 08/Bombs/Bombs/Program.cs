using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombs
{
    internal class Program
    {
        public static int[,] DetonateBombs(int[][] jaggedArray, int[,] matrix)
        {
            foreach (int[] array in jaggedArray)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if ((array[0] == i && array[1] == j) && matrix[i, j] != 0)
                        {
                            int bomb = matrix[i, j];
                            matrix[i, j] = 0;
                            if (i != 0)
                            {
                                
                            }
                        }
                    }
                }
            }
            return matrix;
        }

        static void Main(string[] args)
        {
            int sum = 0;
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            int[][] bombSpotsJaggedArray = Console.ReadLine().Split(' ').Select(s => s.Split(',').Select(f => int.Parse(f)).ToArray()).ToArray();
            foreach (int[] array in bombSpotsJaggedArray)
            {
                if (array[0] < matrix.GetLength(0) && array[1] < matrix.GetLength(1))
                {
                    sum += matrix[array[0], array[1]];
                }
            }
            Console.WriteLine("Alive cells: {0}", bombSpotsJaggedArray.GetLength(0));
            Console.WriteLine("Sum: {0}", sum);
            matrix = DetonateBombs(bombSpotsJaggedArray ,matrix);
            for(int i = 0; i < matrix.GetLength(0); i++)

            Console.ReadLine();
            
        }
    }
}
