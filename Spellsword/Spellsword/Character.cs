using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class Character : Entity
    {
        public event Action<Entity> Died;

        public int Health { get; protected set; }
        public int Strength { get; protected set; }
        public int Magic { get; protected set; }
        public int Defense { get; set; } // Abstract property, add setter

        public List<Attack> SpellList { get; private set; }

        public List<IStatusEffect> StatusEffects { get; private set; }
        private List<IStatusEffect> effectsToRemove;

        public Character()
        {
            SpellList = new List<Attack>();
            StatusEffects = new List<IStatusEffect>();
            effectsToRemove = new List<IStatusEffect>();
        }

        public virtual void TakeDamage(int damage)
        {
            this.Health -= damage - Defense;
            if (this.Health <= 0)
            {
                if (Died != null)
                {
                    Died.Invoke(this);
                }
            }
        }

        public virtual void IncreaseStrength(int amount)
        {
            Strength += amount;
        }
        public virtual void IncreaseMagic(int amount)
        {
            Magic += amount;
        }

        public virtual void AddStatusEffect(IStatusEffect effect)
        {
            StatusEffects.Add(effect);
            effect.Apply(this);
        }
        public virtual void RemoveStatusEffect(IStatusEffect effect)
        {
            effectsToRemove.Add(effect);
            effect.Remove(this);
        }
        public virtual void RemoveAllStatusEffects()
        {
            foreach (IStatusEffect effect in StatusEffects)
            {
                RemoveStatusEffect(effect);
            }
            PermanentlyRemoveStatusEffects();
        }
        public virtual void ResolveStatusEffectsBefore()
        {
            StatusEffects = StatusEffects.OrderByDescending(e => e.Priority).ToList();
            foreach (IStatusEffect effect in StatusEffects)
            {
                effect.BeforeTick(this);
            }
            PermanentlyRemoveStatusEffects();
        }
        public virtual void ResolveStatusEffectsAfter()
        {
            StatusEffects = StatusEffects.OrderByDescending(e => e.Priority).ToList();
            foreach (IStatusEffect effect in StatusEffects)
            {
                effect.AfterTick(this);
            }
            PermanentlyRemoveStatusEffects();
        }

        private void PermanentlyRemoveStatusEffects()
        {
            effectsToRemove = effectsToRemove.OrderByDescending(e => e.Priority).ToList();
            foreach (IStatusEffect effect in effectsToRemove)
            {
                StatusEffects.Remove(effect);
            }
            effectsToRemove.Clear();
        }

        public abstract IAction ChooseAction();
    }
}
