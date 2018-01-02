using ColossalFramework;
using ICities;
using System.Text;
using UnityEngine;

namespace ExtendedGameOptions
{
    public class Milestones : MilestonesExtensionBase
    {
        //private static void Init()
        //{
        //    UnlockController uc = Object.FindObjectOfType<UnlockController>();

        //    if (uc != null)
        //    {
        //        MilestoneInfo[] mi = uc.m_progressionMilestones;
        //        int milestoneCount = mi.Length;

        //        milestoneNames = new string[milestoneCount];
        //        milestoneLocalizedNames = new string[milestoneCount];

        //        for (int i = 0; i < milestoneCount; i++)
        //        {
        //            milestoneNames[i] = mi[i].name;
        //            milestoneLocalizedNames[i] = mi[i].GetLocalizedName();
        //        }
        //    }
        //}

        public static string[] MilestoneLocalizedNames = new string[]
        {
            "Little Hamlet",
            "Worthy Village",
            "Tiny Town",
            "Boom Town",
            "Busy Town",
            "Big Town",
            "Small City",
            "Big City",
            "Grand City",
            "Capital City",
            "Colossal City",
            "Metropolis",
            "Megalopolis"
        };

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

            if (o.UnlockMilestone)
            {
                milestonesManager.UnlockMilestone("Milestone" + o.UnlockMilestoneIndex.ToString());
            }
        }
    }
}
