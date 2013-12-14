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
    class BallisticMissile : Sprite
    {

        const string ASSET_NAME = "Missile1";
        const int START_POS_X = 125;
        const int START_POS_Y = 200;
        Vector2 final_pos;
        public Vector2 speed;
        public Vector2 direction;
        public float slope;
        public Rectangle playArea;
        public const int MOVE_DOWN = 1;
        public const int MOVE_LEFT = -1;
        public const int MOVE_RIGHT=1;
        int speedTotal;


        public Color color;

        public enum State
        {
            moving, exploding, paused,
        }
        public State currentState = State.moving;


        public BallisticMissile(int mSpeedTotal, Vector2 mInitial_pos, Vector2 mFinal_pos)
        {
            position = new Vector2(START_POS_X, START_POS_Y);
            final_pos = mFinal_pos;
            color = Color.LightGoldenrodYellow;
            speedTotal = mSpeedTotal;
            direction = calculateDirection();
            slope = calculateSlope();
            speed = calculateSpeed();
        }


        public void LoadContent(ContentManager theContentManager)
        {
            base.LoadContent(theContentManager, ASSET_NAME);  // also sets the size
        }


        public void Update(GameTime theGameTime)
        {
            switch (currentState)
            {
                case State.paused:
                    //do pause
                    break;
                case (State.exploding):
                    // animate exploion.
                    break;
                case (State.moving):
                    //move. animate?
                    if (position.Y <= playArea.Bottom)
                    {
                        base.Update(theGameTime, speed, direction);
                    }
                    break;
                default:
                    //err output?
                    break;
            }

        }


        private Vector2 calculateDirection()
        {
            Vector2 tmpDir = Vector2.Zero;
            if (position.X < final_pos.X)
                return new Vector2(MOVE_RIGHT, MOVE_DOWN);
            else
                return new Vector2(MOVE_LEFT, MOVE_DOWN);
        }


        private float calculateSlope()
        {
            float tmpSlope = 180f;

            return tmpSlope;
        }


        private Vector2 calculateSpeed()
        {
            float deltaX = Math.Abs(position.X - final_pos.X);
            float deltaY = Math.Abs(position.Y - final_pos.Y);
            float percent;
            if (deltaX > deltaY)
            {
                percent = deltaY / deltaX;
                return new Vector2((percent) * speedTotal, (1 - percent) * speedTotal);
            }
            else
            {
                percent = deltaX / deltaY;
                return new Vector2((1 - percent) * speedTotal, percent * speedTotal);
            }
        }

        public void setMisslePlayArea(Rectangle mPlayArea)
        {
            playArea = mPlayArea;
        }


    }
}
