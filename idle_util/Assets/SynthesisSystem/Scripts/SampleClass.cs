using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Synthesis
{
    public class SampleClass : MonoBehaviour
    {
        SynthesisSystem _synthesisSystem;

        private List<SynthesisItem> _items;
        private List<SynthesisRule> _rules;

        private void Start()
        {
            TestAddItems();
            TestAddRules();

            _synthesisSystem = new SynthesisSystem(_rules);
            _synthesisSystem.SynthesizeAllItems(_items, _rules);

            for (int i = 0; i < _items.Count; i++)
                Debug.Log($"{_items[i].Type} , {_items[i].Tier}");
        }

        private void TestAddItems()
        {
            string weapon   = EItemType.Weapon.ToString();
            string armor    = EItemType.Armor.ToString();

            _items = new List<SynthesisItem>()
            {
                new SynthesisItem(100001, 1, weapon),
                new SynthesisItem(100001, 1, weapon),
                new SynthesisItem(100001, 1, weapon),

                new SynthesisItem(100001, 1, armor),
                new SynthesisItem(100001, 1, armor),
                new SynthesisItem(100001, 1, armor),
            };
        }

        private void TestAddRules()
        {
            _rules = new List<SynthesisRule>();

            _rules.Add(new SynthesisRule("Weapon", 1, 3, 2));
            _rules.Add(new SynthesisRule("Armor", 1, 3, 2));
        }
    }
}