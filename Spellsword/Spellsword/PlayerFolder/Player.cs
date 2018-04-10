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
        public List<Talent> CurrentTalents { get; private set; }

        public Player()
        {
            FirstWeapon = new BasicSword();
            SecondWeapon = new BasicFocus();
            Inventory = new Inventory();
            CurrentTalents = new List<Talent>();
            //Temp test
            Inventory.AddWeapon(new BasicSword());
            Inventory.AddWeapon(new BasicFocus());

            Health = 100;
            Strength = 1;
            Magic = 1;
            Defense = 1;
            TalentPoints = 3;
        }

        public override IAction ChooseAction()
        {
            throw new NotImplementedException();
        }

        public override void TakeDamage(int damage)
        {
            //TODO: Override with damage calculation
            base.TakeDamage(damage);
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
        public void AddTalent(Talent talent)
        {
            CurrentTalents.Add(talent);
        }

        public void GainTalentPoints(int amount)
        {
            TalentPoints += amount;
        }
    }
}
