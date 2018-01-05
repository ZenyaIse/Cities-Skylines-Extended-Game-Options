using ICities;
using ColossalFramework;
using ColossalFramework.UI;
using UnityEngine;

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
            get { return "Collection of small useful features."; }
        }

        #region Options UI

        private UIDropDown areasMaxCountDropdown;
        private bool modified = false;

        public void OnSettingsUI(UIHelperBase helper)
        {
            ExtendedGameOptionsSerializable o = Singleton<ExtendedGameOptionsManager>.instance.values;

            helper.AddCheckbox("Set pause when the game is loaded", o.PauseOnLoad, delegate (bool isChecked)
            {
                o.PauseOnLoad = isChecked;
                modified = true;
            });
            helper.AddCheckbox("Enable achievements", o.EnableAchievements, delegate (bool isChecked)
            {
                o.EnableAchievements = isChecked;
                Achievements.Update();
                modified = true;
            });
            helper.AddCheckbox("Info View buttons are always enabled", o.InfoViewButtonsAlwaysEnabled, delegate (bool isChecked)
            {
                o.InfoViewButtonsAlwaysEnabled = isChecked;
                modified = true;
            });

            helper.AddSpace(20);

            UIHelperBase unlockGroup = helper.AddGroup("Unlocks (requires game reload)");
            unlockGroup.AddCheckbox("Basic roads are available from the start", o.BasicRoadsAvailableBromStart, delegate (bool isChecked)
            {
                o.BasicRoadsAvailableBromStart = isChecked;
                modified = true;
            });
            unlockGroup.AddCheckbox("Train tracks can be constructed without a train station", o.TrainTrackUnlock, delegate (bool isChecked)
            {
                o.TrainTrackUnlock = isChecked;
                modified = true;
            });
            unlockGroup.AddCheckbox("Metro tunnels can be constructed without a metro station", o.MetroTrackUnlock, delegate (bool isChecked)
            {
                o.MetroTrackUnlock = isChecked;
                modified = true;
            });
            unlockGroup.AddCheckbox("Unlock everything up to the following milestone", o.UnlockMilestone, delegate (bool isChecked)
            {
                o.UnlockMilestone = isChecked;
                modified = true;
            });
            unlockGroup.AddDropdown("     (select Megalopolis to unlock all)", Milestones.MilestoneLocalizedNames, o.UnlockMilestoneIndex - 1, delegate (int sel)
            {
                o.UnlockMilestoneIndex = sel + 1;
                modified = true;
            });

            if (SteamHelper.IsDLCOwned(SteamHelper.DLC.NaturalDisastersDLC))
            {
                helper.AddCheckbox("Enable random disasters for scenarios", o.EnableRandomDisastersForScenarios, delegate (bool isChecked)
                {
                    o.EnableRandomDisastersForScenarios = isChecked;
                    modified = true;
                });
            }
            helper.AddCheckbox("Change available areas as below (uncheck this if using 81 tiles mod)", o.EnableAreasMaxCountOption, delegate (bool isChecked)
            {
                Singleton<ExtendedGameOptionsManager>.instance.values.EnableAreasMaxCountOption = isChecked;

                if (isChecked)
                {
                    Areas.Update();
                }
                else
                {
                    Areas.Reset();
                }

                modified = true;
            });
            areasMaxCountDropdown = (UIDropDown)helper.AddDropdown("Available areas", Areas.GetAvailableValuesStr(), o.AreasMaxCount - 1, delegate (int sel)
            {
                o.AreasMaxCount = sel + 1;
                Areas.Update();
                modified = true;
            });

            helper.AddSpace(20);

            UIHelperBase resourcesHelper = helper.AddGroup("Resources depletion rate (move to the left for unlimited)");
            resourcesHelper.AddSlider("Oil depletion rate", 0, 10, 1, o.OilDepletionRate, delegate (float val)
            {
                o.OilDepletionRate = (int)val;
                modified = true;
            });
            resourcesHelper.AddSlider("Ore depletion rate", 0, 10, 1, o.OreDepletionRate, delegate (float val)
            {
                o.OreDepletionRate = (int)val;
                modified = true;
            });

            UIComponent optionPanel = areasMaxCountDropdown.parent.parent;
            optionPanel.eventVisibilityChanged += OptionPanel_eventVisibilityChanged;
        }

        private void OptionPanel_eventVisibilityChanged(UIComponent component, bool value)
        {
            if (modified && !value)
            {
                Singleton<ExtendedGameOptionsManager>.instance.Save();
                modified = false;
            }
        }

        #endregion
    }
}
