using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Player : Character
    {
        public IWeapon FirstWeapon { get; private set; }
        public IWeapon SecondWeapon { get; private set; }
        public Inventory Inventory { get; private set; }

        public int TalentPoints { get; set; }
        public List<Talent> AvailableTalents { get; private set; }
        public List<Talent> CurrentTalents { get; private set; }

        public Player(string worldImage, string battleImage) : base(worldImage, battleImage)
        {
            FirstWeapon = new BasicSword("BasicSword", 10, 5);
            SecondWeapon = new BasicShield("BasicSword");
            Inventory = new Inventory();
            CurrentTalents = new List<Talent>();
            //Temp test
            Inventory.AddWeapon(new BasicFocus("BasicSword"));
            SpellList.Add(new BasicFireball(this, 15));
            //SpellList.Add(new MagicShield(this, 1, 15));

            AvailableTalents = new List<Talent>();
            AvailableTalents.Add(new StrengthTalent());
            AvailableTalents.Add(new MagicTalent());

            MaxHealth = 100;
            Health = 100;
            Strength = 1;
            Magic = 1;
            Defense = 1;
            TalentPoints = 1;
        }

        public override IAction ChooseAction()
        {
            throw new NotImplementedException();
        }

        public override void TakeDamage(int damage, Element element)
        {
            //TODO: Override with damage calculation
            base.TakeDamage(damage, element);
        }

        public virtual void ChangeEquipment(int whichHand, IWeapon weaponToEquip)
        {
            switch(whichHand)
            {
                case 1:
                    Inventory.AddWeapon(FirstWeapon);
                    Inventory.RemoveWeapon(weaponToEquip);
                    FirstWeapon = weaponToEquip;
                    break;
                case 2:
                    Inventory.AddWeapon(SecondWeapon);
                    Inventory.RemoveWeapon(weaponToEquip);
                    SecondWeapon = weaponToEquip;
                    break;
                default:
                    Inventory.AddWeapon(FirstWeapon);
                    Inventory.RemoveWeapon(weaponToEquip);
                    FirstWeapon = weaponToEquip;
                    break;
            }
        }

        public void GiveNewWeapon(IWeapon weapon)
        {
            Inventory.AddWeapon(weapon);
        }
        public void GiveNewSpell(Attack spell)
        {
            SpellList.Add(spell);
        }
        public void AddTalent(Talent talent)
        {
            CurrentTalents.Add(talent);
        }
        public void RemoveAvailableTalent(Talent talent)
        {
            AvailableTalents.Remove(talent);
        }

        public void GainRewards(Reward reward)
        {
            TalentPoints += reward.TalentPoints;
            if (reward.GainedTalents != null)
            {
                foreach(Talent talent in reward.GainedTalents)
                {
                    AvailableTalents.Add(talent);
                }
            }
            if (reward.GainedWeapons != null)
            {
                foreach (Weapon weapon in reward.GainedWeapons)
                {
                    GiveNewWeapon(weapon);
                }
            }
        }
    }
}
