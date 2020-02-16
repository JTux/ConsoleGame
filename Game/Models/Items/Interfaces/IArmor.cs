﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Items.Interfaces
{
    public interface IArmor
    {
        bool IsEquipped { get; }
        int BonusHealth { get; }
    }
}
