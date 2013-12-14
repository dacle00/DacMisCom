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
    class City : Sprite
    {

        const string ASSET_NAME = "City";
        const int START_POS_X = 125;
        const int START_POS_Y = 200;
        public Color color;
        public Shield shield;
 
        public enum State
        {
            dead, paused, armed, reloading, 
        }
        public State currentState = State.armed;


        public City()
        {
            shield = new Shield();
            position = new Vector2(START_POS_X, START_POS_Y);
            color = Color.DarkSlateBlue;
        }


        public void LoadContent(ContentManager theContentManager)
        {
            base.LoadContent(theContentManager, ASSET_NAME);  // also sets the size
        }


        public void Update(GameTime theGameTime)
        {
            switch (currentState)
            {
                case State.reloading:
                    //do stuff?  update the reload time, show progress bar?
                    break;
                case (State.dead):
                    // make sure smoking or dead effect is in place.
                    break;
                case (State.armed):
                    //animate city? etc? life bar?
                    break;
                case (State.paused):
                    // do nothing?
                    break;
                default:
                    //err output?
                    break;
            }

            //TODO: is this needed, since cities don't move?
            //base.Update(theGameTime, speed, direction);
        }


        public void Draww(SpriteBatch theSpriteBatch, Color c)
        {

            if (shield.currentState == Shield.State.active)
                shield.Draw(theSpriteBatch, shield.color);

            base.Draw(theSpriteBatch, c);
        }
    }
}
