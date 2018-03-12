using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BattleMenu : Menu
    {
        public event Action<IAction> ActionChosen;

        private BattleController controller;
        private Entity player;
        private IWeapon currentWeapon;

        public BattleMenu(Game game, Entity player, IWeapon weapon) : base(game)
        {
            controller = new BattleController(game);

            CurrentSprite = game.Content.Load<Texture2D>("BattleMenu");
            AnchorBottomLeft(game);

            this.player = player;
            this.currentWeapon = weapon;
        }

        public void Update()
        {
            controller.Update(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            DrawActions(spriteBatch);
        }

        private void DrawActions(SpriteBatch spriteBatch)
        {
            Vector2 newLocation = this.Location + new Vector2(10, 10);
            spriteBatch.DrawString(font, "1. Attack", newLocation, Color.White);
            if(currentWeapon.IsFocus)
            {
                spriteBatch.DrawString(font, "2. Fireball", newLocation + new Vector2(0, 30), Color.White);
            }
            spriteBatch.DrawString(font, "Attacking with " + currentWeapon.Name, newLocation + new Vector2(10, -40), Color.White);
        }

        public void AttackAction()
        {
            IAction action = new BasicSwordAttack(currentWeapon);
            if(ActionChosen != null)
            {
                ActionChosen.Invoke(action);
            }
        }

        public void DefendAction()
        {
            throw new NotImplementedException();
        }

        public void SwordAction()
        {
            throw new NotImplementedException();
        }

        public void ShieldAction()
        {
            throw new NotImplementedException();
        }

        public void SpellAction(int spellNumber)
        {
            if(currentWeapon.IsFocus)
            {
                // Grab the action from the player's spell list instead.
                IAction action = new BasicFireball();
                if (ActionChosen != null)
                {
                    ActionChosen.Invoke(action);
                }
            }
        }
    }
}
