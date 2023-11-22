using System;
using Terraria;
using Terraria.ModLoader;

namespace MortalsArmory.ReforgeAPI
{
    public class CustomReforge : GlobalItem
    {
        public override bool ReforgePrice(Item item, ref int reforgePrice, ref bool canApplyDiscount)
        {
            reforgePrice = 0;

            return false;
        }

        public static int CalculateCustomCurrencyCost(Item item)
        {
            int cost = 10; 
            return cost;
        }

        public static bool HasEnoughCurrency(Player player, int cost)
        {
            int currencyCount = 0;

            foreach (Item inventoryItem in player.inventory)
            {
                if (inventoryItem.type == ModContent.ItemType<Items.Extra.ExampleItem>())
                {
                    currencyCount += inventoryItem.stack;
                }

            }
            return currencyCount >= cost;
        }

        public static void DeductCustomCurrency(Player player, int cost)
        {
            for(int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i].type == ModContent.ItemType<Items.Extra.ExampleItem>() && cost > 0)
                {
                    int deductAmount = Math.Min(player.inventory[i].stack, cost);
                    player.inventory[i].stack -= deductAmount;
                    cost -= deductAmount;

                    if (player.inventory[i].stack <= 0)
                    {
                        player.inventory[i].TurnToAir();
                    }
                }
            }
        }
        public static bool TryReforgeCustom(Player player, Item item)
        {
            int customCurrencyRequired = CalculateCustomCurrencyCost(item);

            if (HasEnoughCurrency(player, customCurrencyRequired))
            {
                DeductCustomCurrency(player, customCurrencyRequired);
                return true;
            }
            return false;
        }
    }
}
