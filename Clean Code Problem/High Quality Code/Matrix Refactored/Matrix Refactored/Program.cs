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

            Console_Output console_Messages = new Console_Output();

            console_Messages.ValidInput(ref matrixSize);

            VariableChanger variableChanger = new VariableChanger();
           
            MatrixCollection matrixCollection = new MatrixCollection(matrixSize);

            MatrixFunctions matrixFunctions = new MatrixFunctions();

            matrixFunctions.VariableChanger += variableChanger.OnVariableChanger;

            matrixFunctions.FillMatrixPartially(matrixCollection.Matrix);

            matrixFunctions.FindFirstEmptyCell(matrixCollection.Matrix);

            matrixFunctions.FillMatrixPartially(matrixCollection.Matrix);

            console_Messages.WriteMatrixOutput(matrixCollection.Matrix, matrixCollection.MatrixSize);

            Console.ReadLine();
        }
    }
}
