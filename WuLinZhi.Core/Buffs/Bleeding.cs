using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Buffs
{
    public class Bleeding : IBuff
    {
        private int _layer;
        public string Name { get; } = "流血";
        public string Description { get; }

        public int MaxLayer { get; } = int.MaxValue;
        public int Layer
        {
            get => _layer;
            private set
            {
                if(value>MaxLayer)
                {
                    _layer = MaxLayer;
                }
            }
        }
        public bool DeBuff { get; } = true;

        public bool Removable { get; }

        public int StrengthToDamageFactor { get; set; } = 5;
        public int DamageAmplification { get; set; } = 1;

        public void ChangeState(CharacterInFight target, int layer)
        {
            this.Layer += layer;
            target.DamageTakenIncrease += layer * DamageAmplification;
        }
    }
}
