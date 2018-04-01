﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Player : Entity
    {
        public IWeapon FirstWeapon { get; private set; }
        public IWeapon SecondWeapon { get; private set; }
        public Inventory Inventory { get; private set; }

        public Player()
        {
            FirstWeapon = new BasicSword();
            SecondWeapon = new BasicFocus();
            Inventory = new Inventory();
            //Temp test
            Inventory.AddWeapon(new BasicSword());
            Inventory.AddWeapon(new BasicFocus());

            Health = 100;
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
    }
}