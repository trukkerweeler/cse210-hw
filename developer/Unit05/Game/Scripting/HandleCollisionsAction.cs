using System;
using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05;



namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the cycle 
    /// collides with its/other segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool _isGameOver = false;
        

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (_isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
                UpdateScore(cast);
            }
        }

        private void UpdateScore(Cast cast)
        {
            bool _firstCycle = true;
            foreach(Cycle cycle in cast.GetActors("cycles"))
            {
                List<Actor> body = cycle.GetBody();
                if (body.Count % 15 == 0)
                {
                    /* if (_firstCycle)
                    {
                        playerOneScore.AddPoints(1);
                        //playerOneScore.AddPoints(1,"p1");
                        Console.WriteLine($"cycle1");
                    }
                    else
                    {
                        //Console.WriteLine("player2");
                        playerTwoScore.AddPoints(2);
                        //playerTwoScore.AddPoints(2, "p2");
                        Console.WriteLine($"cycle2");

                    } */
                }
                _firstCycle = false;
            }
        }

        /// <summary>
        /// Sets the game over flag if the cycle collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            bool firstCycle = true;
            foreach(Cycle cycle in cast.GetActors("cycles"))
            {
                Actor head = cycle.GetHead();

                foreach(Cycle otherCycle in cast.GetActors("cycles"))
                {
                    List<Actor> body = otherCycle.GetBody();
                    int segmentCount = 0;
                    foreach (Actor segment in body)
                    {
                        segmentCount += 1;
                        if (segment.GetPosition().Equals(head.GetPosition()))
                        {
                            _isGameOver = true;
                            if (firstCycle == true)
                            {
                                //The first cycle has crashed ,deduct points from first cycle.
                                Actor firstActor = cast.GetActors("score")[0];
                                Score firstScore = (Score)firstActor;
                                firstScore.AddPoints(-50);
                            }
                            else
                            {
                                //The second cycle has crashed, deduct points from first cycle.
                                Actor secondActor = cast.GetActors("score")[1];
                                Score secondScore = (Score)secondActor;
                                secondScore.AddPoints(-50);

                            }
                        }
                        /* else
                        {
                            if (_segmentCount % 5 == 0)
                            {
                                //Console.WriteLine($"{segmentCount}");
                                
                            } 
                        } */
                    
                    }

                }  
                firstCycle = false;
                               
            }

        }

        private void HandleGameOver(Cast cast)
        {
            if (_isGameOver == true)
            {
                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                y -= 10;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                foreach(Cycle cycle in cast.GetActors("cycles"))
                {
                    List<Actor> segments = cycle.GetSegments();
                    // make everything white
                    foreach (Actor segment in segments)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                }
            }
        }

    }
}