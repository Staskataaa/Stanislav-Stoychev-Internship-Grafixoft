using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Refactored
{
    public class MatrixFunctions
    {
        public delegate (int, int) VariableChangerEventHandler(object source, VariableChangerEvent e);
        public event VariableChangerEventHandler VariableChanger;
        private int[] directionXArray = new int[] { 1, 1, 1, 0, -1, -1, -1, 0 };
        private int[] directionYArray = new int[] { 1, 0, -1, -1, -1, 0, 1, 1 };
        private int assignedValue = 0;
        private int matrixRow = 0;
        private int matrixCol = 0;
        private int rotation;
        private int directionX;
        private int directionY;

        public void FillMatrixPartially(int[,] matrix)
        {
            SetRotationAndDirections();
            do
            {
                matrixRow += directionX;
                matrixCol += directionY;
                assignedValue++;
                matrix[matrixRow, matrixCol] = assignedValue;

                ChangeDirectionIfNecessaryRecursive(matrix);
            }
            while (CheckIfNeigbouringCellIsEmpty(matrix));
        }

        public (int, int) FindFirstEmptyCell(int[,] matrix)
        {
            OnVariableChanger(ref matrixRow, ref matrixCol, matrix);
            return (matrixRow, matrixCol);
        }

        private bool CheckIfNeigbouringCellIsEmpty(int[,] matrix)
        {
            bool result = false;

            for (int row = matrixRow - 1; row < matrixRow + 2; row++)
            {
                for (int col = matrixCol - 1; col < matrixCol + 2; col++)
                {
                    if (CheckIfCellExists(row, col, matrix, matrix.GetLength(0)) && matrix[row, col] == 0)
                    {
                        {
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        private void SetRotationAndDirections()
        {
            rotation = -1;
            directionX = 0;
            directionY = 0;
        }

        private bool CheckIfCellExists(int matrixRow, int matrixCol, int[,] matrix, int matrixLength)
        {
            bool result = true;

            if (matrixRow >= matrixLength ||
                matrixRow < 0 ||
                matrixCol >= matrixLength ||
                matrixCol < 0)
            {
                result = false;
            }

            return result;
        }

        private bool ShouldDirectionBeChanged(int[,] matrix)
        {
            bool result;
            int newMatrixRow = matrixRow + directionX;
            int newMatrixCol = matrixCol + directionY;
            bool doesCellExists = CheckIfCellExists(newMatrixRow , newMatrixCol, matrix, matrix.GetLength(0));

            if (!CheckIfNeigbouringCellIsEmpty(matrix))
            {
                result = false;
            }

            else if (doesCellExists == true
                && matrix[matrixRow + directionX, matrixCol + directionY] != 0)
            {
                result = true;
            }

            else if (doesCellExists == true
                && matrix[matrixRow + directionX, matrixCol + directionY] == 0)
            {
                result = false;
            }

            else
            {
                result = true;
            }

            return result;
        }

        private void ChangeDirectionIfNecessaryRecursive(int[,] matrix)
        {
            int elementIndex;

            bool isChangeNecessary = ShouldDirectionBeChanged(matrix);

            if (isChangeNecessary == true)
            {
                rotation++;
                elementIndex = rotation % directionXArray.Length;
                directionX = directionXArray[elementIndex];
                directionY = directionYArray[elementIndex];

                if (!CheckIfNeigbouringCellIsEmpty(matrix))
                {
                    return;
                }

                ChangeDirectionIfNecessaryRecursive(matrix);
            }

            else
            {
                elementIndex = rotation % directionXArray.Length;
                directionX = directionXArray[elementIndex];
                directionY = directionYArray[elementIndex];
                return;
            }
        }

        protected virtual void OnVariableChanger(ref int matrixRow, ref int matrixCol, int[,] matrix)
        {
            if (VariableChanger != null)
            {
                var (row, col) = VariableChanger(this, new VariableChangerEvent(matrixRow, matrixCol, matrix));
                matrixRow = row;
                matrixCol = col;
            }
        }
    }
}
