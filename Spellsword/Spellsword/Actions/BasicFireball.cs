using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicFireball : Attack
    {
        public BasicFireball(Entity attacker)
        {
            this.User = attacker;
            this.Damage = 15 + User.Magic;
        }
    }
}
