using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Zombie : Enemy
    {
        public Zombie(string worldImage, string battleImage) : base(worldImage, battleImage)
        {
            MaxHealth = 100;
            Health = 100;
            Strength = 2;
            Magic = 1;
            Defense = 3;

            this.AddWeakness(Element.Fire);

            basicAction = new BasicEnemyAttack(this, Element.None, 25);

            Talent iceTalent = new AddSpellTalent("Ice Lance", 1);
            List<Talent> talentReward = new List<Talent>();
            talentReward.Add(iceTalent);
            Reward = new Reward(1, talentReward);
        }
    }
}
