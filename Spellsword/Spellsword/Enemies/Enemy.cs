using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Enemy : Character
    {
        protected IWeapon basicWeapon;
        public Reward Reward { get; protected set; }
        public Enemy(string worldImage, string battleImage) : base(worldImage, battleImage)
        {
            basicWeapon = new BasicSword();

            MaxHealth = 50;
            Health = 50;
            Strength = 1;
            Magic = 1;
            Defense = 1;

            Reward = new Reward(1);
        }

        public override IAction ChooseAction()
        {
            IAction action = new Poison(this, 2, 3);
            return action;
        }

        public override void TakeDamage(int damage, Element element)
        {
            //TODO: Override with damage calculation
            base.TakeDamage(damage, element);
        }
    }
}
