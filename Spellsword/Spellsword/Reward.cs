using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Reward
    {
        public int TalentPoints { get; private set; }
        public List<Talent> GainedTalents { get; private set; }
        public List<Weapon> GainedWeapons { get; private set; }

        public Reward(int talentPoints = 0, List<Talent> gainedTalents = null, List<Weapon> gainedWeapons = null)
        {
            TalentPoints = talentPoints;
            GainedTalents = gainedTalents;
            GainedWeapons = gainedWeapons;
        }
    }
}
