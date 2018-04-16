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

        private BattleController controller;
        private Character player;
        private IWeapon currentWeapon;

        private List<ISpellswordCommand> currentCommands;
        private int currentTopCommand;

        public BattleMenu(Game game, Character player, IWeapon weapon) : base(game)
        {
            controller = new BattleController(game);
            currentCommands = new List<ISpellswordCommand>();

            currentTopCommand = 0;

            CurrentSprite = game.Content.Load<Texture2D>("BattleMenu");
            AnchorBottomLeft(game);

            this.player = player;
            this.currentWeapon = weapon;
            LoadBasicCommands();
        }

        public void Update()
        {
            controller.Update(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            DrawActions(spriteBatch);
        }

        private void DrawActions(SpriteBatch spriteBatch)
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

        private void DrawCommand(string commandName, Vector2 commandLocation, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, commandName, commandLocation, Color.White);
        }

        private void LoadBasicCommands()
        {
            currentCommands.Clear();
            currentCommands.Add(new AttackCommand(this));
            currentCommands.Add(new DefendCommand(this));
            if(currentWeapon.IsFocus)
            {
                currentCommands.Add(new SpellSelectionCommand(this));
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

        public void SpellSelection()
        {
            controller.ResetIndex();
            List<ISpellswordCommand> newCommands = new List<ISpellswordCommand>();
            List<Attack> spellList = player.SpellList;

            newCommands.Add(new BackCommand(this));
            foreach (Attack spell in spellList)
            {
                newCommands.Add(new NewSpellCommand(this, spell));
            }

            currentCommands = newCommands;
        }

        public void SpellAction(Attack spell)
        {
            if(ActionChosen != null)
            {
                ActionChosen.Invoke(spell);
            }
        }

        public void BackAction()
        {
            LoadBasicCommands();
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
        public bool IsOnCommandList(int index)
        {
            if(index <= currentCommands.Count - 1 && index >= 0)
            {
                return true;
            }
            return false;
        }

        public void ExecuteCommand(int index)
        {
            if(IsOnCommandList(index))
            {
                currentCommands[index].Execute();
            }
        }
    }
}
