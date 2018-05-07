using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Spellsword.Scenes;
using System.Collections.Generic;

namespace Spellsword
{
    public enum GameState { World, Paused, Battle, MainMenu, WinState }
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
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.CurrentState = GameState.World;
            SwitchSong();
            Point gameSize = new Point(17, 23);
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
                case GameState.WinState:
                    walkingScene.Update(gameTime);
                    if(inputHandler.WasButtonPressed(Keys.R))
                    {
                        ResetGame();
                    }
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
                case GameState.WinState:
                    walkingScene.Draw(spriteBatch);
                    spriteBatch.DrawString(Content.Load<SpriteFont>("Arial"), "    YOU WIN!\nPress 'R' to Reset", new Vector2(150, 150), Color.Red);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void InitiateBattle(Character player, Character enemy)
        {
            this.battleScene = new BattleScene(this, player, enemy);
            this.CurrentState = GameState.Battle;
            SwitchBattleSong(enemy);
        }

        public void SwitchToWorld()
        {
            this.CurrentState = GameState.World;
            if(previousState == GameState.Battle)
            {
                battleScene.UnsubscribeDeathHandlers();
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

        public void ResetGame()
        {
            Initialize();
        }

        public void GameWon()
        {
            this.CurrentState = GameState.WinState;
            if (previousState == GameState.Battle)
            {
                battleScene.UnsubscribeDeathHandlers();
                SwitchSong();
            }
        }

        public void OpenMenu(Player player)
        {
            MainMenu menu = new MainMenu(this, menuScene);
            menu.AddCommands(GetMenuCommands(menuScene, menu, player));
            menuScene = new MenuScene(this, menu);
            this.CurrentState = GameState.MainMenu;
        }

        public void SwitchOutMenu(Menu newMenu)
        {
            if(newMenu is BattleMenu)
            {
                battleScene.SetBattleMenu((BattleMenu)newMenu);
            }
            else
            {
                menuScene = new MenuScene(this, newMenu);
            }
        }

        private List<ISpellswordCommand> GetMenuCommands(MenuScene scene, Menu mainMenu, Player player)
        {
            List<ISpellswordCommand> menuCommands = new List<ISpellswordCommand>();
            EquipmentMenu equipmentMenu = new EquipmentMenu(this, player);
            SwitchMenuCommand equipmentMenuCommand = new SwitchMenuCommand("Equipment", this, mainMenu, equipmentMenu);
            menuCommands.Add(equipmentMenuCommand);

            TalentMenu talentMenu = new TalentMenu(this, player);
            SwitchMenuCommand talentMenuCommand = new SwitchMenuCommand("Talents", this, mainMenu, talentMenu);
            menuCommands.Add(talentMenuCommand);

            StatusMenu statusMenu = new StatusMenu(this, player);
            SwitchMenuCommand statusMenuCommand = new SwitchMenuCommand("Player Status", this, mainMenu, statusMenu);
            menuCommands.Add(statusMenuCommand);

            SpellMenu spellMenu = new SpellMenu(this, player);
            SwitchMenuCommand spellMenuCommand = new SwitchMenuCommand("Current Spells", this, mainMenu, spellMenu);
            menuCommands.Add(spellMenuCommand);

            return menuCommands;
        }

        private void SwitchSong()
        {
            MediaPlayer.Stop();
            switch(CurrentState)
            {
                case GameState.World:
                    currentSong = this.Content.Load<Song>("WorldMusic");
                    break;
                case GameState.WinState:
                    currentSong = this.Content.Load<Song>("WorldMusic");
                    break;
                case GameState.Battle:
                    currentSong = this.Content.Load<Song>("BattleMusic");
                    break;
            }
            MediaPlayer.Play(currentSong);
            MediaPlayer.IsRepeating = true;
        }

        private void SwitchBattleSong(Character enemy)
        {
            MediaPlayer.Stop();
            if (enemy is Dragon)
            {
                currentSong = this.Content.Load<Song>("DragonMusic");
            }
            else if(enemy is Welp)
            {
                currentSong = this.Content.Load<Song>("WelpMusic");
            }
            else if (enemy is Wraith)
            {
                currentSong = this.Content.Load<Song>("WraithMusic");
            }
            else if (enemy is Zombie)
            {
                currentSong = this.Content.Load<Song>("ZombieMusic");
            }
            else if (enemy is Ghost)
            {
                currentSong = this.Content.Load<Song>("GhostMusic");
            }
            else if (enemy is Flower)
            {
                currentSong = this.Content.Load<Song>("FlowerMusic");
            }
            MediaPlayer.Play(currentSong);
            MediaPlayer.IsRepeating = true;
        }
    }
}
