using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Refactored
{
    public class VariableChangerEvent : EventArgs
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int[,] Matrix { get; set; }

        public VariableChangerEvent(int row, int col, int[,] matrix)
        {
            Col = col;
            Row = row;
            Matrix = matrix;
        }
    }
}
