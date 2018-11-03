using ICities;
using ColossalFramework;

namespace ExtendedGameOptions
{
    public class OilAndOreResource : ResourceExtensionBase
    {
        public override void OnAfterResourcesModified(int x, int z, NaturalResource type, int amount)
        {
            if ((type == NaturalResource.Oil || type == NaturalResource.Ore) && amount < 0)
            {
                ExtendedGameOptionsSerializable o = Singleton<ExtendedGameOptionsManager>.instance.values;

                if (type == NaturalResource.Oil)
                {
                    // Vanilla original rate (100%)
                    if (o.OilDepletionRate == 100) return;

                    if (o.OilDepletionRate == 0)
                    {
                        // Vanilla original UnlimitedOilAndOre mod
                        resourceManager.SetResource(x, z, type, (byte)(resourceManager.GetResource(x, z, type) - amount), false);
                    }
                    else
                    {
                        // 1% ~ 99%
                        if (Singleton<SimulationManager>.instance.m_randomizer.Int32(100u) >= o.OilDepletionRate)
                        {
                            resourceManager.SetResource(x, z, type, (byte)(resourceManager.GetResource(x, z, type) - amount), false);
                        }
                    }
                }
                else if (type == NaturalResource.Ore)
                {
                    // Vanilla original rate (100%)
                    if (o.OreDepletionRate == 100) return;

                    if (o.OreDepletionRate == 0)
                    {
                        // Vanilla original UnlimitedOilAndOre mod
                        resourceManager.SetResource(x, z, type, (byte)(resourceManager.GetResource(x, z, type) - amount), false);
                    }
                    else
                    {
                        // 1% ~ 99%
                        if (Singleton<SimulationManager>.instance.m_randomizer.Int32(100u) >= o.OreDepletionRate)
                        {
                            resourceManager.SetResource(x, z, type, (byte)(resourceManager.GetResource(x, z, type) - amount), false);
                        }
                    }
                }
            }
        }
    }
}
