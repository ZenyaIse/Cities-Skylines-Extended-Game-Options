using ICities;
using ColossalFramework;

namespace ExtendedGameOptions
{
    public class Economy : EconomyExtensionBase
    {
        public override int OnGetRefundAmount(int constructionCost, int refundAmount, Service service, SubService subService, Level level)
        {
            ExtendedGameOptionsSerializable o = Singleton<ExtendedGameOptionsManager>.instance.values;

            if (o.FullRefund)
            {
                // Full refund for all recently built roads and facilities.
                // Consider it as an "undo" feature.
                return constructionCost;
            }

            return refundAmount;
        }
    }
}
