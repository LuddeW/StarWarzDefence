﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperStarWarzTowerDefence.GameObjects.Tower
{
    class Tower : GameObject
    {
        Vector2 pos;
        public Tower(Texture2D texture, Vector2 pos) :base(texture, pos)
        {
            this.pos = pos;
        }

    }
}
