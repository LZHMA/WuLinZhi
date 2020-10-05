using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Buffs
{
    class Poisoned: IBuff
    {
        public string Name { get; } = "中毒";
        public string Description { get => $"每层降低生命恢复{HPRecoverReduction}%，每回合损失气血"; }
        public int MaxLayer { get; } = int.MaxValue;
        public int Layer { get; private set; }
        public bool DeBuff { get; } = true;
        public bool Removable { get; } = true;

        public int MPToDamageFactor { get; set; } = 1;
        public int HPRecoverReduction { get; set; } = 3;

        public void ChangeState(CharacterInFight target, int layer)
        {
            this.Layer += layer;
            target.RecoverHPIncrease -= layer * HPRecoverReduction;
        }
    }
}
