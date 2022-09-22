using System;
using System.Collections.Generic;

namespace Prep5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Display the welcome
            DisplayWelcome();
            
            //Get the userName
            string userName;
            userName = PromptUserName();
            
            //get the favorite number
            int favNumber;
            favNumber = PromptUserNumber();
            
            //Display the name and square number statement
            DisplayResult(userName, favNumber);
        }
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }
        static string PromptUserName()
        {
            string userName;
            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();
            return userName;

        }
        static int PromptUserNumber()
        {
            int userNumber;
            Console.Write($"Enter your favorite number: ");
            userNumber = int.Parse(Console.ReadLine());
            return userNumber;
        }
        
        static void DisplayResult(string userName, int favNumber)
        {
            int sqNumber;
            sqNumber = favNumber * favNumber;
            Console.Write($"{userName} the square of your number is {sqNumber.ToString()}");
        }
    }
}
