﻿using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;
using static Terraria.ModLoader.ModContent;
using Terraria.GameInput;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Collections.Generic;
using Polarities.Items;
using Polarities.NPCs;
using MonoMod.Cil;
using Terraria.ModLoader.IO;
using Terraria.Enums;

namespace Polarities.Items.Armor
{
    public interface IDrawArmor
    {
        void DrawArmor(ref PlayerDrawSet drawInfo);

        //bool DoVanillaDraw();
    }

    public interface IGetBodyMaskColor
    {
        Color BodyColor(ref PlayerDrawSet drawInfo);
    }

    public class HeadMaskDrawLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return ArmorMasks.headIndexToArmorDraw.ContainsKey(drawInfo.drawPlayer.head);
        }

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            ArmorMasks.headIndexToArmorDraw[drawInfo.drawPlayer.head].DrawArmor(ref drawInfo);
        }
    }

    public class LegMaskDrawLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Leggings);

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return ArmorMasks.legIndexToArmorDraw.ContainsKey(drawInfo.drawPlayer.legs);
        }

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            ArmorMasks.legIndexToArmorDraw[drawInfo.drawPlayer.legs].DrawArmor(ref drawInfo);
        }
    }

    public class ArmorMasks : ILoadable
    {
        public static Dictionary<int, IDrawArmor> headIndexToArmorDraw;
        public static Dictionary<int, IDrawArmor> legIndexToArmorDraw;

        public static Dictionary<int, IGetBodyMaskColor> bodyIndexToBodyMaskColor;

        public void Load(Mod mod)
        {
            headIndexToArmorDraw = new Dictionary<int, IDrawArmor>();
            legIndexToArmorDraw = new Dictionary<int, IDrawArmor>();
            bodyIndexToBodyMaskColor = new Dictionary<int, IGetBodyMaskColor>();
        }

        public void Unload()
        {
            headIndexToArmorDraw = null;
            legIndexToArmorDraw = null;
            bodyIndexToBodyMaskColor = null;
        }
    }
}

