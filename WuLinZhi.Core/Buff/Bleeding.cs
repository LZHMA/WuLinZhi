using System;
using System.Collections.Generic;
using System.Text;

namespace WuLinZhi.Core.Buff
{
    class Bleeding:DeBuff
    {
        public float StrengthToDamageFactor { get; set; } = 0.05f;
        public float DamageAmplification { get; set; } = 0.02f;
    }
}
