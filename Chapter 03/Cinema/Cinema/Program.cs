using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    internal class Program
    {
        public static void Cinema(int rows, int cols)
        {

            Console.WriteLine("Choose the type of tickets: ");
            string ticket = Console.ReadLine();
            if (ticket == "Premiere" || ticket == "Normal" || ticket == "Discount")
            {
                float ticketPrice = 0;
                if (ticket == "Premiere")
                    ticketPrice = 12.0f;
                if (ticket == "Normal")
                    ticketPrice = 7.5f;
                if (ticket == "Discount")
                    ticketPrice = 5.0f;
                float totalSum = rows * cols * ticketPrice;
                Console.WriteLine("The total sum of the tickets is {0}", totalSum);
            }
            else
            {
                Console.WriteLine("Invalid ticket type");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input numbner of rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Input numbner of cols: ");
            int cols = int.Parse(Console.ReadLine());
            Cinema(rows, cols);
            Console.ReadLine();
        }
    }
}
