using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spellsword.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BattleEnemy : BattleEntity
    {
        public BattleEnemy(Game game, BattleScene currentScene, Enemy enemy)
        {
            this.CurrentSprite = game.Content.Load<Texture2D>("Ghost");
            this.Location = new Vector2(180, 20);

            this.currentScene = currentScene;
            this.ThisEntity = enemy;
        }
    }
}
