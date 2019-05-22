using ColossalFramework;

namespace ExtendedGameOptions
{
    public static class Achievements
    {
        public static void Update()
        {
            if (Singleton<SimulationManager>.exists)
            {
                SimulationMetaData.MetaBool newValue = Singleton<ExtendedGameOptionsManager>.instance.values.EnableAchievements
                    ? SimulationMetaData.MetaBool.True
                    : SimulationMetaData.MetaBool.False;

                Singleton<SimulationManager>.instance.m_metaData.m_disableAchievements = newValue;
            }
        }
    }
}
