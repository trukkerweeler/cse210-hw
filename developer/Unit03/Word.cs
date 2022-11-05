using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Unit03
{    
    public class WordBank
    {
        private List<string> answerList;
        private List<char> guesses = new List<char>();
        private string hiddenword;        
        
        public WordBank()
        {
            answerList = new List<string>(File.ReadLines("C:\\Users\\tim\\Documents\\cse210\\cse210-hw\\developer\\Unit03\\wordlist.txt"));
            Console.WriteLine(answerList);
            hiddenword = String.Empty;
        }

        public void GenerateAnswer()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, answerList.Count - 1);
            hiddenword = answerList[randomIndex].ToLower();
            guesses.Clear();
        }


        public void Update()
        {
            StringBuilder letters = new StringBuilder();
            foreach (char guess in hiddenword)
            {
                if (guesses.Contains(guess))
                {
                    letters.AppendFormat("{0} ", Char.ToUpper(guess));
                }
                else
                {
                    letters.AppendFormat("{0} ","_");
                }
            }
            TerminalService.WriteLine(letters.ToString());
        }

        public bool UserGuess(char guess)
        {
            if (hiddenword.Contains(guess))
            {
                if (! guesses.Contains(guess))
                {
                    guesses.Add(guess);                    
                }
                return true;                
            }
            return false;
        }

        public bool Guessed()
        {
            if (guesses.Count == 0)
            {
                return false;
            }
            foreach(char letter in hiddenword)
            {
                if (! guesses.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }

        public string GetRandomWord()
        {
            return hiddenword.ToUpper();
        }
    }
}