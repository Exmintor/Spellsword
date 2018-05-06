using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class EquipmentMenu : Menu
    {
        public int NumberOfWeapons
        {
            get
            {
                return player.Inventory.Weapons.Count;
            }
        }
        private SpellswordGame game;
        private Player player;

        private TextMenu textMenu;

        public EquipmentMenu(SpellswordGame game, Player player) : base(game)
        {
            this.color = new Color(Color.Black, 0.85f);
            CurrentSprite = game.Content.Load<Texture2D>("Menu");
            this.AnchorTopLeft(game);

            this.game = game;
            this.player = player;

            textMenu = new TextMenu(game, "");
            currentCommands = GenerateCommands();
        }

        public override void Update()
        {
            controller.Update(this);
            UpdateCommands();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.DrawWithOffset(spriteBatch, new Vector2(20, 35));
            spriteBatch.DrawString(font, "Current Weapons: ", this.Location, Color.White);
            textMenu.SwitchOutString(currentCommands[controller.CurrentIndex].Description);
            textMenu.Draw(spriteBatch);
        }

        private List<ISpellswordCommand> GenerateCommands()
        {
            List<ISpellswordCommand> commands = new List<ISpellswordCommand>();
            SwitchWeaponCommand command = new SwitchWeaponCommand(game, this, player, player.FirstWeapon, 1);
            SwitchWeaponCommand secondCommand = new SwitchWeaponCommand(game, this, player, player.SecondWeapon, 2);
            commands.Add(command);
            commands.Add(secondCommand);
            return commands;
        }

        private void UpdateCommands()
        {
            currentCommands[0] = new SwitchWeaponCommand(game, this, player, player.FirstWeapon, 1);
            currentCommands[1] = new SwitchWeaponCommand(game, this, player, player.SecondWeapon, 2);
        }
    }
}
