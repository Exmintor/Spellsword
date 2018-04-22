using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class TextMenu : Menu
    {
        private List<string> currentText;

        public TextMenu(SpellswordGame game, List<string> currentText) : base(game)
        {
            this.color = new Color(Color.Black, 1f);
            CurrentSprite = game.Content.Load<Texture2D>("EquipmentMenu");
            this.AnchorTopRight(game);

            this.currentText = currentText;
        }

        public TextMenu(SpellswordGame game, string currentText) : this(game, new List<string> { currentText })
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Vector2 startingLocation = this.Location + new Vector2(20, 10);
            DrawText(spriteBatch, startingLocation);
        }

        protected virtual void DrawText(SpriteBatch spriteBatch, Vector2 location)
        {
            foreach (string thing in currentText)
            {
                spriteBatch.DrawString(font, thing, location, Color.White);
                location += Parameters.battleCommandYOffset;
            }
        }

        protected override void DrawCommands(SpriteBatch spriteBatch)
        {
            
        }

        public void SwitchOutString(List<string> replacement)
        {
            currentText = replacement;
        }

        public void SwitchOutString(string replacement)
        {
            currentText.Clear();
            currentText.Add(replacement);
        }
    }
}
