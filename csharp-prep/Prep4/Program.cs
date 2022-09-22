using System;
using System.Collections.Generic;

namespace Prep4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            int newNumber = -1;
            List<int> numbers = new List<int>();
            
            while (newNumber != 0)
            {
                Console.Write("Enter a number (0 to quit): ");
                newNumber = int.Parse(Console.ReadLine());
                if (newNumber != 0)
                {
                    numbers.Add(newNumber);
                }
                
            }
            
            //find the sum
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"The sum is: {sum}");

            //find the average
            float average = sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            //find the max
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine($"The max number is {max}");
        }
    }
}
