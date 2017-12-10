using System;
using System.IO;
using System.Xml.Serialization;

namespace ExtendedGameOptions   
{
    public class ExtendedGameOptionsSerializable
    {
        private const string optionsFileName = "ExtendedGameOptions_v20171209.xml";

        public bool PauseOnLoad = true;
        public bool EnableAchievements = true;
        public bool InfoViewButtonsAlwaysEnabled = true;
        public bool BasicRoadsAvailableBromStart = true;
        public bool EnableRandomDisastersForScenarios = false;
        public int AreasMaxCount = 25;

        public int OilDepletionRate = 5; // 0 - 10
        public int OreDepletionRate = 5;

        public void Save()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ExtendedGameOptionsSerializable));
            TextWriter writer = new StreamWriter(getOptionsFilePath());
            ser.Serialize(writer, this);
            writer.Close();
        }
        
        public static ExtendedGameOptionsSerializable CreateFromFile()
        {
            string path = getOptionsFilePath();

            if (!File.Exists(path)) return null;

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(ExtendedGameOptionsSerializable));
                TextReader reader = new StreamReader(path);
                ExtendedGameOptionsSerializable instance = (ExtendedGameOptionsSerializable)ser.Deserialize(reader);
                reader.Close();

                return instance;
            }
            catch
            {
                return null;
            }
        }

        private static string getOptionsFilePath()
        {
            //return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Colossal Order", "Cities_Skylines", optionsFileName);
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Colossal Order\\Cities_Skylines\\" + optionsFileName;
        }
    }
}