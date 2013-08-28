using AGENT.Contrib.Hardware;
using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Presentation.Media;

namespace Snake
{
    public class GameOverState : State
    {
        private static GameOverState instance = new GameOverState();
        public static GameOverState Instance { get { return instance; } }

        public override void Init() { }

        public override void ButtonEvent(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time)
        {
            if ((ButtonDirection)Program.ButtonStates[Buttons.MiddleRight] == ButtonDirection.Down)
                Program.StateManager.ChangeState(MainMenuState.Instance);
        }

        public override void TickEvent(object state)
        {
            Program.Display.DrawText("Game Over", Program.fontNinaB, Color.White, 10, 10);
            Program.Display.DrawText("Score: " + GameData.snakedata.size.ToString(), Program.fontNinaB, Color.White, 10, 30);
        }
    }
}
