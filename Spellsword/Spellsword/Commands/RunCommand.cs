using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class RunCommand : ISpellswordCommand
    {
        public string Name { get; protected set; }

        public string Description { get; protected set; }

        private SpellswordGame game;
        private Character player;
        private Character enemy;

        public RunCommand(SpellswordGame game, Character player, Character enemy)
        {
            this.game = game;
            this.player = player;
            this.enemy = enemy;

            Name = "Run";
            Description = "Run Away";
        }

        public void Execute()
        {
            if (player.IsAlive)
            {
                player.HealToMax();
                player.RemoveAllStatusEffects();
            }
            if(enemy.IsAlive)
            {
                if(enemy is Dragon)
                {
                    ((Dragon)enemy).ResetTurnCounter();
                }
                enemy.HealToMax();
                enemy.RemoveAllStatusEffects();
            }
            game.SwitchToWorld();
        }
    }
}
