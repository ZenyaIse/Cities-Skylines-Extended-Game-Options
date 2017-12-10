using ColossalFramework;
using ColossalFramework.UI;

namespace ExtendedGameOptions
{
    public class InfoViewButtons
    {
        public static void Initialize()
        {
            if (Singleton<ExtendedGameOptionsManager>.instance.values.InfoViewButtonsAlwaysEnabled)
            {
                UIComponent uIComponent = UIView.Find<UIPanel>("InfoViewsPanel");
                if (uIComponent != null)
                {
                    uIComponent.eventVisibilityChanged += UIComponent_eventVisibilityChanged;
                }
            }
        }

        private static void UIComponent_eventVisibilityChanged(UIComponent component, bool value)
        {
            if (value && Singleton<ExtendedGameOptionsManager>.instance.values.InfoViewButtonsAlwaysEnabled)
            {
                InfoViewsPanel infoViewsPanel = component.GetComponent<InfoViewsPanel>();
                UIButton[] infoViewButtons = infoViewsPanel.GetComponentsInChildren<UIButton>();

                foreach (UIButton button in infoViewButtons)
                {
                    button.isEnabled = true;
                }
            }
        }
    }
}
