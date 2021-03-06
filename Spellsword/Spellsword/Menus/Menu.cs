﻿using Microsoft.Xna.Framework;
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
        protected SpellswordGame thisGame;
        protected SpriteFont font;

        protected MenuController controller;
        protected List<ISpellswordCommand> currentCommands;
        protected int currentTopCommand;

        public Menu(SpellswordGame game) : this(game, new List<ISpellswordCommand>())
        {

        }

        public Menu(SpellswordGame game, List<ISpellswordCommand> commands)
        {
            thisGame = game;
            controller = new MenuController(game);
            currentCommands = commands;
            currentTopCommand = 0;

            this.color = new Color(Color.Black, 0.85f);
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

        public virtual void DrawWithOffset(SpriteBatch spriteBatch, Vector2 offset)
        {
            base.Draw(spriteBatch);
            DrawCommands(spriteBatch, offset);
        }

        protected virtual void DrawCommands(SpriteBatch spriteBatch)
        {
            DrawCommands(spriteBatch, this.Location + new Vector2(20, 10));
        }

        protected virtual void DrawCommands(SpriteBatch spriteBatch, Vector2 offset)
        {
            Vector2 startingLocation = offset;
            Vector2 currentLocation = startingLocation;
            for (int i = currentTopCommand; i < Math.Min(currentCommands.Count, 10); i++)
            {
                if (i == controller.CurrentIndex)
                {
                    spriteBatch.DrawString(font, "> ", currentLocation + Parameters.arrowOffset, Color.White);
                }
                DrawCommand(currentCommands[i].Name, currentLocation, spriteBatch);
                currentLocation += Parameters.battleCommandYOffset;
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
        public void AddCommands(List<ISpellswordCommand> commands)
        {
            currentCommands.AddRange(commands);
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
