﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DacMisCom
{
    class Sprite
    {


        //Details
        protected string name;
        public Rectangle size;
        public Vector2 position, position_prev;
        protected Texture2D spriteTexture;
        protected float scale;

        public float Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                size = new Rectangle(0, 0, (int)(spriteTexture.Width * Scale), (int)(spriteTexture.Height * Scale));
            }
        }



        public Sprite()
        {
            position = new Vector2(0, 0);
            position_prev = new Vector2(0, 0);
            name = "newSprite";
            scale = 1f;
        }

        public Sprite(string assetName)
        {
            position = new Vector2(0, 0);
            position_prev = new Vector2(0, 0);
            name = assetName;
            scale = 1f;
        }

        public Sprite(string assetName, Color c)
        {
            position = new Vector2(0, 0);
            position_prev = new Vector2(0, 0);
            name = assetName;
            scale = 1f;
        }


        //Load the texture for the sprite using the Content Pipeline
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            spriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            size = new Rectangle(0, 0, (int)(spriteTexture.Width * scale), (int)(spriteTexture.Height * scale));
        }


        //Update the Sprite and change it's position based on the passed in speed, direction and elapsed time.
        public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection)
        {
            position_prev = position;
            position += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
        }


        //Draw the sprite to the screen
        public void Draw(SpriteBatch theSpriteBatch)
        {
            Rectangle tmpRec = new Rectangle(0, 0, spriteTexture.Width, spriteTexture.Height);
            theSpriteBatch.Draw(spriteTexture, position, tmpRec, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
        }


        //overload, supplying optional color parameter
        public void Draw(SpriteBatch theSpriteBatch, Color c, float pSlope=0f, int layer=0)
        {
            Rectangle tmpRec = new Rectangle(0, 0, spriteTexture.Width, spriteTexture.Height);
            theSpriteBatch.Draw(spriteTexture, position, tmpRec, c, pSlope, Vector2.Zero, scale, SpriteEffects.None, layer);
        }

    }
}
