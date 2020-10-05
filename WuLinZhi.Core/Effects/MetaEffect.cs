using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Effects
{
    public static class MetaEffect
    {
        public static void TakeDamage(CharacterInFight target,int damage)
        {
            if(target.Shield>=damage)
            {
                target.Shield -= damage;
            }
            else
            {
                var remainingDamage = damage - target.Shield;
                target.HPCurrent -= remainingDamage;
            }
        }
        public static void TakeHPRecover(CharacterInFight source, int recover)
        {
            int actualRecover= (int)(recover * (1 + source.RecoverHPIncrease / 100.0));
            source.HPCurrent += actualRecover;
        }
        public static void TakeMPRecover(CharacterInFight source, int recover)
        {
            source.MPCurrent += recover;
        }
        public static void GainShield(CharacterInFight source,int percentage)
        {
            source.Shield += source.Vitality * percentage / 100;
        }

        public static void Attack(CharacterInFight source,int attackRatio, CharacterInFight target)
        {
            double damageTakeRatio = 1 / (1 + target.Vitality / 3000.0);
            int damage = (int)(source.Strength * attackRatio/100 * (1+source.DamageExertIncrease/100.0) * damageTakeRatio * (1+(target.DamageTakenIncrease - target.DamageTakenDecrease)/100.0));
            TakeDamage(target, damage);
        }
    }
}
