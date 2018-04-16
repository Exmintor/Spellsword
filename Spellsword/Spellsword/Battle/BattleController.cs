using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BattleController
    {
        private InputHandler inputHandler;
        public int CurrentIndex { get; private set; }

        public BattleController(Game game)
        {
            CurrentIndex = 0;
            inputHandler = game.Services.GetService<InputHandler>();
            if (inputHandler == null)
            {
                inputHandler = new InputHandler(game);
                game.Components.Add(inputHandler);
            }
        }

        public void Update(BattleMenu menu)
        {
            if(inputHandler.WasButtonPressed(Keys.D) && menu.IsOnCommandList(CurrentIndex + 1) && CurrentIndex % 2 == 0)
            {
                CurrentIndex += 1;
            }
            if(inputHandler.WasButtonPressed(Keys.A) && menu.IsOnCommandList(CurrentIndex - 1) && CurrentIndex % 2 == 1)
            {
                CurrentIndex -= 1;
            }
            if (inputHandler.WasButtonPressed(Keys.W) && menu.IsOnCommandList(CurrentIndex - 2))
            {
                CurrentIndex -= 2;
            }
            if (inputHandler.WasButtonPressed(Keys.S) && menu.IsOnCommandList(CurrentIndex + 2))
            {
                CurrentIndex += 2;
            }
            if(inputHandler.WasButtonPressed(Keys.Space))
            {
                menu.ExecuteCommand(CurrentIndex);
            }
        }

        public void ResetIndex()
        {
            CurrentIndex = 0;
        }
    }
}
