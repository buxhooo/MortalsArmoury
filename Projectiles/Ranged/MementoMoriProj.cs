using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MortalsArmory.Projectiles.Ranged
{
    public class MementoMoriProj : ModProjectile
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        private const int Lifetime = 600;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.extraUpdates = 4;
            Projectile.timeLeft = Lifetime;
            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.spriteDirection = Projectile.direction;


            Lighting.AddLight(Projectile.Center, 0.9f, 0f, 0.15f);

            
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 4f)
            {
                int dustID = 63;
                float scale = Main.rand.NextFloat(0.6f, 0.9f);
                Dust d = Dust.NewDustDirect(Projectile.Center, 0, 0, dustID);
                Vector2 posOffset = Projectile.velocity.SafeNormalize(Vector2.Zero) * 12f;
                d.position += posOffset - 2f * Vector2.UnitY;
                d.noGravity = true;
                d.velocity *= 0.6f;
                d.velocity += Projectile.velocity * 0.15f;
                d.scale = scale;
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(226, 240, 255, 1);

        public override void OnKill(int timeLeft)
        {
            int dustID = 63;
            int dustCount = 3;
            for (int i = 0; i < dustCount; ++i)
                Dust.NewDust(Projectile.Center, 0, 0, dustID, Scale: 1.2f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
            return true;
        }
    }

}

