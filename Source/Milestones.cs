using ColossalFramework;
using ICities;

namespace ExtendedGameOptions
{
    public class Milestones : MilestonesExtensionBase
    {
        public override void OnRefreshMilestones()
        {
            if (Singleton<ExtendedGameOptionsManager>.instance.values.BasicRoadsAvailableBromStart)
            {
                milestonesManager.UnlockMilestone("Basic Road Created");
            }
        }
    }
}
