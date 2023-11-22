using Terraria.ModLoader;
using Terraria.GameContent.UI;


namespace MortalsArmory
{
	public class MortalsArmoury : Mod
	{
        public static int ExampleCustomCurrencyId;


        public override void Load()
        {
            ExampleCustomCurrencyId = CustomCurrencyManager.RegisterCurrency(new Extra.Currencies.ExampleCustomCurrency(ModContent.ItemType<Items.Extra.ExampleItem>(), 999L, "Mods.MortalsArmory.Extra.Currencies.ExampleCustomCurrency"));
        }

        public override void Unload()
        {
           //todo
        }
    }
}