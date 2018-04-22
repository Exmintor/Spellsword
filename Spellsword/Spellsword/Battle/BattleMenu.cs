using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BattleMenu : Menu
    {
        public event Action<IAction> ActionChosen;

        private Character player;
        private IWeapon currentWeapon;

        public BattleMenu(SpellswordGame game, Character player, IWeapon weapon) : this(game, player, weapon, new List<ISpellswordCommand>())
        {
            LoadBasicCommands();
        }

        public BattleMenu(SpellswordGame game, Character player, IWeapon weapon, List<ISpellswordCommand> commands) : base(game, commands)
        {
            controller = new BattleController(game);

            CurrentSprite = game.Content.Load<Texture2D>("BattleMenu");
            AnchorBottomLeft(game);

            this.player = player;
            this.currentWeapon = weapon;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        protected override void DrawCommands(SpriteBatch spriteBatch)
        {
            SwitchCommandsIfNeeded();
            Vector2 startingLocation = this.Location + new Vector2(10, 10);
            Vector2 currentLocation = startingLocation;
            for(int i = currentTopCommand; i < Math.Min(currentCommands.Count, currentTopCommand + 4); i++)
            {
                if (i != currentTopCommand && i % 2 == 0)
                {
                    currentLocation -= Parameters.battleCommandXOffset;
                    currentLocation += Parameters.battleCommandYOffset;
                }
                else if (i % 2 != 0)
                {
                    currentLocation += Parameters.battleCommandXOffset;
                }
                if(i == controller.CurrentIndex)
                {
                    spriteBatch.DrawString(font, "> ", currentLocation + Parameters.arrowOffset, Color.White);
                }
                DrawCommand(currentCommands[i].Name, currentLocation, spriteBatch);
            }
            spriteBatch.DrawString(font, "Attacking with " + currentWeapon.Name, startingLocation + new Vector2(10, -40), Color.White);
        }

        private void LoadBasicCommands()
        {
            currentCommands.Clear();
            currentCommands.Add(new AttackCommand(this));
            currentCommands.Add(new DefendCommand(this));
            if(currentWeapon.IsFocus)
            {
                BattleMenu spellMenu = GenerateSpellMenu();
                SwitchMenuCommand switchToSpells = new SwitchMenuCommand("Spells", thisGame, this, spellMenu);
                currentCommands.Add(switchToSpells);
            }

            controller.ResetIndex();
        }

        public void AttackAction()
        {
            IAction action = new BasicSwordAttack(player, currentWeapon);
            if(ActionChosen != null)
            {
                ActionChosen.Invoke(action);
            }
        }

        public void DefendAction()
        {
            IAction action = new Defend(player, 1, currentWeapon);
            if (ActionChosen != null)
            {
                ActionChosen.Invoke(action);
            }
        }

        public void SwordAction()
        {
            throw new NotImplementedException();
        }

        public void ShieldAction()
        {
            throw new NotImplementedException();
        }

        public void SpellAction(Attack spell)
        {
            if (ActionChosen != null)
            {
                ActionChosen.Invoke(spell);
            }
        }

        private BattleMenu GenerateSpellMenu()
        {
            List<ISpellswordCommand> newCommands = new List<ISpellswordCommand>();
            List<Attack> spellList = player.SpellList;
            foreach (Attack spell in spellList)
            {
                newCommands.Add(new NewSpellCommand(this, spell));
            }
            BattleMenu newMenu = new BattleMenu(thisGame, player, currentWeapon, newCommands);
            return newMenu;
        }

        private void SwitchCommandsIfNeeded()
        {
            if(controller.CurrentIndex >= currentTopCommand + 4)
            {
                currentTopCommand += 4;
            }
            else if(controller.CurrentIndex <= currentTopCommand - 1)
            {
                currentTopCommand -= 4;
            }
        }
    }
}
