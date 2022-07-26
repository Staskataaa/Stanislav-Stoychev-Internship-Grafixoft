using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Characters
{
    internal class Program
    {
        public static List<int> ListOfSpecialNumbers(int num)
        {
            List<int> specialNumbers = new List<int>();
            List<int> divisibleNumbers = new List<int>();
            for (int i = 1; i < num + 1; i++)
            {
                if (num < 10000)
                {
                    if (num % i == 0)
                    {
                        divisibleNumbers.Add(i);
                    }
                }
                else
                    break;
            }
            for (int a = 0; a < divisibleNumbers.Count(); a++)
            {
                int toBeAdded = 0;
                if (divisibleNumbers[a] > 0 && divisibleNumbers[a] <= 9)
                {
                    toBeAdded = divisibleNumbers[a];
                    for (int b = 0; b < divisibleNumbers.Count(); b++)
                    {
                        if (divisibleNumbers[b] >= 0 && divisibleNumbers[b] <= 9)
                        {
                            int twoDigits = (toBeAdded * 10) + divisibleNumbers[b];
                            for (int c = 0; c < divisibleNumbers.Count(); c++)
                            {
                                if (divisibleNumbers[c] >= 0 && divisibleNumbers[c] <= 9)
                                {
                                    int threeDigits = (twoDigits * 10) + divisibleNumbers[c];
                                    for (int e = 0; e < divisibleNumbers.Count(); e++)
                                    {
                                        if (divisibleNumbers[e] >= 0 && divisibleNumbers[e] <= 9)
                                        {
                                            int fourDigits = (threeDigits * 10) + divisibleNumbers[e];
                                            specialNumbers.Add(fourDigits);
                                        }
                                        else
                                            break;
                                    }
                                }
                                else if (divisibleNumbers[c] >= 10 && divisibleNumbers[c] <= 99)
                                {
                                    int fourDigits = (twoDigits * 100) + divisibleNumbers[c];
                                    specialNumbers.Add(fourDigits);
                                }
                                else
                                    break;
                            }
                        }
                        else if (divisibleNumbers[b] >= 10 && divisibleNumbers[b] <= 99)
                        {
                            int threeDigits = (toBeAdded * 100) + divisibleNumbers[b];
                            for (int d = 0; d < divisibleNumbers.Count(); d++)
                            {
                                if (divisibleNumbers[d] >= 0 && divisibleNumbers[d] <= 9)
                                {
                                    int fourDigits = (threeDigits * 10) + divisibleNumbers[d];
                                    specialNumbers.Add(fourDigits);
                                }
                            }
                        }
                        else if (divisibleNumbers[b] >= 100 && divisibleNumbers[b] <= 999)
                        {
                            int fourDigits = (toBeAdded * 1000) + divisibleNumbers[b];
                            specialNumbers.Add(fourDigits);
                        }
                        else
                            break;
                    }
                }
                else if (divisibleNumbers[a] >= 10 && divisibleNumbers[a] <= 99)
                {
                    int twoDigits = divisibleNumbers[a];
                    for (int b = 0; b < divisibleNumbers.Count(); b++)
                    {
                        if (divisibleNumbers[b] >= 0 && divisibleNumbers[b] <= 9)
                        {
                            int threeDigit = (twoDigits * 10) + divisibleNumbers[b];
                            for (int d = 0; d < divisibleNumbers.Count(); d++)
                            {
                                if (divisibleNumbers[d] >= 0 && divisibleNumbers[d] <= 9)
                                {
                                    int fourDigit = (threeDigit * 10) + divisibleNumbers[d];
                                    specialNumbers.Add(fourDigit);
                                }
                                else
                                    break;
                            }
                        }
                        else if (divisibleNumbers[b] >= 10 && divisibleNumbers[b] <= 99)
                        {
                            int fourDigit = (twoDigits * 100) + divisibleNumbers[b];
                            specialNumbers.Add(fourDigit);
                        }
                        else
                            break;
                    }
                }
                else if (divisibleNumbers[a] >= 100 && divisibleNumbers[a] <= 999)
                {
                    int threeDigit = divisibleNumbers[a];
                    for (int c = 0; c < divisibleNumbers.Count(); c++)
                    {
                        if (divisibleNumbers[c] >= 0 && divisibleNumbers[c] <= 9)
                        {
                            int fourDigit = (threeDigit * 10) + divisibleNumbers[c];
                            specialNumbers.Add(fourDigit);
                        }
                        else
                            break;
                    }
                }
                else if (divisibleNumbers[a] >= 1000 && divisibleNumbers[a] <= 9999)
                {
                    specialNumbers.Add(divisibleNumbers[a]);
                }
                else
                    break;
            }
            return specialNumbers;
        }

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<int> listNum = ListOfSpecialNumbers(num).Distinct().ToList();
            foreach (int specialNum in listNum)
            {
                Console.Write("{0} ", specialNum);
            }
            Console.ReadLine();
        }

    }
}
