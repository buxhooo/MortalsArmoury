using Microsoft.Xna.Framework;
using MortalsArmory.Items.Extra;
using MortalsArmory.Projectiles.Ranged;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MortalsArmory.Items.Weapons
{
    public class TheAce : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.rare = ItemRarityID.Red;
            

            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            Item.UseSound = SoundID.Item1;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 400;
            Item.knockBack = 8f;
            Item.noMelee = true;
            Item.crit = 24;
            Item.value = ModContent.ItemType<ExampleItem>();

            Item.shoot = ModContent.ProjectileType<MementoMoriProj>();
            Item.shootSpeed = 16f;
            Item.useAmmo = AmmoID.Bullet;


        }
        public override Vector2? HoldoutOffset() 
        {
            return new Vector2(0f, 0f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Vector2 newPos = position + new Vector2(60f, player.direction * (Math.Abs(velocity.SafeNormalize(Vector2.Zero).X) < 0.02f ? -2f : -8f)).RotatedBy(velocity.ToRotation());

            if (type == ProjectileID.Bullet)
            {
                damage = 1200;
                Projectile.NewProjectile(source, newPos, velocity, Item.shoot, damage, knockback, player.whoAmI);
            }
            else
            {
                damage = 400;
                Projectile.NewProjectile(source, newPos, velocity, type, damage, knockback, player.whoAmI);
            }

            return false;


        }

    }

   
}
