﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Refactored
{
    public class VariableChanger
    {
        public (int, int) OnVariableChanger(object source, VariableChangerEvent e)
        {
            bool foundResult = false;
            int matrixLength = e.Matrix.GetLength(0);

            for (int newRow = 0; newRow < matrixLength; newRow++)
            {
                for (int newCol = 0; newCol < matrixLength; newCol++)
                {
                    if (e.Matrix[newRow, newCol] == 0)
                    {
                        e.Row = newRow;
                        e.Col = newCol;
                        foundResult = true;
                        break;
                    }
                }
                if (foundResult == true)
                {
                    break;
                }
            }

            return (e.Row, e.Col);
        }
    }
}
