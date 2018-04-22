using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class AddTalentCommand : ISpellswordCommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private Player player;
        private Talent talent;

        public AddTalentCommand(Player player, Talent talent)
        {
            this.player = player;
            this.talent = talent;

            this.Name = talent.Name;
            this.Description = talent.Description;
        }

        public void Execute()
        {
            if(player.TalentPoints >= talent.Cost)
            {
                talent.ApplyTalent(player);
                player.AddTalent(talent);
                player.TalentPoints -= talent.Cost;
            }
        }
    }
}
