using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class EmptyCommand : ISpellswordCommand
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public EmptyCommand(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public void Execute()
        {
            // Do nothing
        }
    }
}
