using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.GachaItem
{
    public class GachaProbability
    {
        public string ItemType { get; private set; }
        public int Tier { get; private set; }
        public float Weight { get; private set; }

        public GachaProbability(string itemType, int tier, float weight)
        {
            ItemType    = itemType;
            Tier        = tier;
            Weight      = weight;
        }

        public void UpdateProbability(float probabilities)
        {
            Weight = probabilities;
        }
    }
}