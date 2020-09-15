using System;
using System.IO;
using System.Text;
using System.Text.Json;
using WuLinZhi.Core;
using WuLinZhi.Core.Equipment;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var me = RecordWorker.Load(1);
            Console.WriteLine(me);
        }
        static void SaveCharacter()
        {
            var character = new MainCharacter
            {
                Name = "LZHMA",
                HPBase = 2000,
                HPAmplification = 0,
                MPBase = 1000,
                MPAmplification = 0,
                VitalityBase = 300,
                StrengthBase = 260,
                AgilityBase = 200,
                Weapon = new EquipmentBase
                {
                    Name = "轩辕剑",
                    Type = EquipmentType.Weapon,
                    HP = 200,
                    MP = 100,
                    Vitiality = 50,
                    Strength = 30,
                    Agility = 40,
                    Price = 10,
                }
            };
            RecordWorker.SaveCharacter(character,1);
        }

        static void PrintMainCharacter()
        {
            var me = new MainCharacter
            {
                HPBase = 500,
                AgilityBase = 500,
            };
            Console.WriteLine(me);
        }

        static void DeserializeEquipment()
        {
            var jsonString = File.ReadAllText(@"./pvf/json1.json", Encoding.UTF8);
            JsonDocument document = JsonDocument.Parse(jsonString);
            JsonElement element = document.RootElement;
            var swordElement = element.GetProperty("XuanyuanSword").GetRawText();
            Console.WriteLine(swordElement);
            var sword = JsonSerializer.Deserialize<EquipmentBase>(swordElement);
            Console.WriteLine(sword.Name);
        }
    }
}
