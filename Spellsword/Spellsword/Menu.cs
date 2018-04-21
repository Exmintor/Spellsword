using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class Menu : Sprite
    {
        protected Game thisGame;
        protected MenuScene thisScene;
        protected SpriteFont font;

        protected MenuController controller;
        protected List<ISpellswordCommand> currentCommands;
        protected int currentTopCommand;

        public Menu(Game game, MenuScene scene) : this(game, scene, new List<ISpellswordCommand>())
        {

        }

        public Menu(Game game, MenuScene scene, List<ISpellswordCommand> commands)
        {
            thisGame = game;
            this.thisScene = scene;
            controller = new MenuController(game);
            currentCommands = commands;
            currentTopCommand = 0;

            font = game.Content.Load<SpriteFont>("Arial");
            CurrentSprite = game.Content.Load<Texture2D>("Menu");
            AnchorTopLeft(game);
        }

        public virtual void Update()
        {
            controller.Update(this);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            DrawCommands(spriteBatch);
        }

        protected virtual void DrawCommands(SpriteBatch spriteBatch)
        {
            Vector2 startingLocation = this.Location + new Vector2(10, 10);
            Vector2 currentLocation = startingLocation;
            for (int i = currentTopCommand; i < Math.Min(currentCommands.Count, 10); i++)
            {
                currentLocation += Parameters.battleCommandXOffset;

                if (i == controller.CurrentIndex)
                {
                    spriteBatch.DrawString(font, "> ", currentLocation + Parameters.arrowOffset, Color.White);
                }
                DrawCommand(currentCommands[i].Name, currentLocation, spriteBatch);
            }
        }

        protected virtual void DrawCommand(string commandName, Vector2 commandLocation, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, commandName, commandLocation, Color.White);
        }

        public bool IsOnCommandList(int index)
        {
            if (index <= currentCommands.Count - 1 && index >= 0)
            {
                return true;
            }
            return false;
        }

        public void AddCommand(ISpellswordCommand command)
        {
            currentCommands.Add(command);
        }
        public void RemoveCommand(ISpellswordCommand command)
        {
            currentCommands.Remove(command);
        }
        public void ExecuteCommand(int index)
        {
            if (IsOnCommandList(index))
            {
                currentCommands[index].Execute();
            }
        }


        protected void AnchorTopLeft(Game game)
        {
            Location = new Vector2(0,0);
        }

        protected void AnchorTopRight(Game game)
        {
            Location = new Vector2(game.GraphicsDevice.Viewport.Width - CurrentSprite.Width, 0);
        }

        protected void AnchorBottomLeft(Game game)
        {
            Location = new Vector2(0, game.GraphicsDevice.Viewport.Height - CurrentSprite.Height);
        }

        protected void AnchorBotomRight(Game game)
        {
            Location = new Vector2(game.GraphicsDevice.Viewport.Width - CurrentSprite.Width, game.GraphicsDevice.Viewport.Height - CurrentSprite.Height);
        }
    }
}
