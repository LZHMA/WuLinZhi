using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Buffs
{
    public interface IBuff
    {
        string Name { get; }
        string Description { get; }

        int MaxLayer { get; }
        int Layer { get; }
        bool DeBuff { get; }
        bool Removable { get; }

        void ChangeState(CharacterInFight target,int layer);
    }
}
