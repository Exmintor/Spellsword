using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Ghost : Enemy
    {
        public Ghost(string worldImage, string battleImage) : base(worldImage, battleImage)
        {
            MaxHealth = 100;
            Health = 100;
            Strength = 1;
            Magic = 3;
            Defense = 2;
            this.AddResistance(Element.None);
            this.AddWeakness(Element.Ice);

            basicAction = new Poison(this, 2, 15);

            Reward = new Reward(1);
        }

        public override IAction ChooseAction()
        {
            return new Poison(this, 2, 15);
        }
    }
}
