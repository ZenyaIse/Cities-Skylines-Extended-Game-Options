using ICities;
using ColossalFramework;

namespace ExtendedGameOptions
{
    public class Areas : AreasExtensionBase
    {
        private static IAreas areasObj;

        public override void OnCreated(IAreas areas)
        {
            areasObj = areas;
            areas.maxAreaCount = Singleton<ExtendedGameOptionsManager>.instance.values.AreasMaxCount;
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
            if (areasObj != null)
            {
                areasObj.maxAreaCount = Singleton<ExtendedGameOptionsManager>.instance.values.AreasMaxCount;
            }
        }
    }
}
