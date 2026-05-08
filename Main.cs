using System;
using DungeonCrawler;
using PlayerInput;
using DrawGame;
using DrawMenu;
using Globals;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        // Initialize Map
        MapGeneration.GenerateMap(
            GameGlobals.map,
            GameGlobals.width,
            GameGlobals.height,
            GameGlobals.totalFloors,
            GameGlobals.stairsDown,
            GameGlobals.stairsUp,
            GameGlobals.rng
        );

        // The Main Game Loop
        while (true)
        {
            switch (GameState.CurrentState)
            {
                case GameStateType.MainMenu:
                    RunMainMenu();
                    break;

                case GameStateType.PlayerCreation:
                    // When the game is in "Creation Mode", we run the sub-flow
                    HandlePlayerCreationFlow();
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

    static void HandlePlayerCreationFlow()
    {
        // This switch looks at your second Enum (PlayerCreationState)
        switch (CreationState.CurrentState)
        {
            case PlayerCreationState.PlayerCreation:
                RunPlayerCreationMenu();
                break;

            case PlayerCreationState.NameSelection:
                NameSelection();
                break;

            case PlayerCreationState.StatsSelection:
                StatsSelection();
                break;
        }
    }

    static void RunMainMenu()
    {
        string[] options = { "New Game", "Load Game","Delete Game", "Quit" };
        int choice = MenuUI.DrawMenu("Store Simulation", options);

        switch (choice)
        {
            case 0: // New Game
                GameState.CurrentState = GameStateType.PlayerCreation;
                break;
            case 1: // Load Game
                SaveSystem.LoadPlayers();
                GameState.CurrentState = GameStateType.Playing;
                break;
            case 2:
                SaveSystem.DeleteSave();
                GameState.CurrentState = GameStateType.MainMenu;
                Console.Clear();
                break;
            case 3:
                Environment.Exit(0);
                break;
        }
    }

    static void RunPlayerCreationMenu()
    {
        string[] options = { "Set Name", "Set Stats", "Start Game", "Back to Main Menu" };
        int choice = MenuUI.DrawMenu("Character Creation", options);

        switch (choice)
        {
            case 0:
                CreationState.CurrentState = PlayerCreationState.NameSelection;
                break;
            case 1:
                CreationState.CurrentState = PlayerCreationState.StatsSelection;
                break;
            case 2:
                // Finalize creation
                GameState.CurrentState = GameStateType.Playing;
                
                // SAVE HERE: Now that the character is done, commit it to disk
                SaveSystem.SavePlayers(); 
                break;
            case 3:
                GameState.CurrentState = GameStateType.MainMenu;
                Console.Clear();
                break;
        }
    }

    static void NameSelection()
    {
        Console.Clear();
        Console.WriteLine("=== Name Selection ===");
        Console.Write("Enter your character's name: ");
        PlayerEntity.MainPlayer.PlayerName = Console.ReadLine() ?? "Hero";
        CreationState.CurrentState = PlayerCreationState.PlayerCreation;
        Console.Clear();
    }

    static void StatsSelection()
    {
        bool assigning = true;

        while (assigning)
        {
            // We include current values in the labels so the user sees progress
            string[] options = { 
                $"STR =({PlayerEntity.MainPlayer.STR})", 
                $"DEX =({PlayerEntity.MainPlayer.DEX})", 
                $"CON =({PlayerEntity.MainPlayer.CON})", 
                $"INT =({PlayerEntity.MainPlayer.INT})", 
                $"WIS =({PlayerEntity.MainPlayer.WIS})", 
                $"CHA =({PlayerEntity.MainPlayer.CHA})", 
                "Finished" 
            };

            int choice = MenuUI.DrawPlayerCreationMenu("Stats Selection", options);

            switch (choice)
            {
                case 0: PlayerEntity.MainPlayer.STR++; break;
                case 1: PlayerEntity.MainPlayer.DEX++; break;
                case 2: PlayerEntity.MainPlayer.CON++; break;
                case 3: PlayerEntity.MainPlayer.INT++; break;
                case 4: PlayerEntity.MainPlayer.WIS++; break;
                case 5: PlayerEntity.MainPlayer.CHA++; break;
                case 6: // "Finished"
                    assigning = false; // Break the loop
                    Console.Clear();
                    break;
            }
        }

        // ONLY move back to the main creation menu when the loop is finished
        CreationState.CurrentState = PlayerCreationState.PlayerCreation;
    }

    static void RunGame()
    {
        DrawHandler.Draw(
            GameGlobals.width, GameGlobals.height, GameGlobals.currentFloor,
            GameGlobals.playerX, GameGlobals.playerY, GameGlobals.map
        );

        InputHandler.HandleInput(
            ref GameGlobals.playerX, ref GameGlobals.playerY, ref GameGlobals.currentFloor,
            GameGlobals.width, GameGlobals.height, GameGlobals.map,
            GameGlobals.stairsUp, GameGlobals.stairsDown, GameGlobals.totalFloors
        );
        
    }

    static void RunPause()
    {
        string[] options = { "Resume", "Save Game", "Main Menu" };
        int choice = MenuUI.DrawMenu("Paused", options);
        
        switch (choice)
        {
            case 0:
                GameState.CurrentState = GameStateType.Playing;
                break;
            case 1:
                SaveSystem.SavePlayers();
                GameState.CurrentState = GameStateType.Paused; 
                Console.Clear();
                break;
            case 2:
                GameState.CurrentState = GameStateType.MainMenu;
                Console.Clear();
                break;
        }
    }

    static void RunGameOver()
    {
        string[] options = { "Try Again", "Quit" };
        int choice = MenuUI.DrawMenu("You Died!", options);
        GameState.CurrentState = (choice == 0) ? GameStateType.MainMenu : GameStateType.MainMenu;
        if (choice == 1) Environment.Exit(0);
    }
}