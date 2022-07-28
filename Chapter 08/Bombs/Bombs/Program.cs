using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombs
{
    internal class Program
    {
        public static bool IsValidForUpdate(int rowsIndex, int colsIndex, ref int[,] matrix)
        {
            return IsValidIndex(rowsIndex, colsIndex, matrix.GetLength(0)) && IsValueGreaterThanZero(rowsIndex, colsIndex, ref matrix);
        }

        public static bool IsValueGreaterThanZero(int rowsIndex, int colsIndex, ref int[,] matrix)
        {
            bool result = false;
            if (matrix[rowsIndex, colsIndex] > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool IsValidIndex(int rowsIndex, int colsIndex, int matrixLength)
        {
            bool result = false;

            if (Math.Min(rowsIndex, colsIndex) >= 0 && Math.Max(rowsIndex, colsIndex) < matrixLength)
            {
                result = true;
            }
            

            return result;
        }

        public static bool IsBombSpot(int rowsCurrent, int colsCurrent, int rowIndex, int colIndex)
        {
            bool result = false;

            if (rowsCurrent == rowIndex && colsCurrent == colIndex)
            {
                result = true;    
            }

            return result;
        }

        public static void PrintOutput(int sum, int aliveCells, ref string matrix)
        {
            Console.WriteLine("Alive cells: {0}", aliveCells);
            Console.WriteLine("Sum", sum);
            Console.WriteLine(matrix);
        }

        public static void Calculate(ref int[,] matrix)
        {
            int aliveCells = 0;
            int sumOfAliveCells = 0;
            string matrixPrint = "";
            int matrixLength = matrix.GetLength(0);
            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    int currentValue = matrix[i, j];
                    matrixPrint += currentValue.ToString() + " ";
                    if (IsValueGreaterThanZero(i, j, ref matrix))
                    {                      
                        sumOfAliveCells += currentValue;
                        aliveCells++;
                    }
                }
                matrixPrint += "\n";
            }
            PrintOutput(aliveCells, sumOfAliveCells, ref matrixPrint);
        }

        public static void DetonateBomb(int rowIndex, int colIndex, ref int[,] matrix)
        {
            int bombValue = matrix[rowIndex, colIndex];
       
            for (int rows = rowIndex - 1; rows < rowIndex + 2; rows++)
            {
                for (int cols = colIndex - 1; cols < colIndex + 2; cols++)
                {
                    if (IsBombSpot(rows, cols, rowIndex, colIndex))
                    {
                        matrix[rows, cols] = 0;
                    }
                    else if (IsValidForUpdate(rows, cols, ref matrix))
                    {
                        matrix[rows, cols] -= bombValue;
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
                DetonateBomb(rowCoordianate, colCoordinate, ref matrix);
            }

            Calculate(ref matrix);
            return matrix;
        }

        //After code review
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
            Console.WriteLine("Total time in milliseconds after code review is {0}", totalTime.TotalMilliseconds);
            Console.ReadLine();
            
        }
    }
}
