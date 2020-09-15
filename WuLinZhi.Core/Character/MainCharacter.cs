using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using WuLinZhi.Core.Equipment;
using WuLinZhi.Core.Force;

namespace WuLinZhi.Core.Character
{
    public class MainCharacter : IFightable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        #region property
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                if(this.PropertyChanged!=null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public int HPBase { get; set; }
        public int HPEquipment
        {
            get => Weapon.HP + Armor.HP + Shoes.HP;
        }
        public int HPAmplification { get; set; }
        public int HP
        {
            get => (HPBase + HPEquipment) * (100 + HPAmplification) / 100;
        }

        public int MPBase { get; set; }
        public int MPEquipment
        {
            get => Weapon.MP + Armor.MP + Shoes.MP;
        }
        public int MPAmplification { get; set; }
        public int MP
        {
            get => (MPBase + MPEquipment) * (100 + MPAmplification) / 100;
        }

        public int VitalityBase { get; set; }
        public int VitalityEquipment
        {
            get => Weapon.Vitiality + Armor.Vitiality + Shoes.Vitiality;
        }
        public int VitalityAmplification { get; set; }
        public int Vitality
        {
            get => (VitalityBase + VitalityEquipment) * (100 + VitalityAmplification) / 100;
        }

        public int StrengthBase { get; set; }
        public int StrengthEquipment
        {
            get => Weapon.Strength + Armor.Strength + Shoes.Strength;
        }
        public int StrengthAmplification { get; set; }
        public int Strength
        {
            get => (StrengthBase + StrengthEquipment) * (100 + StrengthAmplification) / 100;
        }

        public int AgilityBase { get; set; }
        public int AgilityEquipment
        {
            get => Weapon.Agility + Armor.Agility + Shoes.Agility;
        }
        public int AgilityAmplification { get; set; }
        public int Agility
        {
            get => (AgilityBase + AgilityEquipment) * (100 + AgilityAmplification) / 100;
        }

        public int Attack { get; set; }
        public int Defence { get; set; }
        public int CriticalAttack
        {
            get => Agility / 50;
        }
        public int CriticalDefence
        {
            get => Agility / 50;
        }


        public ICollection<ForceBase> Forces { get; set; }

        public EquipmentBase Weapon { get; set; }
        public EquipmentBase Armor { get; set; }
        public EquipmentBase Shoes { get; set; }

        #endregion

        public void OnEquipmentChange(object sender, EventArgs e)
        {
        }

        public void OnForceChange(object sender, EventArgs e)
        {

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