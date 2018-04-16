using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    interface ISpellswordCommand
    {
        string Name { get; }
        void Execute();
    }
}
