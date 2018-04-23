using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class SwitchWeaponMenu : Menu
    {
        private Player player;
        private int weaponIndex;

        private TextMenu textMenu;

        public SwitchWeaponMenu(SpellswordGame game, Player player, int weaponIndex) : base(game)
        {
            this.color = new Color(Color.Black, 0.85f);
            CurrentSprite = game.Content.Load<Texture2D>("Menu");
            this.AnchorTopLeft(game);

            this.player = player;
            this.weaponIndex = weaponIndex;

            textMenu = new TextMenu(game, "");
            currentCommands = GenerateCommands();
        }

        public override void Update()
        {
            base.Update();
            UpdateCommands();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.DrawWithOffset(spriteBatch, new Vector2(20, 35));
            spriteBatch.DrawString(font, "Inventory: ", this.Location, Color.White);
            textMenu.SwitchOutString(currentCommands[controller.CurrentIndex].Description);
            textMenu.Draw(spriteBatch);
        }

        public void SwitchWeapon(IWeapon weaponToSwitch)
        {
            player.ChangeEquipment(weaponIndex, weaponToSwitch);
        }

        private List<ISpellswordCommand> GenerateCommands()
        {
            List<ISpellswordCommand> commands = new List<ISpellswordCommand>();
            foreach(IWeapon weapon in player.Inventory.Weapons)
            {
                SwitchOutWeaponCommand command = new SwitchOutWeaponCommand(this, weapon);
                commands.Add(command);
            }
            return commands;
        }

        private void UpdateCommands()
        {
            for(int i = 0; i < currentCommands.Count - 1; i++)
            {
                currentCommands[i] = new SwitchOutWeaponCommand(this, player.Inventory.Weapons[i]);
            }
        }
    }
}
