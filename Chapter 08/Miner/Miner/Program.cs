using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{
    internal class Program
    {
        public static void WriteOutput(string result, int remainingCoals, int minerPosRow, int minerPosCol)
        {
            
            if (result == "exit")
            {
                Console.WriteLine("Game over! ({0}, {1})", minerPosRow, minerPosCol);
            }
            else if(result == "all colected")
            {
                Console.WriteLine("You collected all coals! ({0}, {1})", minerPosRow, minerPosCol);
            }
            else if(result == "")
            {
                Console.WriteLine(" {0} coals leaft ({1}, {2})", remainingCoals, minerPosRow, minerPosCol);
            }
        }

        public static string MoveMiner(ref int minerPosRowOld, ref int minerPosColOld, int minerPosRowNew, 
            int minerPosColNew, string[,] field, ref int remainingCoals, string result)
        {
            if (!IsExitPosition(minerPosRowNew, minerPosColNew, field))
            {
                string temp = field[minerPosRowOld, minerPosColOld];
                field[minerPosRowOld, minerPosColOld] = "*";               
                if (IsCoalPosition(minerPosRowNew, minerPosColNew, field))
                {
                    if (remainingCoals != 0)
                    {
                        remainingCoals--;
                    }
                    if (remainingCoals == 0)
                    {
                        result = "all colected";
                    }             
                }
                field[minerPosRowNew, minerPosColNew] = temp;
            }
            else
            {
                result = "exit";
            }
            minerPosColOld = minerPosColNew;
            minerPosRowOld = minerPosRowNew;
            return result;
        }
        public static bool IsMinerPosition(int rowIndex, int colIndex, string[,] field)
        {
            bool result = false;
            if (field[rowIndex, colIndex] == "s")
            {
                result = true;
            }
            return result;
        }
        public static bool IsValidMinerPlace(int minerPosRow, int minerPosCol, int fieldSize)
        {
            bool result = false;
            if (Math.Min(minerPosRow, minerPosCol) >= 0 && Math.Max(minerPosRow, minerPosCol) < fieldSize)
            {
                result = true;
            }
            return result;
        }
        public static bool IsCoalPosition(int rowIndex, int colIndex, string[,] field)
        {
            bool result = false;
            if (field[rowIndex, colIndex] == "c")
            {
                result = true;
            }
            return result;
        }
        public static bool IsExitPosition(int rowIndex, int colIndex, string[,] field)
        {
            bool result = false;
            if (field[rowIndex, colIndex] == "e")
            {
                result = true;
            }
            return result;
        }
        public static string PlayMinerGame(string[,] field, string[] movementCommands,
            ref int minerPositionRow, ref int minerPostionCol, ref int remainingCoals)
        {
            string result = "";
            int fieldSize = field.GetLength(0);

            foreach (string movement in movementCommands)
            {
                switch (movement)
                {
                    case "left":
                        {
                            if (IsValidMinerPlace(minerPositionRow, minerPostionCol - 1, fieldSize))
                            {
                                result = MoveMiner(ref minerPositionRow, ref minerPostionCol,  minerPositionRow, minerPostionCol - 1, field, ref remainingCoals, result);
                            }
                            break;
                        }
                    case "right":
                        {
                            if (IsValidMinerPlace(minerPositionRow, minerPostionCol + 1, fieldSize))
                            {
                                result = MoveMiner(ref minerPositionRow, ref minerPostionCol, minerPositionRow, minerPostionCol + 1, field, ref remainingCoals, result);
                            }
                            break;
                        }
                    case "up":
                        {
                            if (IsValidMinerPlace(minerPositionRow - 1, minerPostionCol, fieldSize))
                            {
                                result = MoveMiner(ref minerPositionRow, ref minerPostionCol, minerPositionRow - 1, minerPostionCol, field, ref remainingCoals, result);
                            }
                            break;
                        }
                    case "down":
                        {
                            if (IsValidMinerPlace(minerPositionRow + 1, minerPostionCol, fieldSize))
                            {
                                result = MoveMiner(ref minerPositionRow, ref minerPostionCol, minerPositionRow + 1, minerPostionCol, field, ref remainingCoals, result);
                            }
                            break;
                        }
                }
                if (result != "")
                {
                    WriteOutput(result, remainingCoals, minerPositionRow, minerPostionCol);
                }
            }
            if (result == "")
            {
                WriteOutput(result, remainingCoals, minerPositionRow, minerPostionCol);
            }
            return result;
        }
        static void Main(string[] args)
        {
            int minerPositionRow = 0;
            int minerPositionCol = 0;
            int remainingCoals = 0;
            int fieldSize = int.Parse(Console.ReadLine());
            string[,] field = new string[fieldSize, fieldSize];
            string[] movementCommands = Console.ReadLine().Split(' ').ToArray();

            for (int rows = 0; rows < fieldSize; rows++)
            {
                string[] row = Console.ReadLine().Split(' ').ToArray();
                for (int cols = 0; cols < fieldSize; cols++)
                {
                    field[rows, cols] = row[cols];

                    if (IsCoalPosition(rows, cols, field))
                    {
                        remainingCoals++;
                    }
                    else if (IsMinerPosition(rows, cols, field))
                    {
                        minerPositionRow = rows;
                        minerPositionCol = cols;
                    }
                }
            }

            int demo = 0;
            PlayMinerGame(field, movementCommands, ref minerPositionRow, ref minerPositionCol, ref remainingCoals);
            Console.ReadLine();
        }
    }
}
