using System;
using System.Text;

namespace DrawGame
{
    public static class DrawHandler
    {
        public static void Draw(
            Int16 width,
            Int16 height,
            Int16 currentFloor,
            Int16 playerX,
            Int16 playerY,
            char[,,] map)
        {
            Console.SetCursorPosition(0, 0);

            var output = new StringBuilder();

            for (Int16 y = 0; y < height; y++)
            {
                for (Int16 x = 0; x < width; x++)
                {
                    if (x == playerX && y == playerY)
                        output.Append('@');
                    else
                        output.Append(map[x, y, currentFloor]);
                }
                output.AppendLine();
            }

            output.AppendLine($"Floor: {currentFloor}");

            Console.Write(output.ToString());
        }
    }
}