using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace AdditionalTasks
{
    internal class Program
    {
        public static double LowNumber()
        {
            Console.Write("Enter a low number: ");
            double lowNumber = Convert.ToDouble(Console.ReadLine());

            while (lowNumber <= 0)
            {
                Console.WriteLine("Please enter a positive number.");
                Console.Write("Enter a low number: ");
                lowNumber = Convert.ToDouble(Console.ReadLine());
            }

            return lowNumber;
        }

        public static double HighNumber(double lowNumber)
        {
            Console.Write("Enter a high number: ");
            double highNumber = Convert.ToDouble(Console.ReadLine());

            while (highNumber <= lowNumber)
            {
                Console.WriteLine("Please enter a high number than low number.");
                Console.Write("Enter a high number: ");
                highNumber = Convert.ToDouble(Console.ReadLine());
            }

            return highNumber;
        }

        public static bool IsPrime(double number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (double i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            double lowNumber = LowNumber();
            double highNumber = HighNumber(lowNumber);

            double difference = highNumber - lowNumber;

            Console.WriteLine("Difference between high number and low number is " + difference);

            List<double> numbers = new List<double>();

            double num = highNumber - 1;
            int index = 0;

            while (num != lowNumber)
            {
                numbers.Add(num);
                index++;
                num--;
            }

            string filepath = "C:\\numbers.txt";

            StringBuilder stringBuilder = new StringBuilder();
            foreach (double number in numbers)
            {
                stringBuilder.AppendLine(number.ToString());
            }

            File.WriteAllText(filepath, stringBuilder.ToString());

            double total = 0;

            foreach (string number in File.ReadAllLines(filepath))
            {
                total += Convert.ToInt32(number);
            }

            Console.WriteLine("Sum of all numbers in the file: " + total);

            Console.WriteLine("Prime Numbers: ");

            foreach (string number in File.ReadAllLines(filepath))

            {
                if (IsPrime(Convert.ToDouble(number)))
                {
                    Console.WriteLine(number);
                }
            }

            Console.ReadLine();
        }
    }
}
