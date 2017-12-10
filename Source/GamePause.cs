using ColossalFramework;

namespace ExtendedGameOptions
{
    public static class GamePause
    {
        public static void OnGameLoaded()
        {
            if (Singleton<ExtendedGameOptionsManager>.instance.values.PauseOnLoad)
            {
                SetPause();
            }
        }

        public static void SetPause()
        {
            if (Singleton<SimulationManager>.exists)
            {
                Singleton<SimulationManager>.instance.SimulationPaused = true;
            }
        }
    }
}
