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

        public BattleController(Game game)
        {
            inputHandler = game.Services.GetService<InputHandler>();
            if (inputHandler == null)
            {
                inputHandler = new InputHandler(game);
                game.Components.Add(inputHandler);
            }
        }

        public void Update(BattleMenu menu)
        {
            if(inputHandler.WasButtonPressed(Keys.D1))
            {
                menu.AttackAction();
            }
            if(inputHandler.WasButtonPressed(Keys.D2))
            {
                menu.SpellAction(0);
            }
        }
    }
}
