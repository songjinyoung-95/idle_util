using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Synthesis
{
    public interface ISynthesisSystem
    {
        /// <summary>
        /// 합성 함수
        /// </summary>
        SynthesisResult Synthesize(List<SynthesisItem> items, SynthesisRule rule);

        /// <summary>
        /// 합성에 필요한 룰
        /// </summary>
        List<SynthesisRule> GetAvailableRules(List<SynthesisItem> items);
    }
}
