using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using WuLinZhi.Core;
using WuLinZhi.Core.Equipment;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Lab
{
    class Program
    {
        static JsonSerializerOptions option = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All)
        };
        static void Main(string[] args)
        {
            LoadCharacter();
        }

        static void LoadCharacter()
        {
            var character=RecordLoader.Load(@"../WuLinZhi.Core/Saves/Record1.json");
            Console.WriteLine(character);
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
        static void SerializeEquipmentToJson()
        {
            EquipmentBase sword = new EquipmentBase()
            {
                Name = "轩辕剑",
                Type = EquipmentType.Weapon,
                HP = 200,
                MP = 100,
                Vitiality = 50,
                Strength = 30,
                Agility = 40,
                Price = 10,
            };
            string result = JsonSerializer.Serialize<EquipmentBase>(sword, option);
            Console.WriteLine(result);
        }
    }
}
