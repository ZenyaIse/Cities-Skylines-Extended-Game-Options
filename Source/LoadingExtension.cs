using ColossalFramework;
using ICities;

namespace ExtendedGameOptions
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);
            Economy.UpdateInitialMoney();
        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            Achievements.Update();
            InfoViewButtons.Initialize();
        }
    }
}
