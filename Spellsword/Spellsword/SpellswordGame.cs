using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Spellsword.Scenes;
using System.Collections.Generic;

namespace Spellsword
{
    public enum GameState { World, Paused, Battle, MainMenu }
    public class SpellswordGame : Game
    {
        private Song currentSong;
        private InputHandler inputHandler;

        private GameState currentState;
        public GameState CurrentState
        {
            get
            {
                return currentState;
            }
            private set
            {
                previousState = currentState;
                currentState = value;
            }
        }
        private GameState previousState;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private WalkingScene walkingScene;
        private BattleScene battleScene;
        private MenuScene menuScene;

        public SpellswordGame()
        {
            inputHandler = this.Services.GetService<InputHandler>();
            if (inputHandler == null)
            {
                inputHandler = new InputHandler(this);
                this.Components.Add(inputHandler);
            }

            graphics = new GraphicsDeviceManager(this);
            int size = (Parameters.numTiles * Parameters.tileSize) + Parameters.numTiles - 1;
            graphics.PreferredBackBufferHeight = size;
            graphics.PreferredBackBufferWidth = size;
            Content.RootDirectory = "Content";

            this.CurrentState = GameState.World;
            SwitchSong();
        }

        protected override void Initialize()
        {
            base.Initialize();
            Point gameSize = new Point(Parameters.numTiles, Parameters.numTiles);
            World gameWorld = new World(gameSize, Content.Load<Texture2D>("BaseTile"));
            WalkingPlayer player = new WalkingPlayer(this, gameWorld);
            walkingScene = new WalkingScene(this, gameWorld, player);
            battleScene = null;
            menuScene = null;
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
                    if(inputHandler.WasButtonPressed(Keys.P))
                    {
                        SwitchToWorld();
                    }
                    break;
                case GameState.Battle:
                    battleScene.Update(gameTime);
                    break;
                case GameState.MainMenu:
                    menuScene.Update(gameTime);
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
                    spriteBatch.DrawString(Content.Load<SpriteFont>("Arial"), "Paused", new Vector2(150, 150), Color.Red);
                    break;
                case GameState.Battle:
                    GraphicsDevice.Clear(Color.Red);
                    battleScene.Draw(spriteBatch);
                    break;
                case GameState.MainMenu:
                    walkingScene.Draw(spriteBatch);
                    menuScene.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void InitiateBattle(Character player, Character enemy)
        {
            this.battleScene = new BattleScene(this, player, enemy);
            this.CurrentState = GameState.Battle;
            SwitchSong();
        }

        public void SwitchToWorld()
        {
            this.CurrentState = GameState.World;
            if(previousState == GameState.Battle)
            {
                SwitchSong();
            }
            if(previousState == GameState.Paused)
            {
                MediaPlayer.Resume();
            }
        }

        public void PauseGame()
        {
            this.CurrentState = GameState.Paused;
            MediaPlayer.Pause();
        }

        public void OpenMenu(Player player)
        {
            MainMenu menu = new MainMenu(this, menuScene);
            menu.AddCommands(GetMenuCommands(menuScene, menu, player));
            menuScene = new MenuScene(this, menu);
            this.CurrentState = GameState.MainMenu;
        }

        private List<ISpellswordCommand> GetMenuCommands(MenuScene scene, Menu mainMenu, Player player)
        {
            List<ISpellswordCommand> menuCommands = new List<ISpellswordCommand>();
            EquipmentMenu equipmentMenu = new EquipmentMenu(this, scene, player);
            SwitchMenuCommand equipmentMenuCommand = new SwitchMenuCommand("Equipment", scene, mainMenu, equipmentMenu);
            menuCommands.Add(equipmentMenuCommand);

            TalentMenu talentMenu = new TalentMenu(this, scene, player);
            SwitchMenuCommand talentMenuCommand = new SwitchMenuCommand("Talents", scene, mainMenu, talentMenu);
            menuCommands.Add(talentMenuCommand);

            return menuCommands;
        }

        private void SwitchSong()
        {
            MediaPlayer.Stop();
            switch(CurrentState)
            {
                case GameState.World:
                    currentSong = this.Content.Load<Song>("WalkingMusic");
                    break;
                case GameState.Battle:
                    currentSong = this.Content.Load<Song>("BattleMusic");
                    break;
            }
            MediaPlayer.Play(currentSong);
            MediaPlayer.IsRepeating = true;
        }
    }
}
