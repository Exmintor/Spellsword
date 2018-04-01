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
        private InputHandler inputHandler;

        private int whichHand = 1;

        public MenuController(Game game)
        {
            inputHandler = game.Services.GetService<InputHandler>();
            if (inputHandler == null)
            {
                inputHandler = new InputHandler(game);
                game.Components.Add(inputHandler);
            }
        }

        public void Update(EquipmentMenu menu)
        {
            if(inputHandler.WasButtonPressed(Keys.D1))
            {
                whichHand = 1;
            }
            if(inputHandler.WasButtonPressed(Keys.D2))
            {
                whichHand = 2;
            }
            if(inputHandler.WasButtonPressed(Keys.D3))
            {
                if(menu.NumberOfWeapons >= 1)
                {
                    menu.ChangeEquipment(whichHand, 0);
                }
            }
            if (inputHandler.WasButtonPressed(Keys.D4))
            {
                if (menu.NumberOfWeapons >= 2)
                {
                    menu.ChangeEquipment(whichHand, 1);
                }
            }
            if (inputHandler.WasButtonPressed(Keys.D5))
            {
                if (menu.NumberOfWeapons >= 3)
                {
                    menu.ChangeEquipment(whichHand, 2);
                }
            }
            if (inputHandler.WasButtonPressed(Keys.D6))
            {
                if (menu.NumberOfWeapons >= 4)
                {
                    menu.ChangeEquipment(whichHand, 3);
                }
            }
            if (inputHandler.WasButtonPressed(Keys.D7))
            {
                if (menu.NumberOfWeapons >= 5)
                {
                    menu.ChangeEquipment(whichHand, 4);
                }
            }
        }
    }
}
