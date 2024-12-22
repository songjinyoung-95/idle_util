using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.GachaItem
{
    public class GachaItemList
    {
        private List<GachaProbability> _probabilities;

        public GachaItemList(List<GachaProbability> probabilities)
        {
            _probabilities = probabilities;
        }

        public GachaProbability GetGachaItem()
        {
            float totalWeight = 0;
            foreach (var probability in _probabilities)
            {
                totalWeight += probability.Weight;
            }

            float randomValue       = Random.Range(0f, totalWeight);
            float cumulativeWeight  = 0;

            foreach (var probability in _probabilities)
            {
                cumulativeWeight += probability.Weight;

                if(randomValue <= cumulativeWeight)
                    return probability;
            }

            Debug.LogError("가중치의 총 합이 0입니다. 리스트를 확인하거나 확률을 확인해주세요");
            return null;
        }
    }
}