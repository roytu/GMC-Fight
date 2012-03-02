using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Player : Object
    {
        protected int speed;
        protected int jumpHeight;
        protected int gravity;

        protected int playerID;

        private float xsp;
        private float ysp;

        public Player(int x, int y, int playerID) : base(x,y)
        {
            PreInit();
            xsp = 0;
            ysp = 0;

            xoff = width / 2;
            yoff = height / 2;

            SetBbox(-width/2, -height/2, width, height);

            this.playerID = playerID;
        }
        public virtual void PreInit() { }
        public override void Update()
        {
            #region Input
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A))
            {
                for(int dx=speed;dx>0;dx--)
                {
                    if(!isCollidingAt((int)x - dx, (int)y, typeof(Walls)))
                    {
                        x -= dx;
                        xscale = -1;
                        break;
                    }
                }
            }
            if (state.IsKeyDown(Keys.D))
            {
                for (int dx = speed; dx > 0; dx--)
                {
                    if (!isCollidingAt((int)x + dx, (int)y, typeof(Walls)))
                    {
                        x += dx;
                        xscale = 1;
                        break;
                    }
                }
            }
            if (state.IsKeyDown(Keys.W))
            {
                if (isCollidingAt((int)Math.Round(x), (int)Math.Round(y)+1, typeof(Walls)))
                {
                    ysp = -jumpHeight;
                }
            }
            #endregion

            #region Physics
            if (isCollidingAt(x, y, typeof(Walls)))
            {
                //Console.WriteLine(bbox.Left);
            }

            if (!isCollidingAt(x, y + 1, typeof(Walls)))
            {
                ysp += gravity;
            }

            //check for collisions before updating
            if (isCollidingAt(x, y + ysp, typeof(Walls)))
            {
                y += ysp;
                while (isCollidingAt(x, y, typeof(Walls)))
                {
                    if (ysp >= 0)
                    {
                        y -= 0.1f;
                    }
                    else if (ysp < 0)
                    {
                        y += 0.1f;
                    }
                }
                ysp = 0;
            }

            //update speeds
            x += xsp;
            y += ysp;
            #endregion
        }
    }
}
