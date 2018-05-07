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
            MaxHealth = 300;
            Health = 300;
            Strength = 5;
            Magic = 5;
            Defense = 5;

            this.AddWeakness(Element.Lightning);
            this.AddResistance(Element.Fire);

            basicAction = new BasicEnemyAttack(this, Element.None, 40);
            secondAction = new BasicFireball(this, 80);

            Reward = new Reward(1);

            firstImage = battleImage;
            secondImage = superImage;
            turnCounter = 0;
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
