using ICities;

namespace ExtendedGameOptions
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            if (mode == LoadMode.NewGame || mode == LoadMode.LoadGame || mode == LoadMode.NewGameFromScenario)
            {
                Achievements.Update();
                GamePause.OnGameLoaded();
                InfoViewButtons.Initialize();
            }
        }
    }
}
