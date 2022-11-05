using System;

namespace Unit03
{

///===================
    public class Game
    {
        private bool _isPlaying;
        private Jumper jumper;
        private WordBank wordBank;
        int _remainingTries;
        
        public Game()
        {
            jumper = new Jumper();
            wordBank = new WordBank();
            _isPlaying = false;
            _remainingTries = 0;
        }

        public void StartGame()
        {
            Splash.show();
            _isPlaying = true;
            while (_isPlaying)
            {
                DoUpdates();
            }
            TerminalService.Clear();
            TerminalService.WriteText("Game Over");
        }

        private void DoUpdates()
        {
            wordBank.GenerateAnswer();
            jumper.jump();
            _remainingTries = 4;

            while (_isPlaying)
            {
                TerminalService.Clear();
                jumper.Update();
                wordBank.Update();
                
                if (! jumper.IsAlive() || _remainingTries == 0)
                {
                    DisplayGameLose();
                    if (! IsPlayerNeedsToTryAgain())
                    {
                        _isPlaying = false;
                    }
                    return;
                }

                if (wordBank.Guessed())
                {
                    DisplayGameWin();
                    if (! IsPlayerNeedsToTryAgain())
                    {
                        _isPlaying = false;
                    }
                    return;
                }
                UserGuess();
            }
        }
        private void UserGuess()
        {
            TerminalService.WriteText("");
            TerminalService.WriteText("Choose letter: ");
            char letter = Char.ToLower(TerminalService.ReadChar(false));
            if (! wordBank.UserGuess(letter))
            {
                jumper.CutRope();
                _remainingTries--;
            }
        }

        private void DisplayGameLose()
        {
            TerminalService.WriteText("");
            TerminalService.WriteText("Sorry, you lost");
            TerminalService.WriteText("The secret word was : " + wordBank.GetRandomWord());
        }
        private void DisplayGameWin()
        {
            TerminalService.WriteText("");
            TerminalService.WriteText("Congratulations you guessed the word!");
        }

        private bool IsPlayerNeedsToTryAgain()
        {
            TerminalService.WriteText(" ");
            TerminalService.WriteText("Do you want to play again? y/n");
            return Char.ToLower(TerminalService.ReadChar(false)) == 'y';    
        }
    }
}

