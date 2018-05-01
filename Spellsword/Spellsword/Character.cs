using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public enum Element { None, Fire, Ice, Lightning, Poison }
    public abstract class Character : Entity
    {
        public event Action<Entity> Died;

        public string WorldImage { get; protected set; }
        public string BattleImage { get; protected set; }

        public int MaxHealth { get; protected set; }
        public int Health { get; protected set; }
        public bool IsAlive
        {
            get
            {
                if(Health > 0)
                {
                    return true;
                }
                return false;
            }
        }
        public int Strength { get; protected set; }
        public int Magic { get; protected set; }
        public int Defense { get; set; } // Abstract property, add setter

        public List<Element> Weakness { get; protected set; }
        public List<Element> Resistance { get; protected set; }

        public List<Attack> SpellList { get; private set; }

        public List<IStatusEffect> StatusEffects { get; private set; }
        private List<IStatusEffect> effectsToRemove;

        public Character(string WorldImage, string BattleImage)
        {
            this.WorldImage = WorldImage;
            this.BattleImage = BattleImage;

            SpellList = new List<Attack>();
            StatusEffects = new List<IStatusEffect>();
            effectsToRemove = new List<IStatusEffect>();
            Weakness = new List<Element>();
            Resistance = new List<Element>();
        }

        public virtual void TakeDamage(int damage, Element element)
        {
            bool resisted = false;
            foreach(Element instance in Resistance)
            {
                if(element == instance)
                {
                    damage /= 2;
                    resisted = true;
                    break;
                }
            }
            if(resisted == false)
            {
                foreach(Element instance in Weakness)
                {
                    if(element == instance)
                    {
                        damage *= 2;
                        break;
                    }
                }
            }

            if(element == Element.Poison)
            {
                this.Health -= damage;
            }
            else if(damage - Defense > 0)
            {
                this.Health -= damage - Defense;
            }
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
        public virtual void IncreaseHealth(int amount)
        {
            MaxHealth += amount;
            Health += amount;
        }
        public virtual void IncreaseDefense(int amount)
        {
            Defense += amount;
        }

        public virtual void HealToMax()
        {
            Health = MaxHealth;
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
