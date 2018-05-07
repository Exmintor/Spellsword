using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Dragon : Enemy
    {
        private string firstImage;
        private string secondImage;
        private int turnCounter;
        private IAction secondAction;

        public Dragon(string worldImage, string battleImage, string superImage) : base(worldImage, battleImage)
        {
            MaxHealth = 50;
            Health = 50;
            Strength = 1;
            Magic = 1;
            Defense = 1;

            Reward = new Reward(1);

            firstImage = battleImage;
            secondImage = superImage;
            turnCounter = 0;

            IWeapon weapon = new BasicSword("BasicSword", 10, 5);
            basicAction = new BasicSwordAttack(this, weapon);
            secondAction = new BasicFireball(this, 20);
        }

        public override IAction ChooseAction()
        {
            turnCounter++;
            if(turnCounter % 3 == 0)
            {
                this.BattleImage = secondImage;
                return secondAction;
            }
            else
            {
                this.BattleImage = firstImage;
                return base.ChooseAction();
            }
        }
    }
}
