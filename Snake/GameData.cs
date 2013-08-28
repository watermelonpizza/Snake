using System;
using Microsoft.SPOT;

namespace Snake
{
    public static class GameData
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        };

        public static Direction SnakeDirection { get; set; }
    }
}
