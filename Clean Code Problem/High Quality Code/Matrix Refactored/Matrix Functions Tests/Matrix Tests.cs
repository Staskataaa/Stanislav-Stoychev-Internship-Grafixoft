using Matrix_Refactored;
using Moq;
using System.Reflection;

namespace Matrix_Functions_Tests
{
    public class Tests
    {
        private MatrixFunctions matrixFunctions;
        private int[,] matrix;

        [SetUp]
        public void Setup()
        {
            matrixFunctions = new MatrixFunctions();
            matrix = new int[5, 5];
        }

        [Test]
        public void FillMatrixPartially()
        {
            int[,] expectedMatrix = new int[,]{
                                                { 1, 13, 14, 15, 16 },
                                                { 12, 2, 21, 22, 17 },
                                                { 11, 0, 3, 20, 18 },
                                                { 10, 0, 0, 4, 19 },
                                                { 9, 8, 7, 6, 5 }
                                               };

            int size = 5;
            int[,] newMatrix = new int[size, size];
            int matrixRow = 0;
            int matrixCol = 0;
            int rotation = 0;
            int assignedValue = 1;
            int directionX = 1;
            int directionY = 1;

            matrixFunctions.FillMatrixPartially(newMatrix);

            Assert.AreEqual(expectedMatrix, newMatrix);
        }

        [Test]
        public void FillMatrixFully()
        {
            int[,] expectedMatrix = new int[,]{
                                                { 1, 13, 14, 15, 16 },
                                                { 12, 2, 21, 22, 17 },
                                                { 11, 23, 3, 20, 18 },
                                                { 10, 25, 24, 4, 19 },
                                                { 9, 8, 7, 6, 5 }
                                               };

            int size = 5;
            int[,] newMatrix = new int[size, size];

            VariableChanger variableChanger = new VariableChanger();
            matrixFunctions.VariableChanger += variableChanger.OnVariableChanger;

            matrixFunctions.FillMatrixPartially(newMatrix);

            matrixFunctions.FindFirstEmptyCell(newMatrix);

            matrixFunctions.FillMatrixPartially(newMatrix);

            Assert.AreEqual(expectedMatrix, newMatrix);
        }

        [Test]
        public void FindFirstEmptyCell()
        {
            int[,] matrix = new int[,]{
                                                { 1, 13, 14, 0, 16 },
                                                { 12, 2, 0, 22, 17 },
                                                { 11, 0, 3, 20, 18 },
                                                { 10, 24, 0, 4, 19 },
                                                { 0, 8, 7, 6, 0 }
                                               };

            (int, int) expected = (0, 3);
            VariableChanger variableChanger = new VariableChanger();
            matrixFunctions.VariableChanger += variableChanger.OnVariableChanger;

            (int, int) result = matrixFunctions.FindFirstEmptyCell(matrix);

            Assert.AreEqual(expected, result);
        }

        [TestCase(2, 3)]
        [TestCase(4, 2)]
        public void CheckIfCellExistsWithReflection_Correct(int row, int col)
        {
            MethodInfo methodInfo = typeof(MatrixFunctions).GetMethod("CheckIfCellExists",
                BindingFlags.NonPublic | BindingFlags.Instance);
            int[,] matrix = new int[,]{
                                                { 1, 13, 14, 0, 16 },
                                                { 12, 2, 0, 22, 17 },
                                                { 11, 0, 3, 20, 18 },
                                                { 10, 24, 0, 4, 19 },
                                                { 0, 8, 7, 6, 0 }
                                               };

            var expected = true;
            var result = methodInfo.Invoke(matrixFunctions, new object[] { row, col, matrix });
            Assert.AreEqual(expected, result);
        }

        [TestCase(7, 3)]
        [TestCase(6, 9)]
        public void CheckIfCellExistsWithReflection_Incorrect(int row, int col)
        {
            MethodInfo methodInfo = typeof(MatrixFunctions).GetMethod("CheckIfCellExists",
                BindingFlags.NonPublic | BindingFlags.Instance);
            int[,] matrix = new int[,]{
                                                { 1, 13, 14, 0, 16 },
                                                { 12, 2, 0, 22, 17 },
                                                { 11, 0, 3, 20, 18 },
                                                { 10, 24, 0, 4, 19 },
                                                { 0, 8, 7, 6, 0 }
                                               };

            var expected = false;
            var result = methodInfo.Invoke(matrixFunctions, new object[] { row, col, matrix });
            Assert.AreEqual(expected, result);
        }
    }    
}