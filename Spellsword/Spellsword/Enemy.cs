using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Enemy : Entity
    {
        public Enemy()
        {

        }

        public override IAction ChooseAction()
        {
            throw new NotImplementedException();
        }

        public override void TakeDamage(int damage)
        {
            //TODO: Override with damage calculation
            base.TakeDamage(damage);
        }
    }
}
