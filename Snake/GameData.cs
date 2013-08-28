using System;
using System.Collections;

namespace Snake
{
    public static class GameData
    {
        public const int INITAL_SIZE = 5;
        public const int BLOCK_SIZE = 4;
        public const int START_X = 4;
        public const int START_Y = 6;
        
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        };

        public struct Coordinate
        {
            public int x, y;
        } 
        

        public struct Snake
        {
            public Direction direction;
            public Coordinate headlocation;
            public int size;
            public Queue snakeq;
        }

        public static Snake snakedata = new Snake();
        public static Coordinate applelocation = new Coordinate();
    }
}
