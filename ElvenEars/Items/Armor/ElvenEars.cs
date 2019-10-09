using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElvenEars.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ElvenEars : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elven Ears");
            Tooltip.SetDefault("Living that long ear life.");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 1000000;   //1 Platinum.
            item.rare = -11;        //Amber Item Name Color.
            item.vanity = true;
        }

        public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            Color color1 = drawPlayer.skinColor;                                                                    //Gives the ears the correct skin color.
            Color color2 = Lighting.GetColor((int)(drawPlayer.Center.X / 16f), (int)(drawPlayer.Center.Y / 16f));   //Gives the ears the characters lighting at their position.
            //float averageLightLevel = (color2.R + color2.G + color2.B) / 3f;                                      //Was used to determine overall average lighting, good to keep around though.
            //float multiplier = averageLightLevel / 255f;                                                          //Transformed averageLightLevel into a coefficient for multiplication.
            //color = color1 * multiplier;                                                                          //Applied the coefficient to the skin color.
            color.A = 255;                                                                                          //Always have Alpha at max, so there's no accidental transparency.
            color.R = (byte)(color1.R * (color2.R / 255f));                                                         //Applies Red lighting to Red Skin Color channel.
            color.G = (byte)(color1.G * (color2.G / 255f));                                                         //Same as Red but Green.
            color.B = (byte)(color1.B * (color2.B / 255f));                                                         //Same as Red but Blue.
        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            base.DrawHair(ref drawHair, ref drawAltHair);
            drawHair = true;
        }

        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}