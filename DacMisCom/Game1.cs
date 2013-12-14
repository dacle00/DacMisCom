using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;

namespace DacMisCom
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        const int BUFFER_MISSILE_SIDE = 100;
        const int BUFFER_MISSILE_TOP = 100;
        const int BUFFER_GROUND_LEVEL_BOTTOM = 40;  //default screen is 480 tall
        const int groundLevel = 440;  // default screen is 480 tall
        
        SpriteBatch spriteBatch;
        const int numCities = 3;
        City[] cities = new City[numCities];
        Shield[] shields = new Shield[numCities];
        Color[] CityColors = { Color.AliceBlue, Color.Aqua, Color.Aquamarine, Color.Azure, Color.Blue, Color.BlueViolet, Color.CadetBlue, Color.Cyan, Color.DarkBlue, Color.DarkCyan, Color.DarkOrchid };
        Color[] ShieldColors = { Color.Wheat, Color.Thistle, Color.Tan, Color.SeaShell, Color.PapayaWhip, Color.PaleGoldenrod, Color.Linen };
        Color missileColor = Color.Tomato;
        Vector2 missileInitialPosition = new Vector2(400,240);
        Vector2 missileFinalPosition = new Vector2(600, groundLevel);
        int numMissiles = 0;
        int maxNumMissiles = 1;
        Rectangle missilePlayArea;
        int missileSpeedTotal = 200;
        ArrayList missiles = new ArrayList();
        BallisticMissile tmpMissile;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            Random r = new Random(DateTime.Now.Second);
            // TODO: Add your initialization logic here
            for (int i = 0; i < numCities; i++)
            {
                cities[i] = new City();
                cities[i].color = CityColors[r.Next(CityColors.Length - 1)];
                cities[i].shield.color = ShieldColors[r.Next(ShieldColors.Length - 1)];
            }

            missileInitialPosition = new Vector2(100, 100);
            missileFinalPosition = new Vector2(groundLevel, 100);
            tmpMissile = new BallisticMissile(0, missileInitialPosition, missileFinalPosition);

            base.Initialize();

            missilePlayArea = new Rectangle(-BUFFER_MISSILE_SIDE, -BUFFER_MISSILE_TOP, graphics.PreferredBackBufferWidth + (2 * BUFFER_MISSILE_SIDE), graphics.PreferredBackBufferHeight + BUFFER_MISSILE_TOP - BUFFER_GROUND_LEVEL_BOTTOM);
            tmpMissile.setMisslePlayArea(missilePlayArea);
        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            int y;
            int x_seg = (graphics.PreferredBackBufferWidth / numCities);
            for (int i = 0; i < numCities; i++)
            {
                cities[i].LoadContent(this.Content, "City");
                cities[i].shield.LoadContent(this.Content, "Shield");
                int x = i * x_seg + (x_seg / 2) - (cities[0].size.Width / 2);
                y = groundLevel - cities[i].size.Height;
                cities[i].position = new Vector2(x, y);
                cities[i].shield.setPositionByCenter(new Rectangle((int)cities[i].position.X, (int)cities[i].position.Y, cities[i].size.Width, cities[i].size.Height));
            }

            tmpMissile.LoadContent(this.Content, "Missile1");
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (numMissiles < maxNumMissiles)
            {
                tmpMissile = new BallisticMissile(missileSpeedTotal, missileInitialPosition, missileFinalPosition);
                tmpMissile.setMisslePlayArea(missilePlayArea);
                missiles.Add(tmpMissile);
            }

            for (int i =0; i<missiles.Count; i++)
            {
                tmpMissile = (BallisticMissile)missiles[i];
                tmpMissile.Update(gameTime);
            }

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            {
                for (int i = 0; i < numCities; i++)
                {
                    cities[i].Draww(this.spriteBatch, cities[i].color);
                }

                for (int i = 0; i < missiles.Count; i++)
                {
                    tmpMissile = (BallisticMissile)missiles[i];
                    tmpMissile.Draw(this.spriteBatch, missileColor);
                }
            }
            //missiles[i].Draw(this.spriteBatch, missileColor); //, missiles.slope);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
