using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaRoyaleMod.Content.Buffs;
using TerrariaRoyaleMod.Content.projectiles.Minions;


namespace TerrariaRoyaleMod.Content.Items.Weapons
{
    public class Skeletons : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            ItemID.Sets.GamepadWholeScreenUseRange[Type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;

            Item.DamageType = DamageClass.Summon;
            Item.damage = 10;
            Item.knockBack = 1;
            Item.mana = 7;
            Item.noMelee = true;

            Item.value = Item.buyPrice(silver: 10);

            Item.shoot = ModContent.ProjectileType<Skeleton>();
            Item.buffType = ModContent.BuffType<SkeletonsBuffs>();
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);

            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, Main.myPlayer);
            projectile.originalDamage = Item.damage;

            return false;
        }
    }
}
