using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class MenuController
    {
        protected InputHandler inputHandler;
        public int CurrentIndex { get; protected set; }

        public MenuController(Game game)
        {
            CurrentIndex = 0;
            inputHandler = game.Services.GetService<InputHandler>();
            if (inputHandler == null)
            {
                inputHandler = new InputHandler(game);
                game.Components.Add(inputHandler);
            }
        }

        public virtual void Update(Menu menu)
        {
            if (inputHandler.WasButtonPressed(Keys.W) && menu.IsOnCommandList(CurrentIndex - 1))
            {
                CurrentIndex -= 1;
            }
            if (inputHandler.WasButtonPressed(Keys.S) && menu.IsOnCommandList(CurrentIndex + 1))
            {
                CurrentIndex += 1;
            }
            if (inputHandler.WasButtonPressed(Keys.Space))
            {
                ResetIndex();
                menu.ExecuteCommand(CurrentIndex);
            }
        }

        public void ResetIndex()
        {
            CurrentIndex = 0;
        }
    }
}
