namespace Item.Synthesis
{
    [System.Serializable]
    public class SynthesisItem
    {
        public SynthesisItem(int id, int tier, string type)
        {
            Id      = id;
            Tier    = tier;
            Type    = type;
        }

        public int Id           { get; private set; } // 아이템 고유 아이디
        public int Tier         { get; private set; } // 아이템 티어
        public string Type      { get; private set; } // 아이템 타입
    }
}