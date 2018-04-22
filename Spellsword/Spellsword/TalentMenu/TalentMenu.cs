﻿using Microsoft.Xna.Framework;
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
        private List<Talent> availableTalents;
        private TextMenu textMenu;

        public TalentMenu(SpellswordGame game, Player player) : base(game)
        {
            this.color = new Color(Color.Black, 0.85f);
            CurrentSprite = game.Content.Load<Texture2D>("Menu");
            this.AnchorTopLeft(game);

            textMenu = new TextMenu(game, "");

            this.player = player;
            availableTalents = new List<Talent>();
            availableTalents.Add(new StrengthTalent());
            availableTalents.Add(new MagicTalent());
            this.currentCommands = GenerateCommands();
        }

        public override void Update()
        {
            controller.Update(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            textMenu.SwitchOutString(currentCommands[controller.CurrentIndex].Description);
            textMenu.Draw(spriteBatch);
        }

        private List<ISpellswordCommand> GenerateCommands()
        {
            List<ISpellswordCommand> commands = new List<ISpellswordCommand>();
            foreach(Talent talent in availableTalents)
            {
                AddTalentCommand newCommand = new AddTalentCommand(player, talent);
                commands.Add(newCommand);
            }
            return commands;
        }
    }
}
