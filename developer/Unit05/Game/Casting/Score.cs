using System;
using Unit05;


namespace Unit05.Game.Casting
{
    public class Score : Actor
    {
        private int _score = 0;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Score(string playerno)
        {
            AddPoints(0);
            if (playerno == "p1")
            {

            }
            else
            {
               this.SetPosition (new Point(Constants.MAX_X - 150,0));
            }
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this._score += points;
            SetText($"Score: {this._score}");
            Console.WriteLine($"Score: {this._score}");
        }
    }
}