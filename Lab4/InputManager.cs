﻿using System;

namespace Lab4
{
    class InputManager
    {
        public Direction DirectionInput(GameManager gameManager)
        {
            var direction = Direction.None;
            do
            {               
            switch (Console.ReadKey().KeyChar)
            {
                case 'w':
                    return Direction.Upp;
                                       
                case 's':
                    return Direction.Down;
                    
                case 'd':                
                    return Direction.Right;

                case 'a':
                    return Direction.Left;
                    
                default:                    
                    return Direction.None;
            }
            } while (direction == Direction.None);
        }
    }
}
