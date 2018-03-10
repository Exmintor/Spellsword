using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Spellsword
{
    public class InputHandler : GameComponent
    {
        private KeyboardState currentState;
        private KeyboardState previousState;
        public InputHandler(Game game) : base(game)
        {
            currentState = Keyboard.GetState();
            previousState = Keyboard.GetState();
        }

        public override void Update(GameTime gameTime)
        {
            previousState = currentState;
            currentState = Keyboard.GetState();
            base.Update(gameTime);
        }

        public bool IsButtonHeld(Keys key)
        {
            if(currentState.IsKeyDown(key) && previousState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        public bool WasButtonPressed(Keys key)
        {
            if(currentState.IsKeyDown(key) && !previousState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }
    }
}
