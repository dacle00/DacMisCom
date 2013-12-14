using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DacMisCom
{
    class Shield: Sprite
    {

        const string ASSET_NAME = "Shield";
        const int START_POS_X = 125;
        const int START_POS_Y = 200;
        public Color color;

        public enum State
        {
            active, inactive, charging,
        }
        public State currentState = State.active;


        public Shield()
        {
            position = new Vector2(START_POS_X, START_POS_Y);
            color = Color.LightGoldenrodYellow;
        }


        public void LoadContent(ContentManager theContentManager)
        {
            base.LoadContent(theContentManager, ASSET_NAME);  // also sets the size
        }


        public void Update(GameTime theGameTime)
        {
            switch (currentState)
            {
                case State.charging:
                    //do stuff?  update the reload time, show progress bar?
                    break;
                case (State.inactive):
                    // make sure smoking or dead effect is in place.
                    break;
                case (State.active):
                    //animate city? etc? life bar?
                    break;
                default:
                    //err output?
                    break;
            }

            //TODO: is this needed, since shields don't move? (and doesn't yet animate
            //base.Update(theGameTime, speed, direction);
        }


        public void setPositionByCenter(Rectangle center)
        {
            position = new Vector2(center.Center.X - size.Width/2, center.Center.Y - size.Height/2);
        }


    }
}
