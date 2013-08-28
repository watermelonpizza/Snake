using AGENT.Contrib.Hardware;
using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Presentation.Media;

namespace Snake
{
    public class State
    {
        private bool tickVisualiser;

        public virtual void Init() 
        {
            tickVisualiser = true;
        }

        public virtual void ButtonEvent(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time) { }

        public virtual void TickEvent(object state)
        {
            if (tickVisualiser)
                Program.Display.DrawLine(Color.White, 1, 126, 0, 127, 1);
            else
                Program.Display.DrawLine(Color.White, 1, 126, 1, 127, 0);

            tickVisualiser = !tickVisualiser;

            Program.Display.Flush();
        }
    }
}
