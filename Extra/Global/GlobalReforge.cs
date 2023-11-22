using MortalsArmory.ReforgeAPI;
using Terraria;
using Terraria.ModLoader;

namespace MortalsArmory.Extra.Global
{
    public class GlobalReforge : GlobalItem
    {
        public override bool CanReforge(Item item)
        {
            Player player = Main.LocalPlayer;
            int customCurrencyCost = CustomReforge.CalculateCustomCurrencyCost(item);

            
            return CustomReforge.HasEnoughCurrency(player, customCurrencyCost);
        }

        public override void PostReforge(Item item)
        {
            Player player = Main.LocalPlayer;
            int customCurrencyCost = CustomReforge.CalculateCustomCurrencyCost(item);

            
            if (CustomReforge.HasEnoughCurrency(player, customCurrencyCost))
            {
                CustomReforge.DeductCustomCurrency(player, customCurrencyCost);
            }
        }
    }
}
