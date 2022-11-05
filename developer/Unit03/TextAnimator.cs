using System;
using System.Collections.Generic;
using System.IO;

namespace Unit03
{   
    public class TextAnimator
    {
        private TextAnimator() 
        {
            // This is left empty
        }
        
        public static void WriteLine(string text, int interval)
        {
            foreach (char ch in text)
            {
                TerminalService.WriteText(ch.ToString());
                if (ch != ' ')
                {
                    GameUtils.Wait(interval);
                }                
            }
            TerminalService.WriteText("\n");
        }
    }
}
