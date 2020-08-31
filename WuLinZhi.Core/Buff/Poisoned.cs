using System;
using System.Collections.Generic;
using System.Text;

namespace WuLinZhi.Core.Buff
{
    class Poisoned:BuffBase
    {
        public float MPToDamageFactor { get; set; } = 0.01f;
        public float HPRecoverReduction { get; set; } = 0.03f;
    }
}
