using System.Text.Json;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core
{
    public static class SaveLoader
    {
        public static MainCharacter Load(string savePath)
        {
            JsonDocument document=JsonDocument.Parse("./Saves");
            return new MainCharacter();
        }
    }
}