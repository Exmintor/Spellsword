﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public interface IInteractable
    {
        void Interact(Character agentInteracting);
    }
}
