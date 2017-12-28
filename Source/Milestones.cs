using ColossalFramework;
using ICities;

namespace ExtendedGameOptions
{
    public class Milestones : MilestonesExtensionBase
    {
        public override void OnRefreshMilestones()
        {
            ExtendedGameOptionsSerializable o = Singleton<ExtendedGameOptionsManager>.instance.values;

            if (o.BasicRoadsAvailableBromStart)
            {
                milestonesManager.UnlockMilestone("Basic Road Created");
            }

            if (o.TrainTrackUnlock)
            {
                milestonesManager.UnlockMilestone("Train Track Requirements");
            }

            if (o.MetroTrackUnlock)
            {
                milestonesManager.UnlockMilestone("Metro Track Requirements");
            }
        }
    }
}
