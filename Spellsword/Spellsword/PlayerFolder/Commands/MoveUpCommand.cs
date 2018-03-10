using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword.PlayerFolder.Commands
{
    public class MoveUpCommand : Command
    {
        private WalkingPlayer player;

        public MoveUpCommand(WalkingPlayer player)
        {
            this.player = player;
        }

        public override void Execute()
        {
            player.MoveUp();
        }
    }
}
