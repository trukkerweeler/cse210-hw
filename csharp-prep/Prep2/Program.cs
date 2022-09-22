using System;

namespace Prep2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("This is Prep 2");
            string letter;
            Console.Write("Please enter your grade percentage: ");
            string userPercentageStr = Console.ReadLine();
            int userPercentageInt = Int32.Parse(userPercentageStr);


            if (userPercentageInt >= 90)
            {
                letter = "A";
            }
            else if (userPercentageInt >= 80)
            {
                letter = "B";
            }
            else if (userPercentageInt >= 70)
            {
                letter = "C";
            }
            else if (userPercentageInt >= 60)
            {
                letter = "D";
            }
            else{
                letter = "F";
            }
            
            Console.WriteLine($"Your letter grade is {letter}");

            if (userPercentageInt >= 70)
            {
                Console.WriteLine("Congratulations! You passed the class.");
            }
            else{
                Console.WriteLine("Stay focused and you'll get it next time.");
            }



        }
    }
}
