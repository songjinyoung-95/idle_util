using System.Collections.Generic;
using UnityEngine;

namespace Item.Synthesis
{
    public class SynthesisResult
    {
        public SynthesisResult(SynthesisItem resultItem, List<SynthesisItem> synthesisItems)
        {
            ResultItem      = resultItem;
            ConsumedItems   = synthesisItems;
        }

        public SynthesisItem ResultItem             { get; private set; } // 합성 결과물 아이템
        public List<SynthesisItem> ConsumedItems    { get; private set; } // 합성에 들어간 재료 아이템 목록
    }
}