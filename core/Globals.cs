using System;

namespace Globals
{
    public class Enemy
    {
        public string EnemyName { get; set; } = "Unknown";

        // Core Ability Scores
        public Int16 STR { get; set; }
        public Int16 DEX { get; set; }
        public Int16 CON { get; set; }
        public Int16 INT { get; set; }
        public Int16 WIS { get; set; }
        public Int16 CHA { get; set; }

        // 3.5 Specific Combat Stats
        public Int16 HitPoints { get; set; }
        public Int16 ArmorClass { get; set; }
        public Int16 TouchAC { get; set; }
        public Int16 FlatFootedAC { get; set; }
        public Int16 Initiative { get; set; }
        public Int16 BaseAttackBonus { get; set; }
        public Int16 GrappleModifier { get; set; }
        public Int16 Speed { get; set; }

        // Saving Throws
        public Int16 Fortitude { get; set; }
        public Int16 Reflex { get; set; }
        public Int16 Will { get; set; }

        // Utility
        public Int16 SpellResistance { get; set; }
        public string DamageReduction { get; set; } = "None";

        // Map Position
        public Int16 X { get; set; }
        public Int16 Y { get; set; }

        // ADDED: Empty Constructor (Required for JSON Loading to work)
        public Enemy() { }

        // ORIGINAL: Your standard Constructor
        public Enemy(string name, string damageReduction)
        {
            EnemyName = name;
            DamageReduction = damageReduction;
        }
    }

    public class Players
    {
        public string PlayerName { get; set; } = "Hero";

        // Core Ability Scores
        public Int16 STR { get; set; }
        public Int16 DEX { get; set; }
        public Int16 CON { get; set; }
        public Int16 INT { get; set; }
        public Int16 WIS { get; set; }
        public Int16 CHA { get; set; }

        // 3.5 Specific Combat Stats
        public Int16 HitPoints { get; set; }
        public Int16 ArmorClass { get; set; }
        public Int16 TouchAC { get; set; }
        public Int16 FlatFootedAC { get; set; }
        public Int16 Initiative { get; set; }
        public Int16 BaseAttackBonus { get; set; }
        public Int16 GrappleModifier { get; set; }
        public Int16 Speed { get; set; }

        // Saving Throws
        public Int16 Fortitude { get; set; }
        public Int16 Reflex { get; set; }
        public Int16 Will { get; set; }

        // Utility
        public Int16 SpellResistance { get; set; }
        public string DamageReduction { get; set; } = "None";

        // 1. ADDED: Empty Constructor (Required for JSON Loading to work)
        public Players() { }

        // 2. ORIGINAL: Your standard Constructor
        public Players(string name, string damageReduction)
        {
            PlayerName = name;
            DamageReduction = damageReduction;
        }
    }

    public static class GameGlobals
    {
        public static Int16 originalparty = 1;
        public static Int16 currentparty;
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

    public static class PlayerEntity
    {
        public static Players MainPlayer = new Players("Default", "None");
        public static Players Party2 = new Players("Default", "None");
        public static Players Party3 = new Players("Default", "None");
        public static Players Party4 = new Players("Default", "None");
    }

    public static class EnemyEntity
    {
        public static Enemy MainEnemie = new Enemy("Default", "None");
    }
}