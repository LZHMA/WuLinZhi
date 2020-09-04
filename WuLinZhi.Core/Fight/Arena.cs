using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Fight
{
    public class Arena
    {
        private readonly NPC _npc;
        private readonly MainCharacter _mainCharacter;

        private int _mainCharacterHPCurrent;
        private int _mainCharacterMPCurrent;

        public Arena(MainCharacter mainCharacter, NPC npc)
        {
            this._npc = npc;
            this._mainCharacter = mainCharacter;

            MainCharacterHPUpperLimit = _mainCharacter.HP;
            MainCharacterHPCurrent = MainCharacterHPUpperLimit;

            MainCharacterMPUpperLimit = _mainCharacter.MP;
            MainCharacterMPCurrent = MainCharacterMPUpperLimit;
        }

        public int MainCharacterHPUpperLimit { get; set; }
        public int MainCharacterHPCurrent
        {
            get => _mainCharacterHPCurrent;
            set
            {
                _mainCharacterHPCurrent = value < MainCharacterHPUpperLimit ? value : MainCharacterHPUpperLimit;
            }
        }

        public int MainCharacterMPUpperLimit { get; set; }
        public int MainCharacterMPCurrent
        {
            get => _mainCharacterMPCurrent;
            set
            {
                _mainCharacterMPCurrent = value < MainCharacterMPUpperLimit ? value : MainCharacterMPUpperLimit;
            }
        }

        public bool GoThroughFightProgress()
        {
            return true;
        }

        void CastSkill(IFightable from, IFightable to)
        {

        }
    }
}
