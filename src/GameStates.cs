namespace DungeonCrawler
{
    public enum GameStateType
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    public static class GameState
    {
        public static GameStateType CurrentState = GameStateType.MainMenu;
    }
}


