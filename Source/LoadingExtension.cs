using ICities;

namespace ExtendedGameOptions
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            Achievements.Update();

            if (mode == LoadMode.NewGame || mode == LoadMode.LoadGame || mode == LoadMode.NewGameFromScenario)
            {
                InfoViewButtons.Initialize();
            }
        }
    }
}
