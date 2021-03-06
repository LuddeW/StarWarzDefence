﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperStarWarzTowerDefence.GameObjects.Tower
{
    class ExplosiveTower : Tower
    {
        public ExplosiveTower(Texture2D texture, Vector2 pos) : base(texture, pos, 100)
        {
            fireSpeed = 0.5f;
        }
        internal Tower Copy()
        {
            return new ExplosiveTower(texture, pos);
        }
    }
}
