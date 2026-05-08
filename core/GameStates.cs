namespace DungeonCrawler
{
    public enum GameStateType
    {
        MainMenu,
        PlayerCreation, // Add this!
        Playing,
        Paused,
        GameOver
    }

    public enum PlayerCreationState
    {
        PlayerCreation, // This acts as the "Top Menu" for creation
        NameSelection,
        StatsSelection,
    }

    public static class GameState
    {
        public static GameStateType CurrentState = GameStateType.MainMenu;
    }

    public static class CreationState
    {
         public static PlayerCreationState CurrentState = PlayerCreationState.PlayerCreation;
    }
}