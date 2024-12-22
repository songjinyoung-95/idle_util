using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ID   = System.Int32;
using Tier = System.Int32;
using Type = System.String;

namespace Item.Synthesis
{
    public static class SynthesisItemLookup
    {
        private static Dictionary<(Tier, Type), ID> _synthesisItemDictionary;
        private static bool _isInitialized = false;

        private static void Initialize()
        {
            _synthesisItemDictionary ??= new Dictionary<(Tier, Type), ID>();

            string weapon   = EItemType.Weapon.ToString();
            string armor    = EItemType.Armor.ToString();

            _synthesisItemDictionary.Add((1, weapon), 100001);
            _synthesisItemDictionary.Add((2, weapon), 100002);
            _synthesisItemDictionary.Add((3, weapon), 100003);

            _synthesisItemDictionary.Add((1, armor), 200001);
            _synthesisItemDictionary.Add((2, armor), 200002);
            _synthesisItemDictionary.Add((3, armor), 200003);

            _isInitialized = true;

            ///TODO : 아이템 데이터 추가
        }

        /// <summary>
        /// 티어와 타입에 따른 아이템 ID 받아오는 함수
        /// </summary>
        public static int GetID(Type type, Tier tier)
        {   
            if(_isInitialized == false)
                Initialize();

            if (_synthesisItemDictionary.TryGetValue((tier, type), out var id))
            {
                return id;
            }

            Debug.LogError($"Item Type : {type} , Item Tier : {tier}에 해당하는 ID가 등록되어있지않습니다.");
            return 0;
        }
    }
}