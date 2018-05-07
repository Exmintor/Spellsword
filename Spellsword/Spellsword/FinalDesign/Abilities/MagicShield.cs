using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class MagicShield : Attack, ISelfTargetAction, IStatusEffect
    {
        public int Duration { get; private set; }

        public int Priority { get; private set; }

        private int strength;

        public MagicShield(Character user, int duration, int strength)
        {
            this.User = user;
            Duration = duration;
            this.strength = strength;
            this.Priority = 0;
            this.Name = "Magic Shield";
            this.Description = "Grants " + this.strength + " defense \nand Resistance to all \nElements";
        }

        public void BeforeTick(Character attachedEntity)
        {
            if (Duration <= 0)
            {
                attachedEntity.RemoveStatusEffect(this);
            }
        }

        public void AfterTick(Character attachedEntity)
        {
            Duration--;
        }

        public void Apply(Character attachedEntity)
        {
            attachedEntity.Defense += strength;
            attachedEntity.AddResistance(Element.Fire);
            attachedEntity.AddResistance(Element.Ice);
            attachedEntity.AddResistance(Element.Lightning);
            attachedEntity.AddResistance(Element.Poison);
        }

        public void Remove(Character attachedEntity)
        {
            attachedEntity.Defense -= strength;
            attachedEntity.RemoveResistance(Element.Fire);
            attachedEntity.RemoveResistance(Element.Ice);
            attachedEntity.RemoveResistance(Element.Lightning);
            attachedEntity.RemoveResistance(Element.Poison);
        }

        public override void UpdateDescription()
        {
            this.Description = "Grants " + this.strength + " defense \nand Resistance to all \nElements";
        }
    }
}
