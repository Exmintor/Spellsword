using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class SpellMenu : Menu
    {
        private Player player;
        private TextMenu textMenu;
        public SpellMenu(SpellswordGame game, Player player) : base(game)
        {
            this.color = new Color(Color.Black, 0.85f);
            CurrentSprite = game.Content.Load<Texture2D>("Menu");
            this.AnchorTopLeft(game);

            this.player = player;

            textMenu = new TextMenu(game, "");

            this.currentCommands = GenerateCommands();
        }

        public override void Update()
        {
            base.Update();
            currentCommands = UpdateCommands();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            textMenu.SwitchOutString(currentCommands[controller.CurrentIndex].Description);
            textMenu.Draw(spriteBatch);
        }

        private List<ISpellswordCommand> GenerateCommands()
        {
            List<ISpellswordCommand> spellList = new List<ISpellswordCommand>();
            foreach(Attack attack in player.SpellList)
            {
                attack.UpdateDescription();
                EmptyCommand command = new EmptyCommand(attack.Name, attack.Description);
                spellList.Add(command);
            }
            return spellList;
        }

        private List<ISpellswordCommand> UpdateCommands()
        {
            ISpellswordCommand backCommand = currentCommands.Last();
            List<ISpellswordCommand> spellList = new List<ISpellswordCommand>();
            foreach (Attack attack in player.SpellList)
            {
                attack.UpdateDescription();
                EmptyCommand command = new EmptyCommand(attack.Name, attack.Description);
                spellList.Add(command);
            }
            spellList.Add(backCommand);
            return spellList;
            //for (int i = 0; i < currentCommands.Count - 1; i++)
            //{
            //    player.SpellList[i].UpdateDescription();
            //    currentCommands[i] = new EmptyCommand(player.SpellList[i].Name, player.SpellList[i].Description);
            //}
        }
    }
}
