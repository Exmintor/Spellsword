﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class StatusMenu : TextMenu
    {
        private Player player;

        public StatusMenu(SpellswordGame game, Player player) : base(game, "")
        {
            this.CurrentSprite = game.Content.Load<Texture2D>("Menu");
            this.AnchorTopLeft(game);
            this.player = player;

            this.SwitchOutString(GetPlayerStatus());
        }

        public override void Update()
        {
            this.SwitchOutString(GetPlayerStatus());
            base.Update();
        }

        private List<string> GetPlayerStatus()
        {
            string healthString = "Health: " + player.Health;
            string attackString = "Strength: " + player.Strength;
            string magicString = "Magic: " + player.Magic;
            string isFocus = "";
            if(player.FirstWeapon.IsFocus)
            {
                isFocus = "Can cast spells.";
            }
            else
            {
                isFocus = "";
            }
            string weaponString = "Current Right-Hand Weapon: \n" + player.FirstWeapon.Name + 
                "\n    Attack: " + player.FirstWeapon.Damage + " + " + player.Strength + 
                "\n    Defense: " + player.FirstWeapon.Defense + " + " + player.Defense + 
                "\n    " + isFocus;
            if (player.SecondWeapon.IsFocus)
            {
                isFocus = "Can cast spells.";
            }
            else
            {
                isFocus = "";
            }
            string weaponString2 = "Current Left-Hand Weapon: \n" + player.SecondWeapon.Name +
                "\n    Attack: " + player.SecondWeapon.Damage + " + " + player.Strength +
                "\n    Defense: " + player.SecondWeapon.Defense + " + " + player.Defense +
                "\n    " + isFocus;

            List<string> allStrings = new List<string>();
            allStrings.Add(healthString);
            allStrings.Add(attackString);
            allStrings.Add(magicString);
            allStrings.Add(weaponString);
            allStrings.Add("");
            allStrings.Add("");
            allStrings.Add(weaponString2);
            allStrings.Add("");
            allStrings.Add("");
            allStrings.Add("");
            return allStrings;
        }
    }
}
