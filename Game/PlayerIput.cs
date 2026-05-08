using System;
using Globals; 

namespace PlayerInput
{
    public static class InputHandler
    {
        public static void HandleInput(
            ref Int16 playerX,
            ref Int16 playerY,
            ref Int16 currentFloor,
            Int16 width,
            Int16 height,
            char[,,] map,
            (Int16 x, Int16 y)[] stairsUp,
            (Int16 x, Int16 y)[] stairsDown,
            Int16 totalFloors)
        {
            var key = Console.ReadKey(true).Key;

            Int16 newX = playerX;
            Int16 newY = playerY;

            switch (key)
            {
                case ConsoleKey.W: newY--; break;
                case ConsoleKey.S: newY++; break;
                case ConsoleKey.A: newX--; break;
                case ConsoleKey.D: newX++; break;
                
                case ConsoleKey.P: 
                    DungeonCrawler.GameState.CurrentState = DungeonCrawler.GameStateType.Paused; 
                    return; 
            }
            //collision
            if (newX >= 0 && newX < width &&
                newY >= 0 && newY < height &&
                map[newX, newY, currentFloor] != '#')
            {
                playerX = newX;
                playerY = newY;
            }

            // stairs
            char tile = map[playerX, playerY, currentFloor];

            if (tile == '>' && currentFloor < totalFloors - 1)
            {
                currentFloor++;
                // Moving down usually lands you on the 'Up' stairs of the next floor
                playerX = stairsUp[currentFloor].x;
                playerY = stairsUp[currentFloor].y;
            }
            else if (tile == '<' && currentFloor > 0)
            {
                currentFloor--;
                // Moving up usually lands you on the 'Down' stairs of the previous floor
                playerX = stairsDown[currentFloor].x;
                playerY = stairsDown[currentFloor].y;
            }
        }
    }
}