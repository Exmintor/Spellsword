using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class EquipmentScene : MenuScene
    {
        private InputHandler inputHandler;

        private SpellswordGame game;

        public EquipmentScene(SpellswordGame game, Player player)
        {
            inputHandler = game.Services.GetService<InputHandler>();
            if (inputHandler == null)
            {
                inputHandler = new InputHandler(game);
                game.Components.Add(inputHandler);
            }

            this.game = game;
            currentMenu = new EquipmentMenu(game, player);
        }

        public void Update(GameTime gameTime)
        {
            if(inputHandler.WasButtonPressed(Keys.E))
            {
                game.SwitchToWorld();
            }
            currentMenu.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentMenu.Draw(spriteBatch);
        }
    }
}
