using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using WuLinZhi.Core.Forces;
using WuLinZhi.Core.Skills;

namespace WuLinZhi.Core.Character
{
    public class MainCharacter : IFightable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private int _hp,_mp,_vitality,_strength,_agility,_money;

        #region property
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int HP
        {
            get => _hp;
            set
            {
                _hp = value;
                OnPropertyChanged(nameof(HP));
            }
        }

        public int MP
        {
            get => _mp;
            set
            {
                _mp = value;
                OnPropertyChanged(nameof(MP));
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

        public int Money
        {
            get => _money;
            set
            {
                _money = value;
                OnPropertyChanged(nameof(Money));
            }
        }

        public List<AttackSkill> AttackSkills { get; set; } = new List<AttackSkill>();
        public List<SupportSkill> SupportSkills { get; set; } = new List<SupportSkill>();

        public List<String> LearnedForces { get; } = new List<string>();
        public List<String> EquippedForces { get; } = new List<string>();

        #endregion
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        
        public void EquipForce(string force)
        {
            if (EquippedForces.Count == 5)
                return;
            EquippedForces.Add(force);
        }
        public void UnEquipForce(string force)
        {
            EquippedForces.Remove(force);
        }
        public void ReplaceEquipedForce(string equiped, string toequip)
        {
            UnEquipForce(equiped);
            EquipForce(toequip);
        }

        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
                IgnoreReadOnlyProperties = true,
            };
            var json = JsonSerializer.Serialize<MainCharacter>(this, options);
            return json;
        }

        public MainCharacter ShallowClone()
        {
            return this.MemberwiseClone() as MainCharacter;
        }
    }
}