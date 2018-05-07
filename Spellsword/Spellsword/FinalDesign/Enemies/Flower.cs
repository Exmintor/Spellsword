using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Flower : Enemy
    {
        public Flower(string worldImage, string battleImage) : base(worldImage, battleImage)
        {
            MaxHealth = 50;
            Health = 50;
            Strength = 1;
            Magic = 1;
            Defense = 1;

            this.AddWeakness(Element.Fire);

            basicAction = new BasicEnemyAttack(this, Element.None, 15);

            Reward = new Reward(1);
        }
    }
}
