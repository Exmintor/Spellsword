using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword.PlayerFolder.Commands
{
    public class MoveUpCommand : ISpellswordCommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private WalkingPlayer player;

        public MoveUpCommand(WalkingPlayer player)
        {
            this.Name = "Move Up";
            this.Description = "Move the player up";
            this.player = player;
        }

        public void Execute()
        {
            player.MoveUp();
        }
    }
}
