using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Poison : IAction, IStatusEffect
    {
        public Character User { get; protected set; }
        public int Duration { get; private set; }

        public int Priority { get; private set; }

        public string Name { get; private set; }
        public string Description { get; protected set; }
        public Element AttackElement { get; protected set; }

        private int damagePerTurn;

        public Poison(Character attacker, int duration, int damagePerTurn)
        {
            this.User = attacker;
            this.Name = "Poison";
            this.Duration = duration;
            this.damagePerTurn = damagePerTurn + User.Magic;
            this.Description = "Deals " + this.damagePerTurn + " damage to target each turn for " + Duration + " turns.";
            this.AttackElement = Element.None;

            this.Priority = 2;
        }

        public void BeforeTick(Character attachedEntity)
        {
            //Do nothing
        }
        public void AfterTick(Character attachedEntity)
        {
            attachedEntity.TakeDamage(damagePerTurn, AttackElement);
            Duration--;
            if(Duration <= 0)
            {
                attachedEntity.RemoveStatusEffect(this);
            }
        }

        public void Apply(Character attachedEntity)
        {
            //Do Nothing
        }

        public void Remove(Character attachedEntity)
        {
            //Do nothing
        }
    }
}
