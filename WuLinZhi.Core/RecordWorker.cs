using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using WuLinZhi.Core.Character;
using System.IO;
using System;

namespace WuLinZhi.Core
{
    public static class RecordWorker
    {
        static String pathBase = Directory.GetCurrentDirectory()+@"\Saves\Record";

        static JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            IgnoreReadOnlyProperties = true,
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All)
        };
        static JsonWriterOptions writerOptions = new JsonWriterOptions
        {
            Indented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All),
        };
        static JsonDocumentOptions documentOptions = new JsonDocumentOptions
        {
            CommentHandling = JsonCommentHandling.Skip,
        };

        public static MainCharacter LoadCharacter(string path)
        {
            string jsonString = File.ReadAllText(path, Encoding.UTF8);
            var character = JsonSerializer.Deserialize<MainCharacter>(jsonString);
            return character;
        }
        public static MainCharacter Load(int index)
        {
            var folderPath = pathBase + index + @"/";
            var characterPath = folderPath + @"Character.json";
            var character = LoadCharacter(characterPath);
            return character;
        }
        public static MainCharacter LoadInitial()
        {
            var pathInitial = pathBase + @"Initial/";
            var character = LoadCharacter(pathInitial);
            return character;
        }

        public static void SaveCharacter(MainCharacter character, int index=0)
        {
            var folderPath = pathBase + index;
            Directory.CreateDirectory(folderPath);
            var characterPath = folderPath + @"/Character.json";
            Console.WriteLine(characterPath);
            string characterJson = JsonSerializer.Serialize<MainCharacter>(character, serializerOptions);
            File.WriteAllText(characterPath, characterJson, Encoding.UTF8);
        }
    }
}