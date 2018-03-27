using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Enemy : Entity
    {
        private IWeapon basicWeapon;

        public Enemy()
        {
            basicWeapon = new BasicSword();

            Health = 50;
        }

        public override IAction ChooseAction()
        {
            IAction action = new Poison(2, 15);
            return action;
        }

        public override void TakeDamage(int damage)
        {
            //TODO: Override with damage calculation
            base.TakeDamage(damage);
        }
    }
}
