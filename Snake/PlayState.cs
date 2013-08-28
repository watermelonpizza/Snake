using AGENT.Contrib.Hardware;
using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Presentation.Media;

namespace Snake
{
    public class PlayState : State
    {
        private static PlayState instance = new PlayState();
        public static PlayState Instance { get { return instance; } }

        public override void Init()
        {
            Program.Display.DrawText("MainMenu", Program.fontNinaB, Color.White, 50, 50);
            base.Init();
        }

        public override void ButtonEvent(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time)
        {
            if ((ButtonDirection)Program.ButtonStates[Buttons.BottomRight] == ButtonDirection.Down)
            {
                switch (GameData.SnakeDirection)
                {
                    case GameData.Direction.Up:
                        GameData.SnakeDirection = GameData.Direction.Right;
                        break;
                    case GameData.Direction.Down:
                        GameData.SnakeDirection = GameData.Direction.Left;
                        break;
                    case GameData.Direction.Left:
                        GameData.SnakeDirection = GameData.Direction.Up;
                        break;
                    case GameData.Direction.Right:
                        GameData.SnakeDirection = GameData.Direction.Down;
                        break;
                    default:
                        break;
                }
            }
            else if ((ButtonDirection)Program.ButtonStates[Buttons.TopRight] == ButtonDirection.Down)
            {
                switch (GameData.SnakeDirection)
                {
                    case GameData.Direction.Up:
                        GameData.SnakeDirection = GameData.Direction.Left;
                        break;
                    case GameData.Direction.Down:
                        GameData.SnakeDirection = GameData.Direction.Right;
                        break;
                    case GameData.Direction.Left:
                        GameData.SnakeDirection = GameData.Direction.Down;
                        break;
                    case GameData.Direction.Right:
                        GameData.SnakeDirection = GameData.Direction.Up;
                        break;
                    default:
                        break;
                }
            }
        }

        public override void TickEvent(object state)
        {

        }
    }
}
