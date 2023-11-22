using Terraria;
using Terraria.ModLoader;

namespace MortalsArmory.Items.Extra
{
    public class ExampleItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }
        public override void SetDefaults()
        {
            Item.width = 20; 
            Item.height = 20; 

            Item.maxStack = Item.CommonMaxStack; 
            Item.value = Item.buyPrice(silver: 1);
        }

    }
}
