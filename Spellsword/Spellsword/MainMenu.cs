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
        public MainMenu(Game game, MenuScene scene) : this(game, scene, new List<ISpellswordCommand>())
        {

        }
        public MainMenu(Game game, MenuScene scene, List<ISpellswordCommand> commands) : base(game, scene, commands)
        {
            thisGame = game;
            thisScene = scene;
        }
    }
}
