using System;
using System.Collections.Generic;

namespace Unit03
{
    /// <summary>
    /// <para>Terminal object</para>
    /// <para>

    public class TerminalService
    {
        private TerminalService()
        {

        }
        public static int ReadNumber(string prompt)
        {
            string rawValue = ReadText(prompt);
            return int.Parse(rawValue, System.Globalization.CultureInfo.InvariantCulture);
        }
        
        public static string ReadText(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static Char ReadChar(bool noDisplay)
        {
            return Console.ReadKey(noDisplay).KeyChar;
        }

        public static void WaitForKey()
        {
            Console.ReadKey(true);
        }

        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
        
        public static void WriteText(string text)
        {
            Console.Write(text);
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void WriteList(List<String> list)
        {
            foreach (String line in list)
            {
                Console.WriteLine(line);
            }            
        }
    }
}