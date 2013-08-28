using AGENT.Contrib.Hardware;
using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Presentation.Media;

namespace Snake
{
    public class MainMenuState : State
    {
        private static MainMenuState instance = new MainMenuState();
        public static MainMenuState Instance { get { return instance; } }

        public override void Init() { }

        public override void ButtonEvent(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time)
        {
            if ((ButtonDirection)Program.ButtonStates[Buttons.MiddleRight] == ButtonDirection.Down)
                Program.StateManager.ChangeState(PlayState.Instance);
        }

        public override void TickEvent(object state)
        {
            Program.Display.DrawText("Press middle", Program.fontNinaB, Color.White, 10, 10);
            Program.Display.DrawText("btn to play", Program.fontNinaB, Color.White, 10, 30);
        }
    }
}
