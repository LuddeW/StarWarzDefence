using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spline;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperStarWarzTowerDefence
{
    class MapHandler
    {
        SimplePath spline;
        GraphicsDevice graphics;

        public MapHandler(GraphicsDevice graphics)
        {
            this.graphics = graphics;
        }

        public void MapMaker()
        {
            spline.AddPoint(new Vector2(0, 300));
            spline.AddPoint(new Vector2(250, 300));
            spline.AddPoint(new Vector2(600, 300));
            spline.AddPoint(new Vector2(600, 400));
            spline.AddPoint(new Vector2(600, 500));
            spline.AddPoint(new Vector2(400, 500));
            spline.AddPoint(new Vector2(200, 500));
            spline.AddPoint(new Vector2(200, 750));
            spline.AddPoint(new Vector2(200, 900));
            spline.AddPoint(new Vector2(400, 900));
            spline.AddPoint(new Vector2(600, 900));
            spline.AddPoint(new Vector2(800, 600));
            spline.AddPoint(new Vector2(900, 600));
            spline.AddPoint(new Vector2(950, 500));
            spline.AddPoint(new Vector2(1000, 500));
        }

        public SimplePath GetSimplePath()
        {
            return spline;
        }

        public void LoadContent()
        {
            spline = new SimplePath(graphics);
            spline.Clean();
            MapMaker();
        }

        public void Draw(SpriteBatch sb)
        {
            spline.Draw(sb);
            spline.DrawPoints(sb);
        }
    }
}
