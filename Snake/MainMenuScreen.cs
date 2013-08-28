using AGENT.Contrib.Hardware;
using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Presentation.Media;

namespace Snake
{
    public class MainMenuScreen : State
    {
        private static MainMenuScreen instance = new MainMenuScreen();
        public static MainMenuScreen Instance { get { return instance; } }

        public override void Init() { }

        public override void ButtonEvent(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time)
        {
            if ((ButtonDirection)Program.ButtonStates[Buttons.MiddleRight] == ButtonDirection.Down)
                Program.StateManager.ChangeState(PlayState.Instance);
        }

        public override void TickEvent(object state)
        {
            Program.Display.DrawText("MainMenu", Program.fontNinaB, Color.White, 50, 50);
        }
    }
}
