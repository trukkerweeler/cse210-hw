using System;


namespace Unit05.Game.Casting
{

    public class PlayerTwoScore : Actor
    {
        private int _playerTwoScore = 0;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PlayerTwoScore()
        {
            AddPoints(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this._playerTwoScore += points;
            SetText($"Score p2: {this._playerTwoScore}");
            //Console.WriteLine($"Score p2: {this._playerTwoScore}");
        }
    }
}