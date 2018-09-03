using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace ExtendedGameOptions   
{
    public class ExtendedGameOptionsSerializable
    {
        private const string optionsFileName = "ExtendedGameOptions.xml";

        public bool PauseOnLoad = true;
        public bool EnableAchievements = true;
        public bool InfoViewButtonsAlwaysEnabled = true;

        // Basic unlocks
        public bool BasicRoadsAvailableBromStart = true;
        public bool TrainTrackUnlock = true;
        public bool MetroTrackUnlock = true;

        public bool EnableRandomDisastersForScenarios = false;
        public bool EnableAreasMaxCountOption = true;
        public int AreasMaxCount = 25;

        public int OilDepletionRate = 5; // 0 - 10
        public int OreDepletionRate = 5;

        public bool UnlockMilestone = false;
        public int UnlockMilestoneIndex = 13; // 13 - Megalopolis (unlock all)

        public bool FullRefund = true;

        public void Save()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ExtendedGameOptionsSerializable));
            try
            {
                TextWriter writer = new StreamWriter(getOptionsFilePath());
                ser.Serialize(writer, this);
                writer.Close();
                Debug.Log("ExtendedGameOptionsMod: Options file is saved.");
            }
            catch
            {
                Debug.Log("ExtendedGameOptionsMod: Could not write options file.");
            }
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
                Debug.Log("ExtendedGameOptionsMod: Error reading options file.");
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