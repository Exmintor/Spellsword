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
    public class MenuScene : Scene
    {
        private InputHandler inputHandler;

        private SpellswordGame game;

        protected Menu currentMenu;

        public MenuScene(SpellswordGame game, Menu menu)
        {
            inputHandler = game.Services.GetService<InputHandler>();
            if (inputHandler == null)
            {
                inputHandler = new InputHandler(game);
                game.Components.Add(inputHandler);
            }

            this.game = game;
            currentMenu = menu;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (inputHandler.WasButtonPressed(Keys.E))
            {
                game.SwitchToWorld();
            }
            currentMenu.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            currentMenu.Draw(spriteBatch);
        }

        public void SwitchOutMenu(Menu oldMenu, Menu newMenu)
        {
            currentMenu = newMenu;
        }
    }
}
