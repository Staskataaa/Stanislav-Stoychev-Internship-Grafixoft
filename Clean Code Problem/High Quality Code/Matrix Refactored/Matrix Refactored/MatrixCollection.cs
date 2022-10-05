using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Refactored
{
    public class MatrixCollection
    {
        public int[,] Matrix { get; set; }

        public int MatrixSize => Matrix.GetLength(0);

        public MatrixCollection(int size)
        {
            Matrix = new int[size, size];
        }
    }
}
