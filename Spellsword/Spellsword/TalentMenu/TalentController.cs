using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class TalentController
    {
        private InputHandler inputHandler;

        public TalentController(Game game)
        {
            inputHandler = game.Services.GetService<InputHandler>();
            if (inputHandler == null)
            {
                inputHandler = new InputHandler(game);
                game.Components.Add(inputHandler);
            }
        }

        public void Update(TalentMenu menu)
        {
            if(inputHandler.WasButtonPressed(Keys.D1))
            {
                menu.ApplyTalent(0);
            }
            if (inputHandler.WasButtonPressed(Keys.D2))
            {
                menu.ApplyTalent(1);
            }
            if (inputHandler.WasButtonPressed(Keys.D3))
            {
                menu.ApplyTalent(2);
            }
            if (inputHandler.WasButtonPressed(Keys.D4))
            {
                menu.ApplyTalent(3);
            }
            if (inputHandler.WasButtonPressed(Keys.D5))
            {
                menu.ApplyTalent(4);
            }
        }
    }
}
