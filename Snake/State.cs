using AGENT.Contrib.Hardware;
using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Presentation.Media;

namespace Snake
{
    public class State
    {
        private bool tickvisualiser;

        public virtual void Init()
        {
            tickvisualiser = true;
        }

        public virtual void ButtonEvent(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time) { }

        public virtual void TickEvent(object state)
        {
            if (tickvisualiser)
                Program.Display.DrawLine(Color.White, 1, 126, 0, 127, 1);
            else
                Program.Display.DrawLine(Color.White, 1, 126, 1, 127, 0);

            tickvisualiser = !tickvisualiser;

            Program.Display.Flush();
        }
    }
}
