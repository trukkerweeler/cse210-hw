using System;


namespace Unit05.Game.Casting
{

    public class PlayerOneScore : Actor
    {
        private int _points = 0;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PlayerOneScore()
        {
            AddPoints(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this._points += points;
            SetText($"Score: {this._points}");
            Console.WriteLine($"Score p1: {this._points}");
        }
    }
}