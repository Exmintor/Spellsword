using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Enemy : Character
    {
        protected IAction basicAction;
        public Reward Reward { get; protected set; }
        public Enemy(string worldImage, string battleImage, IAction action) : base(worldImage, battleImage)
        {
            basicAction = action;

            MaxHealth = 50;
            Health = 50;
            Strength = 1;
            Magic = 1;
            Defense = 1;

            Reward = new Reward(1);
        }
        public Enemy(string worldImage, string battleImage) : base(worldImage, battleImage)
        {
            this.basicAction = new Poison(this, 2, 5);

            MaxHealth = 50;
            Health = 50;
            Strength = 1;
            Magic = 1;
            Defense = 1;

            Reward = new Reward(1);
        }

        public override IAction ChooseAction()
        {
            return basicAction;
        }

        public override void TakeDamage(int damage, Element element)
        {
            //TODO: Override with damage calculation
            base.TakeDamage(damage, element);
        }
    }
}
