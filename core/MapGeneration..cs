using System;

namespace DungeonCrawler
{
    public static class MapGeneration
    {
        public static void GenerateMap(
            char[,,] map,
            Int16 width,
            Int16 height,
            Int16 totalFloors,
            (Int16 x, Int16 y)[] stairsDown,
            (Int16 x, Int16 y)[] stairsUp,
            Random rng)
        {
            for (Int16 f = 0; f < totalFloors; f++)
            {
                for (Int16 x = 0; x < width; x++)
                for (Int16 y = 0; y < height; y++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                        map[x, y, f] = '#';
                    else
                        map[x, y, f] = ' ';
                }

                Int16 dx = (short)rng.Next(1, width - 1);
                Int16 dy = (short)rng.Next(1, height - 1);
                map[dx, dy, f] = '>';
                stairsDown[f] = (dx, dy);

                Int16 ux = (short)rng.Next(1, width - 1);
                Int16 uy = (short)rng.Next(1, height - 1);
                map[ux, uy, f] = '<';
                stairsUp[f] = (ux, uy);
            }

            // remove invalid stairs
            map[stairsUp[0].x, stairsUp[0].y, 0] = ' ';
            map[stairsDown[totalFloors - 1].x, stairsDown[totalFloors - 1].y, totalFloors - 1] = ' ';
        }
    }
}