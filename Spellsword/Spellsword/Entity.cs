using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class Entity
    {
        public event Action Died;

        public int Health { get; protected set; }
        public  List<IStatusEffect> StatusEffects { get; private set; }
        private List<IStatusEffect> effectsToRemove;

        public Entity()
        {
            StatusEffects = new List<IStatusEffect>();
            effectsToRemove = new List<IStatusEffect>();
        }
        public virtual void TakeDamage(int damage)
        {
            this.Health -= damage;
            if(this.Health <= 0)
            {
                if(Died != null)
                {
                    Died.Invoke();
                }
            }
        }
        public virtual void AddStatusEffect(IStatusEffect effect)
        {
            StatusEffects.Add(effect);
        }
        protected virtual void RemoveStatusEffect(IStatusEffect effect)
        {
            StatusEffects.Remove(effect);
        }
        public virtual void RemoveAllStatusEffects()
        {
            foreach(IStatusEffect effect in StatusEffects)
            {
                effectsToRemove.Add(effect);
            }
            UnResolveStatusEffects();
        }
        public virtual void ResolveStatusEffects()
        {
            StatusEffects = StatusEffects.OrderByDescending(e => e.Priority).ToList();
            foreach (IStatusEffect effect in StatusEffects)
            {
                effect.Resolve(this);
                if(effect.Duration <= 0)
                {
                    effectsToRemove.Add(effect);
                }
            }
        }
        public virtual void UnResolveStatusEffects()
        {
            effectsToRemove = effectsToRemove.OrderByDescending(e => e.Priority).ToList();
            foreach (IStatusEffect effect in effectsToRemove)
            {
                effect.UnResolve(this);
                RemoveStatusEffect(effect);
            }
            effectsToRemove.Clear();
        }

        public abstract IAction ChooseAction();
    }
}
