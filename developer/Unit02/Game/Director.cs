using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        Card _currentCard;
        bool _isPlaying = true;
        int _score = 300;
        string _userGuess;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            _currentCard = new Card();
            _userGuess = "lower";

        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }

            Console.WriteLine($"Game Over.");
        }

        /// <summary>
        /// Asks the user for their input
        /// </summary>
        public void GetInputs()
        {
            Console.WriteLine($"The current card is {_currentCard._value}");

            Console.WriteLine($"Higher or lower h/l");
            _userGuess = Console.ReadLine();

        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates()
        {
            //Choose the next card
            Card nextCard = new Card();
            Console.WriteLine($"The card was {nextCard._value}");

            // check if the next card is higher or lower or matches the users guess.
            if (nextCard._value > _currentCard._value && _userGuess == "h"
            || nextCard._value < _currentCard._value && _userGuess == "l")
            {
                //win
                _score += 100;
            }
            else
            {
                //they lose
                _score -= 75;

            }

            // update the score.
            Console.WriteLine($"Your score is: {_score}.");

            //set current card to the nextCard.
            _currentCard = nextCard;
        }

        /// <summary>
        /// Displays the score. Also asks the player if they want to play again. 
        /// </summary>
        public void DoOutputs()
        {
            if(_score <= 0)
            {
                _isPlaying = false;
            }
            else{
                Console.WriteLine($"Would you like to keep playing y/n?");
                string playAgain = Console.ReadLine();

                if (playAgain =="y")
                {
                    _isPlaying = true;
                }
                else
                {
                    _isPlaying = false;
                }
            }
        }
    }
}