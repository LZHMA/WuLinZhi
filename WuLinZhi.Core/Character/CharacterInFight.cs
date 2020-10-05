using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WuLinZhi.Core.Skills;
using WuLinZhi.Core.Effects;
using WuLinZhi.Core.Forces;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using WuLinZhi.Core.Buffs;
using System.Threading;
using System.Threading.Tasks;

namespace WuLinZhi.Core.Character
{
    public class CharacterInFight:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _hpCap, _hpCurrent, _mpCap, _mpCurrent, _vitality, _strength, _agility,_shield, _actionPointCurrent;
        private const int _skillDelay = 500;

        public CharacterInFight(IFightable character)
        {
            Name = character.Name;
            HPCap = character.HP;
            HPCurrent = character.HP;
            MPCap = character.MP;
            MPCurrent = character.MP;
            Vitality = character.Vitality;
            Strength = character.Strength;
            Agility = character.Agility;
            ActionPointCap = (int)Math.Log2(MPCap / 1000.0)+3;
            AttackSkills = character.AttackSkills;
            SupportSkills = character.SupportSkills;
            EmplaceEffect(character);
            Buffs.Owner = this;
        }
        public string Name { get; set; }
        public int HPCap
        {
            get => _hpCap;
            set
            {
                _hpCap = value;
                OnPropertyChanged(nameof(HPCap));
            }
        }
        public int HPCurrent
        {
            get => _hpCurrent;
            set
            {
                if(value<=0&&this.Buffs.Exists(buff=>buff.Name.Equals("回魂")))//fatal with huihun buff
                {
                    _hpCurrent = _hpCap / 10;
                    var buff = Buffs.Single(b => b.Name.Equals("回魂"));
                    buff.ChangeState(this, -1);
                }
                else if(value<=0)//fatal without huihun buff
                {
                    _hpCurrent = 0;
                }
                else//normal logic
                {
                    _hpCurrent = value;
                }
                OnPropertyChanged(nameof(HPCurrent));
                if(_hpCurrent==0)
                {
                    throw new ArgumentOutOfRangeException(string.Empty,this.Name);
                }
            }
        }
        public int MPCap
        {
            get => _mpCap;
            set
            {
                _mpCap = value;
                OnPropertyChanged(nameof(MPCap));
            }
        }
        public int MPCurrent
        {
            get => _mpCurrent;
            set
            {
                _mpCurrent = value;
                OnPropertyChanged(nameof(MPCurrent));
            }
        }
        public int Vitality
        {
            get => _vitality;
            set
            {
                _vitality = value;
                OnPropertyChanged(nameof(Vitality));
            }
        }
        public int Strength
        {
            get => _strength;
            set
            {
                _strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }
        public int Agility
        {
            get => _agility;
            set
            {
                _agility = value;
                OnPropertyChanged(nameof(Agility));
            }
        }

        public int DamageExertIncrease { get; set; }
        public int DamageTakenDecrease { get; set; }
        public int DamageTakenIncrease { get; set; }
        public int RecoverHPIncrease { get; set; }

        public int ActionPointCap { get; set; }
        public int ActionPointCurrent
        {
            get => _actionPointCurrent;
            set
            {
                _actionPointCurrent = value;
                OnPropertyChanged(nameof(ActionPointCurrent));
            }
        }

        public int Shield
        {
            get => _shield;
            set
            {
                _shield = value;
                OnPropertyChanged(nameof(Shield));
            }
        }
        public int ShieldRemainRate { get; set; }


        public List<AttackSkill> AttackSkills { get; set; } = new List<AttackSkill>();
        public List<SupportSkill> SupportSkills { get; set; } = new List<SupportSkill>();
        public List<AttackSkill> AttackSkillsToUse { get; set; } = new List<AttackSkill>();
        public List<SupportSkill> SupportSkillsToUse { get; set; } = new List<SupportSkill>();

        public List<Effect> FightStartEffects { get; set; } = new List<Effect>();
        public List<Effect> RoundStartEffects { get; set; } = new List<Effect>();
        public List<Effect> AttactingEffects { get; set; } = new List<Effect>();
        public List<Effect> AttactedEffects { get; set; } = new List<Effect>();
        public List<Effect> RoundEndEffects { get; set; } = new List<Effect>();

        public BuffPanel Buffs { get; } = new BuffPanel();

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void EmplaceEffect(IFightable character)
        {
            var effectList = new List<Effect>();
            foreach (Force force in AllForces.GetForcesByNames(character.EquippedForces))
            {
                effectList.AddRange(force.Effects);
            }
            var effectGroups = effectList.GroupBy(a => a.Occasion);
            foreach (var group in effectGroups)
            {
                switch (group.Key)
                {
                    case EffectOccasion.FightStart:
                        FightStartEffects.AddRange(group);
                        break;
                    case EffectOccasion.RoundStart:
                        RoundStartEffects.AddRange(group);
                        break;
                    case EffectOccasion.RoundEnd:
                        RoundEndEffects.AddRange(group);
                        break;
                    case EffectOccasion.Attacting:
                        AttactingEffects.AddRange(group);
                        break;
                    case EffectOccasion.Attacted:
                        AttactedEffects.AddRange(group);
                        break;
                    default:
                        break;
                }
            }
        }

        private void UseEffects(List<Effect> effects, CharacterInFight target=null)
        {
            effects.ForEach(e => e.TakeEffect(this,target));
        }
        public void UseFightStartEffects()
        {
            UseEffects(FightStartEffects);
        }
        public void UseRoundStartEffects() => UseEffects(RoundStartEffects);
        public void UseRoundEndEffects() => UseEffects(RoundEndEffects);

        public void TakeSkillInstruction(List<AttackSkill> attackSkills,List<SupportSkill> supportSkills)
        {
            AttackSkillsToUse = attackSkills;
            SupportSkillsToUse = supportSkills;
        }

        public void CastInstructedSupportSkills()
        {
            SupportSkillsToUse.ForEach(skill => CastSupportSkill(skill));
            SupportSkillsToUse.Clear();
        }
        public void CastSupportSkill(SupportSkill skill)
        {
            Thread.Sleep(_skillDelay);
            if (!PaySkillCost(skill))
                return;
            skill.Perform(this);
            Thread.Sleep(_skillDelay);
        }

        public void CastInstructedAttackSkills(CharacterInFight target)
        {
            AttackSkillsToUse.ForEach(skill => CastAttackSkill(skill,target));
            AttackSkillsToUse.Clear();
        }
        public void CastAttackSkill(AttackSkill skill,CharacterInFight target)
        {
            Thread.Sleep(_skillDelay);
            if (!PaySkillCost(skill))
                return;
            skill.Perform(this,target);
            this.AttactingEffects.ForEach(effect => effect.TakeEffect(this, target));
            target.AttactedEffects.ForEach(effect => effect.TakeEffect(target, this));
            Thread.Sleep(_skillDelay);
        }

        private bool PaySkillCost(Skill skill)
        {
            if (MPCurrent < skill.MPCost)
                return false;
            else
            {
                MPCurrent -= skill.MPCost;
                return true;
            }
        }
    }
}
