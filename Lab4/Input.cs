using System;

namespace Lab4
{
    class Input
    {
        public Direction DirectionInput(GameManager gameManager)
        {
            var direction = Direction.None;
            do
            {               
                Console.SetCursorPosition(gameManager.Player.Location.row,gameManager.Player.Location.column);
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
        } // adda eventuellt hjälpmedelande om man trycker fel för None
    }
}
