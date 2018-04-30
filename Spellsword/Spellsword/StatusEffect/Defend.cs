using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Defend : ISelfTargetAction, IStatusEffect
    {
        public Character User { get; protected set; }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Duration { get; protected set; }
        public int Priority { get; protected set; }
        public Element AttackElement { get; protected set; }

        private IWeapon thisWeapon;

        public Defend(Character user, int duration, IWeapon weapon)
        {
            this.User = user;
            this.Name = "Defend";
            this.Description = "Grants " + weapon.Defense + " for one turn.";
            this.Duration = duration;
            this.Priority = 0;
            this.thisWeapon = weapon; ;
            this.AttackElement = Element.None;
        }

        public void BeforeTick(Character attachedEntity)
        {
            if(Duration <= 0)
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
            attachedEntity.Defense += thisWeapon.Defense;
        }
        public void Remove(Character attachedEntity)
        {
            attachedEntity.Defense -= thisWeapon.Defense;
        }
    }
}
