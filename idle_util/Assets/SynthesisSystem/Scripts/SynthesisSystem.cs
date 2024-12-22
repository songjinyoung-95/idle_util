using System.Collections.Generic;
using UnityEngine;

namespace Item.Synthesis
{
    public class SynthesisSystem : ISynthesisSystem
    {
        private List<SynthesisRule> _rules;

        public SynthesisSystem(List<SynthesisRule> rules)
        {
            _rules = rules;
        }

        /// <summary>
        /// 합성에 필요한 규칙 가져오는 함수
        /// </summary>
        public List<SynthesisRule> GetAvailableRules(List<SynthesisItem> items)
        {
            List<SynthesisRule> availableRules = new List<SynthesisRule>();
            
            foreach (var rule in _rules)
            {
                int count = 0;

                foreach (var item in items)
                {
                    if(item.Tier != rule.RequirTier)
                    {
                        Debug.Log($"아이템 티어가 다릅니다. 요구 티어 {rule.RequirTier}");
                        continue;
                    }

                    if(item.Type != rule.Type)
                    {
                        Debug.Log($"아이템 타입이 다릅니다. 요구 타입 {rule.Type}");
                        continue;
                    }

                        count++;

                    if (count >= rule.RequirCount)
                    {
                        availableRules.Add(rule);
                        break;
                    }
                }
            }

            return availableRules;
        }

        /// <summary>
        /// 아이템 합성
        /// </summary>
        public SynthesisResult Synthesize(List<SynthesisItem> items, SynthesisRule rule)
        {
            List<SynthesisItem> matchingItems = new List<SynthesisItem>();
            int matchCount = 0;

            foreach (var item in items)
            {
                if (item.Tier != rule.RequirTier)
                {
                    // Debug.Log($"아이템 티어가 다릅니다. 요구 티어 {rule.RequirTier}");
                    continue;
                }

                if (item.Type != rule.Type)
                {
                    // Debug.Log($"아이템 타입이 다릅니다. 요구 타입 {rule.Type}");
                    continue;
                }

                matchingItems.Add(item);
                matchCount++;

                if(matchCount >= rule.RequirCount)
                    break;
            }

            if (matchCount < rule.RequirCount)
            {
                // Debug.Log("합성 아이템 부족");
                return null;
            }

            int resultItemTier      = rule.ResultTier;
            string resultItemType   = rule.Type;
            int resultItemID        = SynthesisItemLookup.GetID(resultItemType, resultItemTier);

            var resultItem  = new SynthesisItem(resultItemID, resultItemTier, resultItemType);
            var result      = new SynthesisResult(resultItem, matchingItems);

            items.Add(result.ResultItem);

            Debug.Log($"합성한 아이템 = ID : {result.ResultItem.Id} Tier : {result.ResultItem.Tier} Type : {result.ResultItem.Type}");

            RemoveConsumeItemList(result.ConsumedItems, items);
            return result;
        }

        /// <summary>
        /// 합성가능한 모든 아이템 합성
        /// </summary>
        public void SynthesizeAllItems(List<SynthesisItem> items, List<SynthesisRule> rules)
        {
            bool hasSynthesized;

            do
            {
                hasSynthesized = false;

                foreach (var rule in rules)
                {
                    while(true)
                    {
                        var result = Synthesize(items, rule);

                        if(result == null)
                            break;
                        else
                            hasSynthesized = true;
                    }
                }
            }
            while (hasSynthesized);
        }    
        
        private void RemoveConsumeItemList(List<SynthesisItem> consumedItems, List<SynthesisItem> items)
        {
            foreach (var consumedItem in consumedItems)
            {
                items.Remove(consumedItem);
            }
        }

    }
}