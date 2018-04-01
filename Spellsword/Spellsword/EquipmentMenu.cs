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
        private MenuController controller;
        private Player player;

        public EquipmentMenu(Game game, Player player) : base(game)
        {
            this.color = new Color(Color.Black, 0.85f);
            controller = new MenuController(game);
            CurrentSprite = game.Content.Load<Texture2D>("EquipmentMenu");
            this.AnchorTopRight(game);

            this.player = player;
        }

        public void Update()
        {
            controller.Update(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            DrawCurrentWeapons(spriteBatch);
            DrawInventory(spriteBatch);
        }

        public void ChangeEquipment(int whichHand, int whichWeapon)
        {
            IWeapon weapon = player.Inventory.GetWeapon(whichWeapon);
            player.ChangeEquipment(whichHand, weapon);
        }

        private void DrawCurrentWeapons(SpriteBatch spriteBatch)
        {
            Vector2 newLocation = this.Location + new Vector2(10, 10);
            spriteBatch.DrawString(font, "1. First: " + player.FirstWeapon.Name, newLocation, Color.White);
            Vector2 secondLocation = newLocation + new Vector2(0, 20);
            spriteBatch.DrawString(font, "2. Second: " + player.SecondWeapon.Name, secondLocation, Color.White);
        }

        private void DrawInventory(SpriteBatch spriteBatch)
        {
            int i = 3;
            Vector2 newLocation = this.Location + new Vector2(10, 60);
            foreach(IWeapon weapon in player.Inventory.Weapons)
            {
                spriteBatch.DrawString(font, i + ". " + weapon.Name, newLocation, Color.White);
                i++;
                newLocation += new Vector2(0, 20);
            }
        }
    }
}
