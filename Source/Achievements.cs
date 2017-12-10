using ColossalFramework;

namespace ExtendedGameOptions
{
    public static class Achievements
    {
        public static void Update()
        {
            if (!Singleton<ExtendedGameOptionsManager>.instance.values.EnableAchievements) return;

            if (Singleton<SimulationManager>.exists)
            {
                Singleton<SimulationManager>.instance.m_metaData.m_disableAchievements = SimulationMetaData.MetaBool.False;
            }
        }
    }
}
