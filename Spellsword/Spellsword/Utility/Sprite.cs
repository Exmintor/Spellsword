using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spellsword
{
    public abstract class Sprite
    {
        public Texture2D CurrentSprite { get; set; }
        public Vector2 Location { get; set; }
        public float CurrentScale { get; protected set; }
        protected Color color = Color.White;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CurrentSprite, Location, color);
        }
    }
}
