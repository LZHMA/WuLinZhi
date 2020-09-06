using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using WuLinZhi.Core.Equipment;
using WuLinZhi.Core.Force;

namespace WuLinZhi.Core.Character
{
    public class MainCharacter:IFightable
    {
        #region property
        public string Name{get;set;}

        public int HPBase { get; set; }
        public int HPEquipment { get; set; }
        public int HPForce { get; set; }
        public int HPAmplification { get; set; }
        public int HP
        {
            get => (HPBase + HPEquipment + HPForce) * (100 + HPAmplification) / 100;
        }

        public int MPBase { get; set; }
        public int MPEquipment { get; set; }
        public int MPForce { get; set; }
        public int MPAmplification { get; set; }
        public int MP
        {
            get => (MPBase + MPEquipment + MPForce) * (100 + MPAmplification) / 100;
        }

        public int VitalityBase { get; set; }
        public int VitalityEquipment { get; set; }
        public int VitalityForce { get; set; }
        public int VitalityAmplification { get; set; }
        public int Vitality
        {
            get => (VitalityBase + VitalityEquipment + VitalityForce) * (100 + VitalityAmplification) / 100;
        }

        public int StrengthBase { get; set; }
        public int StrengthEquipment { get; set; }
        public int StrengthForce { get; set; }
        public int StrengthAmplification { get; set; }
        public int Strength
        {
            get => (StrengthBase + StrengthEquipment + StrengthForce) * (100 + StrengthAmplification) / 100;
        }

        public int AgilityBase { get; set; }
        public int AgilityEquipment { get; set; }
        public int AgilityForce { get; set; }
        public int AgilityAmplification { get; set; }
        public int Agility
        {
            get => (AgilityBase + AgilityEquipment + AgilityForce) * (100 + AgilityAmplification) / 100;
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
            HPEquipment = Weapon.HP + Armor.HP + Shoes.HP;
        }

        public void OnForceChange(object sender, EventArgs e)
        {

        }

        public override string ToString()
        {
            var options=new JsonSerializerOptions
            {
                Encoder=System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented=true,
                IgnoreReadOnlyProperties=true,
            };
            var json=JsonSerializer.Serialize<MainCharacter>(this,options);
            return json;
        }

        public MainCharacter ShallowClone()
        {
            return this.MemberwiseClone() as MainCharacter;
        }
    }
}