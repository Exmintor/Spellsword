using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Defend : IAction, IStatusEffect
    {
        public Entity User { get; protected set; }

        public string Name { get; protected set; }
        public int Duration { get; protected set; }
        public int Priority { get; protected set; }

        private IWeapon thisWeapon;

        public Defend(Entity user, int duration, IWeapon weapon)
        {
            this.User = user;
            this.Name = "Defend";
            this.Duration = duration;
            this.Priority = 0;
            this.thisWeapon = weapon; ;
        }

        public void Tick(Entity attachedEntity)
        {
            Duration--;
        }
        public void Apply(Entity attachedEntity)
        {
            attachedEntity.Defense += thisWeapon.Defense;
        }
        public void Remove(Entity attachedEntity)
        {
            attachedEntity.Defense -= thisWeapon.Defense;
        }
    }
}
