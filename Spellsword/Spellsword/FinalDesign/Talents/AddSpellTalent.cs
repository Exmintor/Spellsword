using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class AddSpellTalent : Talent
    {
        public override string Name { get; protected set; }
        public override string Description { get; protected set; }
        public override int Cost { get; protected set; }

        private string thisSpell;

        public AddSpellTalent(string spell, int cost)
        {
            thisSpell = spell;

            this.Name = "Learn " + spell;
            this.Description = "Learn the " + spell + " \nspell";
            Cost = cost;
        }

        public override void ApplyTalent(Character player)
        {
            base.ApplyTalent(player);
            Attack newSpell;
            switch(thisSpell)
            {
                case "Ice Lance":
                    newSpell = new BasicIceSpell(player, 25);
                    break;
                case "Lightning":
                    newSpell = new BasicLightningSpell(player, 35);
                    break;
                case "Magic Shield":
                    newSpell = new MagicShield(player, 1, 15);
                    break;
                default:
                    newSpell = new BasicFireball(player, 15);
                    break;
            }
            ((Player)player).GiveNewSpell(newSpell);
            ((Player)player).RemoveAvailableTalent(this);
        }
    }
}
