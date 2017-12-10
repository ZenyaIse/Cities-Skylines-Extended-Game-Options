using ColossalFramework;

namespace ExtendedGameOptions
{
    public class ExtendedGameOptionsManager : Singleton<ExtendedGameOptionsManager>
    {
        public ExtendedGameOptionsSerializable values;

        private ExtendedGameOptionsManager()
        {
            values = ExtendedGameOptionsSerializable.CreateFromFile();

            if (values == null)
            {
                values = new ExtendedGameOptionsSerializable();
            }
        }

        public void Save()
        {
            values.Save();
        }
    }
}
