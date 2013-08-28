using AGENT.Contrib.Hardware;
using System;
using System.Collections;
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
            GameData.snakedata.size = GameData.INITAL_SIZE;
            GameData.snakedata.headlocation.x = GameData.START_X;
            GameData.snakedata.headlocation.y = GameData.START_Y;
            GameData.snakedata.direction = GameData.Direction.Up;
            GameData.snakedata.snakeq = new Queue();

            for (int i = GameData.INITAL_SIZE - 1; i >= 0; i--)
                GameData.snakedata.snakeq.Enqueue(new GameData.Coordinate() { x = GameData.START_X, y = GameData.START_Y + i });

            GameData.applelocation.x = 15;
            GameData.applelocation.y = 12;
        }

        public override void ButtonEvent(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time)
        {
            if ((ButtonDirection)Program.ButtonStates[Buttons.BottomRight] == ButtonDirection.Down)
            {
                switch (GameData.snakedata.direction)
                {
                    case GameData.Direction.Up:
                        GameData.snakedata.direction = GameData.Direction.Right;
                        break;
                    case GameData.Direction.Down:
                        GameData.snakedata.direction = GameData.Direction.Left;
                        break;
                    case GameData.Direction.Left:
                        GameData.snakedata.direction = GameData.Direction.Up;
                        break;
                    case GameData.Direction.Right:
                        GameData.snakedata.direction = GameData.Direction.Down;
                        break;
                    default:
                        throw new Exception("Unknown direction for snake");
                }
            }
            else if ((ButtonDirection)Program.ButtonStates[Buttons.TopRight] == ButtonDirection.Down)
            {
                switch (GameData.snakedata.direction)
                {
                    case GameData.Direction.Up:
                        GameData.snakedata.direction = GameData.Direction.Left;
                        break;
                    case GameData.Direction.Down:
                        GameData.snakedata.direction = GameData.Direction.Right;
                        break;
                    case GameData.Direction.Left:
                        GameData.snakedata.direction = GameData.Direction.Down;
                        break;
                    case GameData.Direction.Right:
                        GameData.snakedata.direction = GameData.Direction.Up;
                        break;
                    default:
                        throw new Exception("Unknown direction for snake");
                }
            }
        }

        public override void TickEvent(object state)
        {
            MoveSnake();
            CheckCollisions();
            DrawGame();
        }

        private void MoveSnake()
        {
            switch (GameData.snakedata.direction)
            {
                case GameData.Direction.Up:
                    GameData.snakedata.headlocation.y--;
                    break;
                case GameData.Direction.Down:
                    GameData.snakedata.headlocation.y++;
                    break;
                case GameData.Direction.Left:
                    GameData.snakedata.headlocation.x--;
                    break;
                case GameData.Direction.Right:
                    GameData.snakedata.headlocation.x++;
                    break;
                default:
                    throw new Exception("Invalid direction");
            }

            GameData.snakedata.snakeq.Enqueue(new GameData.Coordinate()
            {
                x = GameData.snakedata.headlocation.x,
                y = GameData.snakedata.headlocation.y
            });
        }

        private void CheckCollisions()
        {
            if (GameData.snakedata.headlocation.x == GameData.applelocation.x
                && GameData.snakedata.headlocation.y == GameData.applelocation.y)
            {
                GameData.snakedata.size++;
                GameData.applelocation.x = new Random().Next(32);
                GameData.applelocation.y = new Random().Next(32);
            }
            else
            {
                GameData.snakedata.snakeq.Dequeue();
            }

            if (GameData.snakedata.headlocation.x > 31 || GameData.snakedata.headlocation.x < 0
                || GameData.snakedata.headlocation.y > 31 || GameData.snakedata.headlocation.y < 0)
                Program.StateManager.ChangeState(GameOverState.Instance);

            int i = 0;
            IEnumerator snakeenum = GameData.snakedata.snakeq.GetEnumerator();
            while (snakeenum.MoveNext())
            {
                if (i == GameData.snakedata.snakeq.Count - 1)
                    break;

                if (GameData.snakedata.headlocation.x == ((GameData.Coordinate)snakeenum.Current).x
                    && GameData.snakedata.headlocation.y == ((GameData.Coordinate)snakeenum.Current).y)
                    Program.StateManager.ChangeState(GameOverState.Instance);

                i++;
            }
        }

        private void DrawGame()
        {
            IEnumerator snakeenum = GameData.snakedata.snakeq.GetEnumerator();

            while (snakeenum.MoveNext())
            {
                Program.Display.DrawRectangle(Color.White,
                                              1,
                                              ((GameData.Coordinate)snakeenum.Current).x * GameData.BLOCK_SIZE,
                                              ((GameData.Coordinate)snakeenum.Current).y * GameData.BLOCK_SIZE,
                                              GameData.BLOCK_SIZE,
                                              GameData.BLOCK_SIZE,
                                              0,
                                              0,
                                              Color.White,
                                              0,
                                              0,
                                              Color.White,
                                              0,
                                              0,
                                              255);
            }

            Program.Display.DrawRectangle(Color.White,
                                          1,
                                          GameData.applelocation.x * GameData.BLOCK_SIZE,
                                          GameData.applelocation.y * GameData.BLOCK_SIZE,
                                          GameData.BLOCK_SIZE,
                                          GameData.BLOCK_SIZE,
                                          0,
                                          0,
                                          Color.White,
                                          0,
                                          0,
                                          Color.White,
                                          0,
                                          0,
                                          0);
        }
    }
}
