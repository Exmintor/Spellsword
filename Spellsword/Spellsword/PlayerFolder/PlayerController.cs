using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class PlayerController
    {
        private InputHandler inputHandler;

        public PlayerController(Game game)
        {
            inputHandler = game.Services.GetService<InputHandler>();
            if(inputHandler == null)
            {
                inputHandler = new InputHandler(game);
                game.Components.Add(inputHandler);
            }
        }

        public void Update(WalkingPlayer player)
        {
            if(inputHandler.WasButtonPressed(Keys.Space))
            {
                player.Interact();
            }
            if(inputHandler.IsButtonHeld(Keys.W) || inputHandler.WasButtonPressed(Keys.W))
            {
                player.MoveUp();
            }
            else if (inputHandler.IsButtonHeld(Keys.S) || inputHandler.WasButtonPressed(Keys.S))
            {
                player.MoveDown();
            }
            else if (inputHandler.IsButtonHeld(Keys.A) || inputHandler.WasButtonPressed(Keys.A))
            {
                player.MoveLeft();
            }
            else if (inputHandler.IsButtonHeld(Keys.D) || inputHandler.WasButtonPressed(Keys.D))
            {
                player.MoveRight();
            }
            else
            {
                player.Stop();
            }
        }
    }
}
