using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombs
{
    internal class Program
    {
        public static void CalculateAndPrintSum(ref int[,] matrix)
        {
            int aliveCells = 0;
            int sum = 0;
            string arrayPrint = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    arrayPrint += matrix[i, j].ToString() + " ";
                    if (matrix[i, j] > 0)
                    {                      
                        sum += matrix[i, j];
                        aliveCells++;
                    }
                }
                arrayPrint += "\n";
            }
            Console.WriteLine("Alive cells: {0}", aliveCells);
            Console.WriteLine("Sum: {0}", sum);
            Console.WriteLine(arrayPrint);
        }

        public static void DetonateOneBomb(int rowIndex, int colIndex, ref int[,] matrix)
        {
            int bombValue = matrix[rowIndex, colIndex];

            for (int i = rowIndex - 1; i < rowIndex + 2; i++)
            {
                for (int j = colIndex - 1; j < colIndex + 2; j++)
                {
                    if (i >= 0 && j >= 0 && i < matrix.GetLength(0) && (j < matrix.GetLength(1)))
                    {
                        if (matrix[i, j] > 0)
                        {
                            matrix[i, j] -= bombValue;
                        }
                    }
                }
            }
        }

        public static int[,] DetonateAllBombs(int[][] jaggedArray, ref int[,] matrix)
        {
            foreach (int[] array in jaggedArray)
            {
                int rowCoordianate = array[0];
                int colCoordinate = array[1];
                DetonateOneBomb(rowCoordianate, colCoordinate, ref matrix);
            }

            CalculateAndPrintSum(ref matrix);
            return matrix;
        }
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize,matrixSize];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int[][] bombSpotsJaggedArray = Console.ReadLine().Split(' ').Select(s => s.Split(',').Select(f => int.Parse(f)).ToArray()).ToArray();
            DetonateAllBombs(bombSpotsJaggedArray , ref matrix);
            DateTime end = DateTime.Now;
            TimeSpan totalTime = end.Subtract(start);

            Console.WriteLine("Total time before code review is {0} milliseconds", totalTime.TotalMilliseconds);
            Console.ReadLine();
            
        }
    }
}
