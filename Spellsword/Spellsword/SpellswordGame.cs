﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spellsword.Scenes;

namespace Spellsword
{
    public enum GameState { World, Paused, Battle, EquipmentMenu, TalentTree }
    public class SpellswordGame : Game
    {
        public GameState CurrentState { get; private set; }

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private WalkingScene walkingScene;
        private BattleScene battleScene;

        public SpellswordGame()
        {
            graphics = new GraphicsDeviceManager(this);
            int size = (11 * 32) + 11 - 1;
            graphics.PreferredBackBufferHeight = size;
            graphics.PreferredBackBufferWidth = size;
            Content.RootDirectory = "Content";

            this.CurrentState = GameState.World;
        }

        protected override void Initialize()
        {
            base.Initialize();
            Point gameSize = new Point(11, 11);
            World gameWorld = new World(gameSize, Content.Load<Texture2D>("BaseTile"));
            WalkingPlayer player = new WalkingPlayer(this, gameWorld);
            walkingScene = new WalkingScene(this, gameWorld, player);
            battleScene = new BattleScene(this, null, null);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            switch(CurrentState)
            {
                case GameState.World:
                    walkingScene.Update(gameTime);
                    break;
                case GameState.Paused:
                    break;
                case GameState.Battle:
                    battleScene.Update(gameTime);
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            switch(CurrentState)
            {
                case GameState.World:
                    walkingScene.Draw(spriteBatch);
                    break;
                case GameState.Paused:
                    walkingScene.Draw(spriteBatch);
                    break;
                case GameState.Battle:
                    GraphicsDevice.Clear(Color.Red);
                    battleScene.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void InitiateBattle(Entity player, Entity enemy)
        {
            this.battleScene.ChangeCombatants(this, player, enemy);
            this.CurrentState = GameState.Battle;
        }

        public void SwitchToWorld()
        {
            this.CurrentState = GameState.World;
        }
    }
}