using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Buffs
{
    public class Huihun:IBuff
    {
        private int _layer;
        public string Name { get; } = "回魂";
        public string Description
        {
            get => "Gain 10% HP after taking a fatal damage";
        }
        public int MaxLayer { get; } = int.MaxValue;
        public int Layer
        {
            get => _layer;
            private set
            {
                if(value>MaxLayer)
                { _layer = MaxLayer; }
            }
        }

        public bool DeBuff { get; } = false;
        public bool Removable { get; } = true;

        public void ChangeState(CharacterInFight target, int layer)
        {
            this.Layer += layer;
        }
    }
}
