using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public interface IStatusEffect
    {
        int Duration { get; }
        int Priority { get; }
        string Name { get; }

        void Tick(Character attachedEntity);
        void Apply(Character attachedEntity);
        void Remove(Character attachedEntity);
    }
}
