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
        protected SpriteFont font;

        public Menu(Game game)
        {
            font = game.Content.Load<SpriteFont>("Arial");
            CurrentSprite = game.Content.Load<Texture2D>("Menu");
            AnchorTopLeft(game);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
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
