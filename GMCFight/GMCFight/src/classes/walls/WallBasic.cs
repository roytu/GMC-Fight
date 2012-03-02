using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class WallBasic : Walls
    {
        public WallBasic(int x, int y) : base(x, y)
        {
            
        }
        public override void PreInit()
        {
            base.PreInit();
            Sprite = Game1.texWall;
        }
        public override void Update()
        {
            base.Update();
        }
    }
}
