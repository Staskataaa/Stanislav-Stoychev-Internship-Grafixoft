using System;

namespace Task3
{
    /// <summary>
    /// The following code contains way too many redundanies. Here I my opinion I will delete all the code and write it again 
    /// because it is way too incoherent but the purpose of the problem is refactoring :). Refactoring here is MANDATORY because 
    /// noone can grasp the idea of the develoer and cannot comprehend the the the conditions of the problem without reading them itself.
    /// Code should be comprehensible for anyone that opens the solution and not take more than several minutes to understand.
    /// Here I will provide a list of the changes that are required to make.
    /// First of all change the names of variables, methods etc. that are not written correctly or do not provide enough detail about
    /// their functionality, or names are formed by a mix of multiple languages like WalkInMatrica.
    /// Make reusable code either global like the dirX and dirY arrays or isolate them in method and invoke them when necessary.
    /// The second example can be seen in the clearly copy pasted code in the main method.
    /// The for loop-s in the change and proverka methods are making 'magic number iterations' that needs to be replaced with the 
    /// length of their respective arrays. When we want to check if we are at a specific iteration we shhould specify that with the array
    /// lengths or even more correct way will be to migrate the values to variables.
    /// Several if statements are way to complex and require immense amount of energy to be comrehended. 
    /// You can create methods that check whether the statement is correct.
    /// Several empty lines are found that does not have exact purpose. One line of separation is just enought when we have logical separation.
    /// Same argumrnt can be said when we have multiple statements on one line. When we have a structure 
    /// that can use body braces it is highly recommended that we should use them.
    /// </summary>
    class RotatingWalkInMatrix
    {
        static int[] directionXArray = new int[] { 1, 1, 1, 0, -1, -1, -1, 0 };
        static int[] directionYArray = new int[] { 1, 0, -1, -1, -1, 0, 1, 1 };

        static void ChangeDirection(ref int directionX, ref int directionY, ref int[,] matrix,
            int matrixRow, int matrixCol, ref int rotation)
        {
            for (int count = 0; count < directionXArray.Length; count++)
            {
                int elementIndex = (count + rotation) % directionXArray.Length;
                int newMatrixRow = matrixRow + directionXArray[elementIndex];
                int newMatrixCol = matrixCol + directionYArray[elementIndex];
                if (CheckIfCellExists(newMatrixRow, newMatrixCol, matrix) || 
                    matrix[newMatrixRow, newMatrixCol] != 0)
                {
                    continue;
                }
                else
                {
                    directionX = directionXArray[elementIndex];
                    directionY = directionYArray[elementIndex];
                    rotation = count;
                    break;
                }
            }
        }

        static bool CheckIfNeigbouringCellIsEmpty(ref int matrixRow, ref int matrixCol, ref int[,] matrix)
        {
            bool result = false;
            for (int row = matrixRow - 1; row < matrixRow + 2; row++)
            {
                for (int col = matrixCol - 1; col < matrixCol + 2; col++)
                {
                    if(CheckIfCellExists(row, col, matrix))
                    {
                        if (matrix[row, col] == 0)
                        {
                            result = true;
                        }
                    }    
                }
            }
            return result;
        }

        static bool FindCell(int[,] matrix, ref int matrixRow, ref int matrixCol)
        {
            bool result = false;
            matrixRow = 0;
            matrixCol = 0;

            for (int newRow = 0; newRow < matrix.GetLength(0); newRow++)
            {
                if (result == true)
                {
                    break;
                }
                for (int newCol = 0; newCol < matrix.GetLength(0); newCol++)
                {
                    if (matrix[newRow, newCol] == 0)
                    {
                        matrixRow = newRow;
                        matrixCol = newCol;
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number ");
            int inputSize = int.Parse(Console.ReadLine());
            ValidInput(ref inputSize);
            int[,] matrix = new int[inputSize, inputSize];
            int rotation = 1;
            int assignedValue = 1;
            int matrixRow = 0;
            int matrixCol = 0;
            int directionX = 1;
            int directionY = 1;

            WhileFunc(ref matrix, ref matrixRow, ref matrixCol, ref assignedValue, 
                ref inputSize, ref directionX, ref directionY, ref rotation);

            FindCell(matrix, ref matrixRow, ref matrixCol);

            WhileFunc(ref matrix, ref matrixRow, ref matrixCol, ref assignedValue, 
                ref inputSize, ref directionX, ref directionY, ref rotation);

            WriteMatrix(matrix);

            Console.ReadLine();
        }

        static void WhileFunc(ref int[,] matrix, ref int matrixRow, ref int matrixCol, ref int assignedValue,
            ref int sizeInput, ref int directionX, ref int directionY, ref int rotaion)
        {
            while (true)
            {
                if (!CheckIfNeigbouringCellIsEmpty(ref matrixRow, ref matrixCol, ref matrix))
                {
                    break;
                }

                matrix[matrixRow, matrixCol] = assignedValue; 
                
                if (ChangeDirectionCheck(ref matrix, ref matrixRow, ref matrixCol,
                    ref sizeInput, ref directionX, ref directionY))
                {
                    ChangeDirection(ref directionX, ref directionY, 
                        ref matrix, matrixRow, matrixCol, ref rotaion);
                }

                matrixRow += directionX;
                matrixCol += directionY;
                assignedValue++;
            }            
        }

        static bool ChangeDirectionCheck(ref int[,] matrix, ref int matrixRow, ref int matrixCol, 
            ref int inputSize, ref int directionX, ref int directionY)
        {
            bool result = false;

            if (matrixRow + directionX >= inputSize ||
                matrixRow + directionX < 0 ||
                matrixCol + directionY >= inputSize ||
                matrixCol + directionY < 0 ||
                matrix[matrixRow + directionX, matrixCol + directionY] != 0)
            {
                result = true;
            }

            return result;
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

        static bool CheckIfCellExists(int matrixRow, int matrixCol, int[,] matrix)
        {
            bool result = true;

            if (matrixRow >= matrix.GetLength(0) ||
                matrixRow < 0 ||
                matrixCol >= matrix.GetLength(0) ||
                matrixCol < 0)
            {
                result = false;
            }

            return result;
        }

        static void WriteMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0}\t", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
