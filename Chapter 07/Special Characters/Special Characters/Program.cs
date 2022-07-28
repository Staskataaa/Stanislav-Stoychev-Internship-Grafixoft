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
            List<int> totalNumbers = new List<int>();
            for (int i = 1111; i < 10000; i++)
            {
                if (!i.ToString().Contains("0"))
                {
                    totalNumbers.Add(i);
                }
            }
            for (int a = 0; a < totalNumbers.Count(); a++)
            {
                int checkOne = totalNumbers.ElementAt(a) / 1000;
                int checkTwo = (totalNumbers.ElementAt(a) / 100) % 10;
                int checkThree = (totalNumbers.ElementAt(a) / 10) % 10;
                int checkFour = totalNumbers.ElementAt(a) % 10;
                if (num % checkOne == 0)
                {
                    if (num % checkTwo == 0)
                    {
                        if (num % checkThree == 0)
                        {
                            if (num % checkFour == 0)
                            {
                                specialNumbers.Add(totalNumbers[a]);
                            }
                        }
                    }
                }
            }

            return specialNumbers;
        }

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<int> listNum = ListOfSpecialNumbers(num);
            foreach (int specialNum in listNum)
            {
                Console.Write("{0} ", specialNum);
            }
            Console.ReadLine();
        }

    }
}
