using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class StatusMenu : TextMenu
    {
        public StatusMenu(SpellswordGame game, Player player) : base(game, "")
        {
            this.CurrentSprite = game.Content.Load<Texture2D>("Menu");
            this.AnchorTopLeft(game);

            this.SwitchOutString(GetPlayerStatus());
        }

        private List<string> GetPlayerStatus()
        {
            return null;
        }
    }
}
