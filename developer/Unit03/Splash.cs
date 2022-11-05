using System.Collections.Generic;
using System.IO;

namespace Unit03
{   
    public class Splash
    {
        private Splash() 
        {
            // This is left empty
        }
        
        public static void show()
        {
            TerminalService.Clear();
            List<string> splashList = new List<string>(File.ReadLines("splash.txt"));
            foreach (string line in splashList)
            {
                //1 millisecond
                TextAnimator.WriteLine(line, 1);
            }
            TerminalService.WaitForKey();
            TerminalService.Clear();
        }
    }
}
