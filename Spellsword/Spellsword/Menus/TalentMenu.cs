using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class TalentMenu : Menu
    {
        private Player player;
        private TextMenu textMenu;

        public TalentMenu(SpellswordGame game, Player player) : base(game)
        {
            this.color = new Color(Color.Black, 0.85f);
            CurrentSprite = game.Content.Load<Texture2D>("Menu");
            this.AnchorTopLeft(game);

            textMenu = new TextMenu(game, "");

            this.player = player;
            this.currentCommands = GenerateCommands();
        }

        public override void Update()
        {
            controller.Update(this);
            if(GetTalentAtIndex(controller.CurrentIndex) != null)
            {
                UpdateTalentText();
            }
            else
            {
                textMenu.SwitchOutString(currentCommands[controller.CurrentIndex].Description);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            textMenu.Draw(spriteBatch);
        }

        private void UpdateTalentText()
        {
            textMenu.SwitchOutString("Talent points: " + player.TalentPoints);
            textMenu.AddString(currentCommands[controller.CurrentIndex].Description);
            textMenu.AddString("");
            Talent currentTalent = GetTalentAtIndex(controller.CurrentIndex);
            if (currentTalent != null)
            {
                textMenu.AddString("Cost: " + currentTalent.Cost);
            }
        }

        private List<ISpellswordCommand> GenerateCommands()
        {
            List<ISpellswordCommand> commands = new List<ISpellswordCommand>();
            foreach(Talent talent in player.AvailableTalents)
            {
                AddTalentCommand newCommand = new AddTalentCommand(player, talent);
                commands.Add(newCommand);
            }
            return commands;
        }

        private Talent GetTalentAtIndex(int index)
        {
            if(index < player.AvailableTalents.Count)
            {
                return player.AvailableTalents[index];
            }
            return null;
        }
    }
}
