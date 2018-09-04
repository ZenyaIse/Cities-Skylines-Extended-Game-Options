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

        private string getResourceSliderText(int value)
        {
            if (value == 0)
            {
                return "0% (unlimited)";
            }
            else
            {
                return (value * 10).ToString() + "%";
            }
        }

        private void addLabelToResourceSlider(object obj)
        {
            UISlider uISlider = obj as UISlider;
            if (uISlider == null) return;

            UILabel label = uISlider.parent.AddUIComponent<UILabel>();
            label.text = getResourceSliderText((int)uISlider.value);
            label.textScale = 1f;
            (uISlider.parent as UIPanel).autoLayout = false;
            label.position = new Vector3(uISlider.position.x + uISlider.width + 15, uISlider.position.y);

            UILabel titleLabel = (uISlider.parent as UIPanel).Find<UILabel>("Label");
            titleLabel.anchor = UIAnchorStyle.None;
            titleLabel.position = new Vector3(titleLabel.position.x, titleLabel.position.y + 3);

            uISlider.eventValueChanged += new PropertyChangedEventHandler<float>(delegate (UIComponent component, float value)
            {
                label.text = getResourceSliderText((int)uISlider.value);
            });
        }

        public void OnSettingsUI(UIHelperBase helper)
        {
            ExtendedGameOptionsSerializable o = Singleton<ExtendedGameOptionsManager>.instance.values;


            //////////// General ////////////

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


            //////////// Unlocks ////////////

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


            //////////// Economy ////////////

            UIHelperBase economyGroup = helper.AddGroup("Economy");

            economyGroup.AddCheckbox("Bulldozing structures built recently gives full refund", o.FullRefund, delegate (bool isChecked)
            {
                o.FullRefund = isChecked;
                modified = true;
            });


            //////////// Others ////////////

            if (SteamHelper.IsDLCOwned(SteamHelper.DLC.NaturalDisastersDLC))
            {
                helper.AddCheckbox("Enable random disasters for scenarios", o.EnableRandomDisastersForScenarios, delegate (bool isChecked)
                {
                    o.EnableRandomDisastersForScenarios = isChecked;
                    modified = true;
                });
            }
            helper.AddCheckbox("Set number of purchasable areas (uncheck this if using 81 tiles mod)", o.EnableAreasMaxCountOption, delegate (bool isChecked)
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
            areasMaxCountDropdown = (UIDropDown)helper.AddDropdown("Areas", Areas.GetAvailableValuesStr(), o.AreasMaxCount - 1, delegate (int sel)
            {
                o.AreasMaxCount = sel + 1;
                Areas.Update();
                modified = true;
            });

            helper.AddSpace(20);


            //////////// Resources ////////////

            UIHelperBase resourcesHelper = helper.AddGroup("Resources depletion rate");
            addLabelToResourceSlider(resourcesHelper.AddSlider("Oil depletion rate", 0, 10, 1, o.OilDepletionRate, delegate (float val)
            {
                o.OilDepletionRate = (int)val;
                modified = true;
            }));
            addLabelToResourceSlider(resourcesHelper.AddSlider("Ore depletion rate", 0, 10, 1, o.OreDepletionRate, delegate (float val)
            {
                o.OreDepletionRate = (int)val;
                modified = true;
            }));


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
