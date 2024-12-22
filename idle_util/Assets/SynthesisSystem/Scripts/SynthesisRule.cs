using UnityEngine;

namespace Item.Synthesis
{
    public class SynthesisRule
    {
        public SynthesisRule(string type, int requirTier, int requirCount, int resultTier)
        {
            Type        = type;
            RequirTier  = requirTier;
            RequirCount = requirCount;
            ResultTier  = resultTier;
        }

        public string Type      { get; private set; } // 합성 타입
        public int RequirTier   { get; private set; } // 합성 할 티어
        public int RequirCount  { get; private set; } // 합성에 필요한 재료 개수
        public int ResultTier   { get; private set; } // 결과물의 등급
    }
}