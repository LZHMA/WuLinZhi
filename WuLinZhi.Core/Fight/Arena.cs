using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Fight
{
    public class Arena
    {
        private readonly int _npcAttackChance = 70;
        private readonly Random _arenaRandom=new Random();
        public Arena(IFightable mainCharacter, IFightable npc)
        {
            MainCharacterInFight = new CharacterInFight(mainCharacter);
            NPCInFight = new CharacterInFight(npc);

            FightStart();
            PlayerRoundStart();
        }

        public CharacterInFight MainCharacterInFight { get; }
        public CharacterInFight NPCInFight { get; }

        public bool PlayerPreparation { get; set; }

        /// <summary>
        /// The whole progress of the fight
        /// </summary>
        /// <returns>Whethear MainCharacter won or not</returns>
        public void FightStart()
        {
            //Fight start
            MainCharacterInFight.UseFightStartEffects();
            NPCInFight.UseFightStartEffects();
        }

        public void PlayerRoundStart()
        {
            int shieldToNextRound = (int)(MainCharacterInFight.Shield * (MainCharacterInFight.ShieldRemainRate) / 100.0);
            MainCharacterInFight.Shield = shieldToNextRound;
            MainCharacterInFight.UseRoundStartEffects();
            MainCharacterInFight.ActionPointCurrent = MainCharacterInFight.ActionPointCap;
            PlayerPreparation = true;
        }
        public void PlayerRoundAct()
        {
            PlayerPreparation = false;
            MainCharacterInFight.CastInstructedSupportSkills();
            MainCharacterInFight.CastInstructedAttackSkills(NPCInFight);
            MainCharacterInFight.UseRoundEndEffects();
            NPCRound();

        }
        public void NPCRound()
        {
            int shieldToNextRound = (int)(NPCInFight.Shield * (NPCInFight.ShieldRemainRate) / 100.0);
            NPCInFight.Shield = shieldToNextRound;
            NPCInFight.UseRoundStartEffects();
            if(_arenaRandom.Next(100)< _npcAttackChance)
            {
                var skillIndex = _arenaRandom.Next(NPCInFight.AttackSkills.Count);
                var skill = NPCInFight.AttackSkills[skillIndex];
                NPCInFight.CastAttackSkill(skill, MainCharacterInFight);
            }
            else
            {
                var skillIndex = _arenaRandom.Next(NPCInFight.SupportSkills.Count);
                var skill = NPCInFight.SupportSkills[skillIndex];
                NPCInFight.CastSupportSkill(skill);
            }
            NPCInFight.UseRoundEndEffects();
            PlayerRoundStart();
        }

        public void EndFight(bool playerWin)
        {

        }
    }
}
