using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile with its tail stapled to the floor.</para>
    /// <para>The responsibility of Cycle is to move itself.</para>
    /// </summary>
    public class Cycle : Actor
    {
        private List<Actor> _segments = new List<Actor>();
        private Point _currentDirection;

        /// <summary>
        /// Constructs a new instance of a Cycle.
        /// </summary>
        public Cycle(Point startingPoint, Color color)
        {
            PrepareBody(startingPoint, color);
            _currentDirection = new Point(0,1);
        }

        /// <summary>
        /// Gets the Cycle's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(_segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the Cycle's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return _segments[0];
        }

        /// <summary>
        /// Gets the Cycle's segments (including the head).
        /// </summary>
        /// <returns>A list of Cycle segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return _segments;
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            //Add a new segment at the beginning of the list(the head)
            Actor oldHead = GetHead();            
            //--Add this in the direction the pcychol is moving
            //Update the old head to the the # character now
            oldHead.SetText("#");

            int x = (oldHead.GetPosition().GetX() + _currentDirection.GetX() + Constants.MAX_X) % Constants.MAX_X;
            int y = (oldHead.GetPosition().GetY() + _currentDirection.GetY() + Constants.MAX_Y) % Constants.MAX_Y;

            Point position = new Point(x, y);
            Point velocity = new Point(0, 0);
            string text = "@";
            Color color = oldHead.GetColor();

            Actor segment = new Actor();
            segment.SetPosition(position);
            segment.SetVelocity(velocity);
            segment.SetText(text);
            segment.SetColor(color);
            _segments.Insert(0, segment);

        }

        /// <summary>
        /// Turns the head of the Cycle in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
           _currentDirection = direction;
        }

        /// <summary>
        /// Prepares the Cycle body for moving.
        /// </summary>
        private void PrepareBody(Point startingPoint, Color color)
        {            
            Point velocity = new Point(0, 0);
            string text = "@";

            Actor segment = new Actor();
            segment.SetPosition(startingPoint);
            segment.SetVelocity(velocity);
            segment.SetText(text);
            segment.SetColor(color);
            _segments.Add(segment);
        }
    }
}