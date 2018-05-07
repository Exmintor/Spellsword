using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class IceDefend : Defend
    {
        public IceDefend(Character user, int duration, IWeapon shield) : base(user, duration, shield)
        {
            this.AttackElement = Element.Ice;
            this.Name = "Ice Defend";
            this.Description = "Grants " + shield.Defense + " for one turn.\nAlso provides Fire and Lightning resistance.";
        }

        public override void Apply(Character attachedEntity)
        {
            base.Apply(attachedEntity);
            attachedEntity.AddResistance(Element.Fire);
            attachedEntity.AddResistance(Element.Lightning);
        }

        public override void Remove(Character attachedEntity)
        {
            base.Remove(attachedEntity);
            attachedEntity.RemoveResistance(Element.Fire);
            attachedEntity.RemoveResistance(Element.Lightning);
        }
    }
}
