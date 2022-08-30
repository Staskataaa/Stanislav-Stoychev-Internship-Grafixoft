using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Refactored
{
    public class RotatingWalkInMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number: ");
            int matrixSize = int.Parse(Console.ReadLine());

            ValidInput(ref matrixSize);

            VariableChanger variableChanger = new VariableChanger();
           
            MatrixCollection matrixCollection = new MatrixCollection(matrixSize);

            MatrixFunctions matrixFunctions = new MatrixFunctions();

            matrixFunctions.VariableChanger += variableChanger.OnVariableChanger;

            matrixFunctions.FillMatrixPartially(matrixCollection.Matrix);

            matrixFunctions.FindFirstEmptyCell(matrixCollection.Matrix);

            matrixFunctions.FillMatrixPartially(matrixCollection.Matrix);

            WriteMatrixOutput(matrixCollection.Matrix, matrixCollection.MatrixSize);

            Console.WriteLine(1);

            Console.ReadLine();
        }

        static bool ValidInput(ref int inputSize)
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

        static void WriteMatrixOutput(int[,] matrix, int matrixSize)
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
