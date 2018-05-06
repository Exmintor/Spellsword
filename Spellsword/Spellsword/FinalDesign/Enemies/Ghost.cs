using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Ghost : Enemy
    {
        public Ghost(string worldImage, string battleImage, IAction action) : base(worldImage, battleImage, action)
        {
            MaxHealth = 50;
            Health = 50;
            Strength = 1;
            Magic = 1;
            Defense = 1;

            Reward = new Reward(1);
        }
    }
}
