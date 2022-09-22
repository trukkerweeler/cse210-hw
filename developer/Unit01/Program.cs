using System;

namespace Unit01
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameOver = 0;
            int currentPlayer = -1;
            char[] markers = {'1','2','3','4','5','6','7','8','9'};

            do {
                Console.Clear();
                currentPlayer = getNextPlayer(currentPlayer);

                displayIntro(currentPlayer);
                displayBoard(markers);

                GamePlay(markers, currentPlayer);
           
                gameOver = CheckOver(markers);

            } while (gameOver.Equals(0));    

            Console.Clear();
            displayIntro(currentPlayer);
            displayBoard(markers);        
            
            if (gameOver.Equals(1))
            {
                Console.WriteLine($"Player {currentPlayer} is the winner.");
            }
            
            if (gameOver.Equals(2))
            {                
                Console.WriteLine("The cat got it. Sorry.");
            }

        }

        private static int CheckOver(char[] markers)
        {
            //judge winner
            //loop if no winner
            //if all markers played = game is draw
            //announce winner and stop            

            if (GameWinLogic(markers))
            {
                return 1;
            }

            if (GameDrawLogic(markers))
            {
                return 2;
            }

            return 0;
        }

        private static bool GameWinLogic(char[] markers)
        {
            if(ThreeInARow(markers, 0, 1, 2))
            {
                return true;
            }
             if(ThreeInARow(markers, 3, 4, 5))
            {
                return true;
            }
             if(ThreeInARow(markers, 6, 7, 8))
            {
                return true;
            }
             if(ThreeInARow(markers, 0, 3, 6))
            {
                return true;
            }
             if(ThreeInARow(markers, 1, 4, 7))
            {
                return true;
            }
             if(ThreeInARow(markers, 2, 5, 8))
            {
                return true;
            }
             if(ThreeInARow(markers, 2, 4, 6))
            {
                return true;
            }
             if(ThreeInARow(markers, 0, 4, 8))
            {
                return true;
            }
            
            return false;
        }

        private static bool GameDrawLogic(char[] markers)
        {
            return markers[0] != '1' &&
                    markers[1] != '2' &&
                    markers[2] != '3' &&
                    markers[3] != '4' &&
                    markers[4] != '5' &&
                    markers[5] != '6' &&
                    markers[6] != '7' &&
                    markers[7] != '8' &&
                    markers[8] != '9' ;
        }

        private static bool ThreeInARow(char[] markers, int pos1, int pos2, int pos3)
        {
            return markers[pos1].Equals(markers[pos2]) && markers[pos2].Equals(markers[pos3]);
        }


        private static void GamePlay(char[] markers, int currentPlayer)
        {
            bool validselection = true;
            do
                {
                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) && 
                    (userInput == ("1") ||
                    userInput == ("2") ||
                    userInput == ("3") ||
                    userInput == ("4") ||
                    userInput == ("5") ||
                    userInput == ("6") ||
                    userInput == ("7") ||
                    userInput == ("8") ||
                    userInput == ("9")))
                {
                    int.TryParse(userInput, out var gamePlaceMarker);
                    
                    char currentMarker = markers[gamePlaceMarker - 1];

                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("This position already played, please select other.");
                    }
                    else
                    {
                        markers[gamePlaceMarker -1 ] = GetMarker(currentPlayer);
                        validselection = false;
                    }

                }
            else
            {
                Console.WriteLine("Invalid position, please choose other");
            }

            } while (validselection == true);
        }

        private static char GetMarker(int player)
        {
            if (player % 2 ==0)
            {
                return 'O';
            }
            return 'X';
        }

        static void displayIntro(int playerNo)
        {
            Console.WriteLine("Welcome to tic tac toe!");

            // player assignment
            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");
            Console.WriteLine();


            //Who's turn is it
            //Enter marker
            Console.WriteLine($"Player {playerNo} to move, select 1 through 9 from the game board.");
            Console.WriteLine();

        }
        static void displayBoard(char[] markers)
        {
            // Draw the game board
            Console.WriteLine($" {markers[0]} | {markers[1]} | {markers[2]} ");
            Console.WriteLine(" ---+---+---");
            Console.WriteLine($" {markers[3]} | {markers[4]} | {markers[5]} ");
            Console.WriteLine(" ---+---+---");
            Console.WriteLine($" {markers[6]} | {markers[7]} | {markers[8]} ");
        }

        static int getNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }            
            
            return 1;
        }
    }
}
