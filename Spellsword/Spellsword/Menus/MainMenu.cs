using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class MainMenu : Menu
    {
        public MainMenu(SpellswordGame game, MenuScene scene) : this(game, new List<ISpellswordCommand>())
        {

        }
        public MainMenu(SpellswordGame game, List<ISpellswordCommand> commands) : base(game, commands)
        {
            thisGame = game;
        }
    }
}
