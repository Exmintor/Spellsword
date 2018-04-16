﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class DefendCommand : ISpellswordCommand
    {
        public string Name { get; private set; }

        private BattleMenu menu;

        public DefendCommand(BattleMenu menu)
        {
            this.Name = "Defend";
            this.menu = menu;
        }
        public void Execute()
        {
            menu.DefendAction();
        }
    }
}
