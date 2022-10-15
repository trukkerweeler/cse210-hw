using System;


namespace Unit02.Game
{
    // TODO: Implement the Die class as follows...
    // 1) Add the class declaration. Use the following class comment.

        /// <summary>
        /// Represents a playing card with a value and a suit.
        /// </summary> 
        public class Card
        {
            public int _value;
            public string _suit;

            public Card()
            {
                Random randomGenerator = new Random();
                _value= randomGenerator.Next(1,14);
                int suitValue = randomGenerator.Next(1,5);

                if (suitValue == 1)
                {
                    _suit = "Hearts";
                }
                else if (suitValue ==2)
                {
                    _suit = "Diamonds";
                }
                else if (suitValue ==3)
                {
                    _suit = "Clubs";
                }
                else if (suitValue ==4)
                {
                    _suit = "Spades";
                }
            }
            public void Display()
            {
                Console.WriteLine($"{_value} of {_suit}.");
            }
        
        }
}