using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Welp : Enemy
    {
        public Welp(string worldImage, string battleImage) : base(worldImage, battleImage)
        {
            MaxHealth = 180;
            Health = 180;
            Strength = 3;
            Magic = 3;
            Defense = 3;
            this.AddResistance(Element.Fire);
            this.AddWeakness(Element.Lightning);

            basicAction = new BasicEnemyAttack(this, Element.Fire, 30);

            Talent magicShieldTalent = new AddSpellTalent("Magic Shield", 3);
            List<Talent> talentRewards = new List<Talent>();
            talentRewards.Add(magicShieldTalent);
            Reward = new Reward(2, talentRewards);
        }
    }
}
