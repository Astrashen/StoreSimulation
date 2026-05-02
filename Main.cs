using System;
using DungeonCrawler;
using PlayerInput;
using DrawGame;
using Globals;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        MapGeneration.GenerateMap(
            GameState.map,
            GameState.width,
            GameState.height,
            GameState.totalFloors,
            GameState.stairsDown,
            GameState.stairsUp,
            GameState.rng
        );

        while (true)
        {
            DrawHandler.Draw(
                GameState.width,
                GameState.height,
                GameState.currentFloor,
                GameState.playerX,
                GameState.playerY,
                GameState.map
            );

            InputHandler.HandleInput(
                ref GameState.playerX,
                ref GameState.playerY,
                ref GameState.currentFloor,
                GameState.width,
                GameState.height,
                GameState.map,
                GameState.stairsUp,
                GameState.stairsDown,
                GameState.totalFloors
            );
        }
    }
}