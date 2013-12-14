using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DacMisCom
{
    class GameInput
    {

        Keys Pause          = Keys.P;
        Keys ShowDebug      = Keys.F3;
        Keys RestartGame    = Keys.F12;
        Keys RestartLevel   = Keys.F11;
        Keys Shield1        = Keys.D1;
        Keys Shield2        = Keys.D2;
        Keys Shield3        = Keys.D3;
        Keys Shield4        = Keys.D4;
        Keys Shield5        = Keys.D5;
        Keys Shield6        = Keys.D6;
        Keys Shield7        = Keys.D7;
        Keys Shield8        = Keys.D8;
        Keys Shield9        = Keys.D9;
        Keys Bomb           = Keys.Space;
        //TODO: unable to pre-define a Mouse Left Button??
        //Buttons Fire        = MOUSE LEFT BUTTON!!

        KeyboardState KState, KState_prev;
        MouseState MState, MState_prev;

        public GameInput()
        {
            KState = new KeyboardState();
            KState_prev = new KeyboardState();
            MState = new MouseState();
            MState_prev = new MouseState();
        }


        public void Update()
        {
            if (KState.Equals(KState_prev))
            {
                //check inputs & do actions
                DoCommonInput();
                DoShieldToggles();
                // DoWeaponInput();  // called from outisde this class

                KState_prev = KState;
                MState_prev = MState;
            }
        }


        private void DoCommonInput()
        {
            if (KState.IsKeyDown(Pause) && KState_prev.IsKeyUp(Pause))
            {
                // Pause the Game
            }
            if (KState.IsKeyDown(ShowDebug) && KState_prev.IsKeyUp(ShowDebug))
            {
                // Toggle ShowDebug
            }
            if (KState.IsKeyDown(RestartGame) && KState_prev.IsKeyUp(RestartGame))
            {
                // Restart Game, re-initialize at level1
            }
            if (KState.IsKeyDown(RestartLevel) && KState_prev.IsKeyUp(RestartLevel))
            {
                // Restart Level, re-initialize at Current Level
            }
        }


        public void DoWeaponInput(Vector2 cursorCoord, bool cursorIntersectsCity, ref City closestCity, ref City closestArmedCity)
        {
            if (KState.IsKeyDown(Bomb) && KState_prev.IsKeyUp(Bomb))
            {
                // launch patriot bomb if avail (clears all enemy missiles
            }
            if (MState.LeftButton == ButtonState.Pressed && MState_prev.LeftButton == ButtonState.Released)
            {
                if (cursorIntersectsCity)
                {
                    if (closestCity.shield.currentState == Shield.State.inactive)
                    {
                        // turn on city shield
                        // play shield on sound
                        // begin shield countdown
                    }
                    else if (closestCity.shield.currentState == Shield.State.active)
                    {
                        // shield is already on, play err sound & flash city
                        // flash shield
                    }
                    else
                    {
                        // shield is still charging
                        // play err sound & flash city 
                    }
                }
                else
                {
                    // fire defensive laser from city, if avail (cities take time to charge up)
                    if (closestArmedCity.currentState == City.State.armed)
                    {
                        // FIRE Defensive measures!!
                    }
                    else if (closestArmedCity.currentState == City.State.reloading ||
                             closestArmedCity.currentState == City.State.dead)
                    {
                        // city is not ready to fire.  ignore, move on to next city.
                    }
                    else
                    {
                        // final state = game is paused
                    }
                }
            }




        }

        
        private void DoShieldToggles()
        {
            if (KState.IsKeyDown(Shield1) && KState_prev.IsKeyUp(Shield1))
            {
                //toggleshield on city[1]
            }
            if (KState.IsKeyDown(Shield2) && KState_prev.IsKeyUp(Shield2))
            {
                //toggleshield on city[2]
            }
            if (KState.IsKeyDown(Shield3) && KState_prev.IsKeyUp(Shield3))
            {
                //toggleshield on city[3]
            }
            if (KState.IsKeyDown(Shield4) && KState_prev.IsKeyUp(Shield4))
            {
                //toggleshield on city[4]
            }
            if (KState.IsKeyDown(Shield5) && KState_prev.IsKeyUp(Shield5))
            {
                //toggleshield on city[5]
            }
            if (KState.IsKeyDown(Shield6) && KState_prev.IsKeyUp(Shield6))
            {
                //toggleshield on city[6]
            }
            if (KState.IsKeyDown(Shield7) && KState_prev.IsKeyUp(Shield7))
            {
                //toggleshield on city[7]
            }
            if (KState.IsKeyDown(Shield8) && KState_prev.IsKeyUp(Shield8))
            {
                //toggleshield on city[8]
            }
            if (KState.IsKeyDown(Shield9) && KState_prev.IsKeyUp(Shield9))
            {
                //toggleshield on city[9]
            }
        }

    
    }
}
