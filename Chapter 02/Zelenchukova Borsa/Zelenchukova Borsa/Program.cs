using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelenchukova_Borsa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input price per kilogram of vegetables: ");
            double veggies = double.Parse(Console.ReadLine());
            Console.WriteLine("Input price per kilogram of fruits: ");
            double fruits = double.Parse(Console.ReadLine());
            Console.WriteLine("Input total kilograms of vegetables: ");
            double veggie_total = double.Parse(Console.ReadLine());
            Console.WriteLine("Input total kilograms of vegetables: ");
            double fruits_total = double.Parse(Console.ReadLine());
            double result = (veggies * veggie_total) + (fruits * fruits_total);
            Console.WriteLine(result / 1.94);
            Console.ReadLine();
        }
    }
}
