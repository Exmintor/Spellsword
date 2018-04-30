using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Enemy : Character
    {
        private IWeapon basicWeapon;
        public int PointsOnDefeat { get; private set; }
        public Enemy()
        {
            basicWeapon = new BasicSword();

            Health = 50;
            Strength = 1;
            Magic = 1;
            Defense = 1;

            PointsOnDefeat = 1;
        }

        public override IAction ChooseAction()
        {
            IAction action = new Poison(this, 2, 15);
            return action;
        }

        public override void TakeDamage(int damage, Element element)
        {
            //TODO: Override with damage calculation
            base.TakeDamage(damage, element);
        }
    }
}
