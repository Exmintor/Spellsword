using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Wraith : Enemy
    {
        public Wraith(string worldImage, string battleImage) : base(worldImage, battleImage)
        {
            MaxHealth = 200;
            Health = 200;
            Strength = 2;
            Magic = 4;
            Defense = 4;
            this.AddWeakness(Element.Ice);
            this.AddResistance(Element.Lightning);

            basicAction = new BasicEnemyAttack(this, Element.Lightning, 35);

            Talent lightningTalent = new AddSpellTalent("Lightning", 2);
            List<Talent> talentRewards = new List<Talent>();
            talentRewards.Add(lightningTalent);
            Reward = new Reward(2, talentRewards);
        }
    }
}
