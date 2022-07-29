using ICities;
using ColossalFramework;
using ColossalFramework.UI;
using UnityEngine;
using System.Text.RegularExpressions;

namespace ExtendedGameOptions
{
    public class Mod : IUserMod
    {
        private static string version = "2022/07/25";

        public string Name
        {
            get { return Locale.Text("ModName"); }
        }

        public string Description
        {
            get { return Locale.Text("ModDesc") + " Ver." + version; }
        }

        #region Options UI

        private bool modified = false;

        private string getResourceSliderText(int value)
        {
            if (value == 0)
            {
                return "0% (" + Locale.Text("unlimited") + ")";
            }
            else if (value == 100)
            {
                return Locale.Text("Unchanged");
            }
            else
            {
                return value.ToString() + "%";
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

            helper.AddCheckbox(Locale.Text("EnableAchievements"), o.EnableAchievements, delegate (bool isChecked)
            {
                o.EnableAchievements = isChecked;
                modified = true;
            });
            helper.AddCheckbox(Locale.Text("InfoViewBtnsEnabled"), o.InfoViewButtonsAlwaysEnabled, delegate (bool isChecked)
            {
                o.InfoViewButtonsAlwaysEnabled = isChecked;
                modified = true;
            });

            helper.AddSpace(20);


            //////////// Unlocks ////////////

            UIHelperBase unlockGroup = helper.AddGroup(Locale.Text("UnlocksTitle"));
            unlockGroup.AddCheckbox(Locale.Text("BasicRoads"), o.BasicRoadsAvailableBromStart, delegate (bool isChecked)
            {
                o.BasicRoadsAvailableBromStart = isChecked;
                modified = true;
            });
            unlockGroup.AddCheckbox(Locale.Text("TrainTracks"), o.TrainTrackUnlock, delegate (bool isChecked)
            {
                o.TrainTrackUnlock = isChecked;
                modified = true;
            });
            unlockGroup.AddCheckbox(Locale.Text("MetroTunnels"), o.MetroTrackUnlock, delegate (bool isChecked)
            {
                o.MetroTrackUnlock = isChecked;
                modified = true;
            });
            unlockGroup.AddCheckbox(Locale.Text("UnlockUpTo"), o.UnlockMilestone, delegate (bool isChecked)
            {
                o.UnlockMilestone = isChecked;
                modified = true;
            });
            unlockGroup.AddDropdown(Locale.Text("SelectMegalopolis"), Milestones.MilestoneLocalizedNames, o.UnlockMilestoneIndex - 1, delegate (int sel)
            {
                o.UnlockMilestoneIndex = sel + 1;
                modified = true;
            });


            //////////// Economy ////////////

            UIHelperBase economyGroup = helper.AddGroup(Locale.Text("Economy"));

            economyGroup.AddTextfield(Locale.Text("InitialMoney"),
                o.InitialMoney < 0 ? "" : o.InitialMoney.ToString("N0"),
                delegate (string text) { },
                delegate (string text)
            {
                text = Regex.Replace(text, "[^0-9]", "");
                long value;
                if (long.TryParse(text, out value))
                {
                    o.InitialMoney = value;
                }
                else
                {
                    o.InitialMoney = -1;
                }

                modified = true;
            });

            economyGroup.AddCheckbox(Locale.Text("BulldozingStructures"), o.FullRefund, delegate (bool isChecked)
            {
                o.FullRefund = isChecked;
                modified = true;
            });


            //////////// Others ////////////

            if (SteamHelper.IsDLCOwned(SteamHelper.DLC.NaturalDisastersDLC))
            {
                helper.AddCheckbox(Locale.Text("EnableDisasters"), o.EnableRandomDisastersForScenarios, delegate (bool isChecked)
                {
                    o.EnableRandomDisastersForScenarios = isChecked;
                    modified = true;
                });
            }
            helper.AddCheckbox(Locale.Text("NumberAreas"), o.EnableAreasMaxCountOption, delegate (bool isChecked)
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
            UIDropDown areasMaxCountDropdown = (UIDropDown)helper.AddDropdown(Locale.Text("Areas"), Areas.GetAvailableValuesStr(), o.AreasMaxCount - 1, delegate (int sel)
            {
                o.AreasMaxCount = sel + 1;
                modified = true;

                if (Singleton<ExtendedGameOptionsManager>.instance.values.EnableAreasMaxCountOption)
                {
                    Areas.Update();
                }
            });

            helper.AddSpace(20);


            //////////// Resources ////////////

            UIHelperBase resourcesHelper = helper.AddGroup(Locale.Text("ResourcesDepletionRate"));
            addLabelToResourceSlider(resourcesHelper.AddSlider(Locale.Text("OilDepletionRate"), 0, 100, 1, o.OilDepletionRate, delegate (float val)
            {
                o.OilDepletionRate = (int)val;
                modified = true;
            }));
            addLabelToResourceSlider(resourcesHelper.AddSlider(Locale.Text("OreDepletionRate"), 0, 100, 1, o.OreDepletionRate, delegate (float val)
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

                Achievements.Update();
                Economy.UpdateInitialMoney();
            }
        }

        #endregion
    }
}
