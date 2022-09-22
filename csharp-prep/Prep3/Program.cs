using System;

namespace Prep3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomgenerator = new Random();
            int magicNumber  = randomgenerator.Next(1,101);
            int guess = -1;
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (magicNumber<guess)
                {
                    Console.WriteLine("Guess lower");
                }
                else if (magicNumber>guess)
                {
                    Console.WriteLine("Guess higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }            

        }
    }
}
