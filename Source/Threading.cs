using ICities;
using ColossalFramework;
using UnityEngine;

namespace ExtendedGameOptions
{
    public class Threading: ThreadingExtensionBase
    {
        public override void OnAfterSimulationFrame()
        {
            if (!Singleton<ExtendedGameOptionsManager>.instance.values.EnableRandomDisastersForScenarios) return;

            // If playing a scenario
            if (!string.IsNullOrEmpty(Singleton<SimulationManager>.instance.m_metaData.m_ScenarioAsset))
            {
                DisasterManager dm = Singleton<DisasterManager>.instance;

                // From DisasterManager.SimulationStepImpl
                ItemClass.Availability mode = Singleton<ToolManager>.instance.m_properties.m_mode;
                if ((mode & ItemClass.Availability.Game) != ItemClass.Availability.None)
                {
                    int areaCount = Singleton<GameAreaManager>.instance.m_areaCount;
                    float num = dm.m_randomDisastersProbability;
                    if (num > 0.001f)
                    {
                        num *= num;
                        num *= (float)((areaCount > 1) ? (550 + areaCount * 50) : 500);
                        int num2 = Mathf.Max(1, Mathf.RoundToInt(num));
                        if (dm.m_randomDisasterCooldown < 65536 - 49152 * num2 / 1000)
                        {
                            dm.m_randomDisasterCooldown++;
                        }
                        else
                        {
                            SimulationManager instance = Singleton<SimulationManager>.instance;
                            if (instance.m_randomizer.Int32(67108864u) < num2)
                            {
                                dm.StartRandomDisaster();
                                dm.m_randomDisasterCooldown = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}
