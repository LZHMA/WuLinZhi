using System;
using System.Collections.Generic;
using System.Text;

namespace WuLinZhi.Core.Effects
{
    public abstract class Effect
    {
        public string Name { get; set; }
        public int Chance { get; set; }

        public bool Trigger()
        {
            var random = new Random().Next(100);
            return random < Chance;
        }

        public abstract void TakeEffect();
    }
}
