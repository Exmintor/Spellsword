﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public interface IAction
    {
        string Name { get; }
        string Description { get; }
        Character User { get; }

        Element AttackElement { get; }
    }
}
