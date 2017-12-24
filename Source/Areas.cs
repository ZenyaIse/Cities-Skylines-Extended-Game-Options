using ICities;
using ColossalFramework;

namespace ExtendedGameOptions
{
    public class Areas : AreasExtensionBase
    {
        private static IAreas areasObj;
        private static int oldAreasMaxCount = 9;

        public override void OnCreated(IAreas areas)
        {
            areasObj = areas;
            oldAreasMaxCount = areas.maxAreaCount;
            Update();
        }

        public static string[] GetAvailableValuesStr()
        {
            string[] values = new string[25];

            for (int i = 1; i <= 25; i++)
            {
                values[i - 1] = i.ToString();
            }

            return values;
        }

        public static void Update()
        {
            if (!Singleton<ExtendedGameOptionsManager>.instance.values.EnableAreasMaxCountOption) return;

            if (areasObj != null)
            {
                areasObj.maxAreaCount = Singleton<ExtendedGameOptionsManager>.instance.values.AreasMaxCount;
            }
        }

        public static void Reset()
        {
            if (areasObj != null)
            {
                areasObj.maxAreaCount = oldAreasMaxCount;
            }
        }
    }
}
