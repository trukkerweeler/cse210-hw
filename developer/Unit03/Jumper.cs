using System.Collections.Generic;

namespace Unit03
{
    /// <summary>
    /// <para>Jumper object</para>
    /// <para>
    public class Jumper
    {
        ///private int _remainingGuesses;
        private List<string> _parachute = new List<string>();
        
        public Jumper()
        {
            jump();
        }

        public void jump()
        {
            _parachute.Clear();
            _parachute.Add("  __");
            _parachute.Add(" /__\\");
            _parachute.Add(" \\  /");
            _parachute.Add("  \\ /");
            _parachute.Add("   O");
            _parachute.Add("  /|\\");            
            _parachute.Add("  / \\");
        }        

        public void Update()
        {
            TerminalService.WriteList(_parachute);
        }

        public void CutRope()
        {
            if (_parachute.Count > 3)
            {
                _parachute.RemoveAt(0);
            }
           if (_parachute.Count == 3)
            {
                _parachute[0] = "  X";
            }
            Update();
        }

        public bool IsAlive()
        {
            return _parachute.Count > 3;
        }

    }
}