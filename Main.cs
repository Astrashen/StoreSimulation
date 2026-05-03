using System;
using DungeonCrawler;
using PlayerInput;
using DrawGame;
using Globals;

class Program
{
    static int selectedIndex = 0;

    static void Main()
    {
        Console.CursorVisible = false;

        MapGeneration.GenerateMap(
            GameGlobals.map,
            GameGlobals.width,
            GameGlobals.height,
            GameGlobals.totalFloors,
            GameGlobals.stairsDown,
            GameGlobals.stairsUp,
            GameGlobals.rng
        );

       while (true)
        {
            switch (GameState.CurrentState)
            {
                case GameStateType.MainMenu:
                    RunMainMenu();
                    break;

                case GameStateType.Playing:
                    RunGame();
                    break;

                case GameStateType.Paused:
                    RunPause();
                    break;

                case GameStateType.GameOver:
                    RunGameOver();
                    break;
            }
        }

    }

    static void RunGame()
    {
        DrawHandler.Draw(
            GameGlobals.width,
            GameGlobals.height,
            GameGlobals.currentFloor,
            GameGlobals.playerX,
            GameGlobals.playerY,
            GameGlobals.map
        );

        InputHandler.HandleInput(
            ref GameGlobals.playerX,
            ref GameGlobals.playerY,
            ref GameGlobals.currentFloor,
            GameGlobals.width,
            GameGlobals.height,
            GameGlobals.map,
            GameGlobals.stairsUp,
            GameGlobals.stairsDown,
            GameGlobals.totalFloors
        );
    }

    static void RunMainMenu()
    {
        
        string[] options = { "Play", "Quit" };

        ConsoleKey key;

        do
        {
            Console.Clear();
            Console.WriteLine("=== Store Simulation ===\n");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"> {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {options[i]}");
                }
            }

            key = Console.ReadKey(true).Key;

            // move selection
            if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length)
                    selectedIndex = 0;
            }

        } while (key != ConsoleKey.Enter);

        // handle selection
        switch (selectedIndex)
        {
            case 0: // Play
                GameState.CurrentState = GameStateType.Playing;
                break;

            case 1: // Quit
                Environment.Exit(0);
                break;
        }
    }

    static void RunGameOver(){}

    static void RunPause(){}
}