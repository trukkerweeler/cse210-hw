using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;
using Unit05.Game;

namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            Point point1 = new Point(Constants.MAX_X/4,Constants.MAX_Y / 2);
            Cycle cycle1 = new Cycle(point1, Constants.RED);
            cast.AddActor("cycles", cycle1);

            Point point2 = new Point(3 * Constants.MAX_X  / 4, Constants.MAX_Y / 2);
            Cycle cycle2 = new Cycle(point2, Constants.GREEN);
            cast.AddActor("cycles", cycle2);

            Score score1 = new Score("p1");
            cast.AddActor("score", score1);

            Score score2 = new Score("p2");
            cast.AddActor("score", score2);

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}