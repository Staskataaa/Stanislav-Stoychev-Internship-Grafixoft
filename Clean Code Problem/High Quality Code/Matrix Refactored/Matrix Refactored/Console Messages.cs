using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Refactored
{
    public class Console_Messages
    {
        public bool ValidInput(ref int inputSize)
        {
            bool correctInput = false;

            while (correctInput == false)
            {
                if (inputSize < 0 || inputSize > 100)
                {
                    Console.WriteLine("You haven't entered a correct positive number. Please enter a new number");
                    inputSize = int.Parse(Console.ReadLine());
                }

                else
                {
                    correctInput = true;
                    break;
                }
            }

            return correctInput;
        }

        public void WriteMatrixOutput(int[,] matrix, int matrixSize)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write("{0}\t", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
