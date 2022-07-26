using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombs
{
    internal class Program
    {
        public static void CalculateAndPrintSum(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine("Sum: {0}", sum);
        }

        public static bool CheckAdjacentElement(int i, int j, int n, int m)
        {
            if (i < 0 || j < 0 || i > n - 1 || j > m - 1)
                return false;
            return true;
        }

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
                            int n = matrix.GetLength(0);
                            int m = matrix.GetLength(1);
                            if (CheckAdjacentElement(i - 1, j - 1, n, m) == true && matrix[i - 1, j - 1] > 0) 
                            {
                                matrix[i - 1, j - 1] -= bomb;
                            }
                            if (CheckAdjacentElement(i, j - 1, n, m) == true && matrix[i, j - 1] > 0)
                            {
                                matrix[i, j - 1] -= bomb;
                            }
                            if (CheckAdjacentElement(i - 1, j, n, m) == true && matrix[i - 1, j] > 0)
                            {
                                matrix[i - 1, j] -= bomb;
                            }
                            if (CheckAdjacentElement(i - 1, j + 1, n, m) == true && matrix[i - 1, j + 1] > 0)
                            {
                                matrix[i - 1, j + 1] -= bomb;
                            }
                            if (CheckAdjacentElement(i, j + 1, n, m) == true && matrix[i, j + 1] > 0)
                            {
                                matrix[i, j + 1] -= bomb;
                            }
                            if (CheckAdjacentElement(i + 1, j, n, m) == true && matrix[i + 1, j] > 0)
                            {
                                matrix[i + 1, j] -= bomb;
                            }
                            if (CheckAdjacentElement(i + 1, j + 1, n, m) == true && matrix[i + 1, j + 1] > 0)
                            {
                                matrix[i + 1, j + 1] -= bomb;
                            }
                            if (CheckAdjacentElement(i + 1, j - 1, n, m) == true && matrix[i + 1, j - 1] > 0)
                            {
                                matrix[i + 1, j - 1] -= bomb;
                            }
                        }
                    }
                }
            }
            CalculateAndPrintSum(matrix);
            return matrix;
        }

        static void Main(string[] args)
        {
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
            Console.WriteLine("Alive cells: {0}", bombSpotsJaggedArray.GetLength(0));
            matrix = DetonateBombs(bombSpotsJaggedArray ,matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1)
                    {
                        Console.Write("{0}", matrix[i, j]);
                        break;
                    }
                    Console.Write("{0} ", matrix[i, j]);
                }
            }
            Console.ReadLine();
            
        }
    }
}
