using System.ComponentModel;

namespace Globals
{
    public static class GameGlobals
    {
        

        public static Int16 party = 4;
        public static Int16 width = 40;
        public static Int16 height = 20;

        public static Int16 totalFloors = 3;
        public static Int16 currentFloor = 0;

        public static char[,,] map = new char[40, 20, 3];

        public static Int16 playerX = 5;
        public static Int16 playerY = 5;

        public static (Int16 x, Int16 y)[] stairsDown = new (Int16, Int16)[3];
        public static (Int16 x, Int16 y)[] stairsUp = new (Int16, Int16)[3];

        public static Random rng = new Random();
        
    }
}