using ICities;
using ColossalFramework;
using UnityEngine;
using System;

namespace ExtendedGameOptions
{
    public class Mod : IUserMod
    {
        public string Name
        {
            get { return "Extended Game Options"; }
        }

        public string Description
        {
            get { return "More game options (2017/12/10)"; }
        }

        #region Options UI

        public void OnSettingsUI(UIHelperBase helper)
        {
            ExtendedGameOptionsSerializable o = Singleton<ExtendedGameOptionsManager>.instance.values;

            helper.AddCheckbox("Set pause when the game is loaded", o.PauseOnLoad, PauseOnLoadChanged);
            helper.AddCheckbox("Enable achievements", o.EnableAchievements, EnabledAchievementsChanged);
            helper.AddCheckbox("Info View buttons are always enabled", o.InfoViewButtonsAlwaysEnabled, InfoViewButtonsAlwaysEnabledChanged);
            helper.AddCheckbox("Basic roads are available from the start", o.BasicRoadsAvailableBromStart, BasicRoadsAvailableBromStartChanged);
            if (SteamHelper.IsDLCOwned(SteamHelper.DLC.NaturalDisastersDLC))
            {
                helper.AddCheckbox("Enable random disasters for scenarios", o.EnableRandomDisastersForScenarios, EnableRandomDisastersForScenariosChanged);
            }
            helper.AddDropdown("Available areas", Areas.GetAvailableValuesStr(), o.AreasMaxCount - 1, AreasMaxCountChanged);

            helper.AddSpace(20);

            UIHelperBase resourcesHelper = helper.AddGroup("Resources depletion rate (move to the left for unlimited)");
            resourcesHelper.AddSlider("Oil depletion rate", 0, 10, 1, o.OilDepletionRate, OilDepletionRateChanged);
            resourcesHelper.AddSlider("Ore depletion rate", 0, 10, 1, o.OreDepletionRate, OreDepletionRateChanged);

            helper.AddSpace(20);

            helper.AddButton("Save", SaveBtnClicked);
        }

        private void PauseOnLoadChanged(bool isChecked)
        {
            Singleton<ExtendedGameOptionsManager>.instance.values.PauseOnLoad = isChecked;
        }

        private void EnabledAchievementsChanged(bool isChecked)
        {
            Singleton<ExtendedGameOptionsManager>.instance.values.EnableAchievements = isChecked;
            Achievements.Update();
        }

        private void InfoViewButtonsAlwaysEnabledChanged(bool isChecked)
        {
            Singleton<ExtendedGameOptionsManager>.instance.values.InfoViewButtonsAlwaysEnabled = isChecked;
        }

        private void BasicRoadsAvailableBromStartChanged(bool isChecked)
        {
            Singleton<ExtendedGameOptionsManager>.instance.values.BasicRoadsAvailableBromStart = isChecked;
        }

        private void EnableRandomDisastersForScenariosChanged(bool isChecked)
        {
            Singleton<ExtendedGameOptionsManager>.instance.values.EnableRandomDisastersForScenarios = isChecked;
            //OptionsGameplayPanel optionsGameplayPanel = Object.FindObjectOfType<OptionsGameplayPanel>();
        }

        private void AreasMaxCountChanged(int sel)
        {
            Singleton<ExtendedGameOptionsManager>.instance.values.AreasMaxCount = sel + 1;
            Areas.Update();
        }

        private void OilDepletionRateChanged(float val)
        {
            Singleton<ExtendedGameOptionsManager>.instance.values.OilDepletionRate = (int)val;
        }

        private void OreDepletionRateChanged(float val)
        {
            Singleton<ExtendedGameOptionsManager>.instance.values.OreDepletionRate = (int)val;
        }

        private void SaveBtnClicked()
        {
            Singleton<ExtendedGameOptionsManager>.instance.Save();
        }

        #endregion
    }
}
