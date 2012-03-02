using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class PlayerZeddy : Player
    {
        public PlayerZeddy(int x, int y, int playerID) : base(x,y,playerID)
        {
            speed = 4;
            jumpHeight = 16;
            gravity = 1;
        }
        public override void PreInit()
        {
            base.PreInit();
            Sprite = Game1.texPlayerZeddy;
        }
    }
}
