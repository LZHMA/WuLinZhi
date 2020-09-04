using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using WuLinZhi.Core.Character;
using System.IO;

namespace WuLinZhi.Core
{
    public static class RecordLoader
    {
        public static MainCharacter Load(string savePath)
        {
            string jsonString=File.ReadAllText(savePath,Encoding.UTF8);
            JsonDocument document=JsonDocument.Parse(jsonString);
            var characterElement=document.RootElement.GetProperty("Record");
            var character=JsonSerializer.Deserialize<MainCharacter>(characterElement.GetRawText());
            return character;
        }
    }
}