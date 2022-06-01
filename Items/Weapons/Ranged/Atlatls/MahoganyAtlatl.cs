﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Polarities.NPCs;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Polarities.Items.Weapons.Ranged.Atlatls
{
	public class MahoganyAtlatl : AtlatlBase
	{
		public override Vector2[] ShotDistances => new Vector2[] { new Vector2(30) };

		public override void SetDefaults()
		{
			Item.SetWeaponValues(9, 3, 0);
			Item.DamageType = DamageClass.Ranged;

			Item.width = 36;
			Item.height = 34;

			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item1;

			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Dart;

			Item.value = Item.sellPrice(copper: 20);
			Item.rare = ItemRarityID.White;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.RichMahogany, 12)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}