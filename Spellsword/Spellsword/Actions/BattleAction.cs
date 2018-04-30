using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BattleAction
    {
        private Character attacker;
        private Character target;
        private IAction action;

        public BattleAction(Character attacker, Character target, IAction action)
        {
            this.attacker = attacker;
            this.target = target;
            this.action = action;
        }

        public void Resolve()
        {
            if(action is Attack)
            {
                int damage = ((Attack)action).Damage;
                target.TakeDamage(damage, action.AttackElement);
            }
            if(action is IStatusEffect) // Not good because I probably want to decouple Actions from Effects
            {
                target.AddStatusEffect((IStatusEffect)action);
            }
        }
    }
}
