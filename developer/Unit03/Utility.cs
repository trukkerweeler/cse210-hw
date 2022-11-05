using System.Threading;

namespace Unit03
{
    public class GameUtils
    {
        private GameUtils()
        {

        }
        public static void Wait(int millis)
        {
            Thread.Sleep(millis);
        }
    }
}