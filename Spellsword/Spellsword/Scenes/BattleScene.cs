using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword.Scenes
{
    public class BattleScene
    {
        private SpellswordGame game;
        private Entity player;
        private Entity enemy;

        public BattleScene(SpellswordGame game, Entity player, Entity enemy)
        {
            this.game = game;
            this.player = player;
            this.enemy = enemy;
        }

        public void ChangeCombatants(Entity player, Entity enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void Update(GameTime gameTime)
        {
            //Temp test
            if(Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                game.SwitchToWorld();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Temp test
            spriteBatch.Draw(game.Content.Load<Texture2D>("BaseTile"), new Vector2(0, 0), Color.Red);
        }
    }
}
