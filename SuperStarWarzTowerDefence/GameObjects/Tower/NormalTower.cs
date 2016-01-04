using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperStarWarzTowerDefence.GameObjects.Tower
{
    class NormalTower : Tower
    {
        public NormalTower(Texture2D texture, Vector2 pos) : base(texture, pos, 150)
        {
            fireSpeed = 1f;
        }
        internal Tower Copy()
        {
            return new NormalTower(texture, pos);
        }
    }
}
