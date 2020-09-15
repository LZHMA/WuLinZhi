namespace WuLinZhi.Core.Character
{
    public class NPC:IFightable
    {
        public int HP { get; set; }
        public int MP { get; set; }
        public int Vitality { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }

        public NPC ShallowClone()
        {
            return this.MemberwiseClone() as NPC;
        }
    }
}