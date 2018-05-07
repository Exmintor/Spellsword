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
        private Game game;
        private Character enemy;

        public BattleEnemy(Game game, BattleScene currentScene, Character enemy)
        {
            this.CurrentSprite = game.Content.Load<Texture2D>(enemy.BattleImage);
            this.Location = Parameters.battleEnemyLocation;

            this.currentScene = currentScene;
            this.ThisEntity = enemy;

            this.game = game;
            this.enemy = enemy;
        }

        public override void Update()
        {
            base.Update();
            RefreshEnemyImage();
        }
        private void RefreshEnemyImage()
        {
            this.CurrentSprite = game.Content.Load<Texture2D>(enemy.BattleImage);
        }
    }
}
