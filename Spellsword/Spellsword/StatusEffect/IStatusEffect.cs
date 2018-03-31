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

        void Resolve(Entity attachedEntity);
        void UnResolve(Entity attachedEntity);
    }
}
