using System;
using System.Collections;
using System.Collections.Generic;
using Item.Synthesis;
using UnityEngine;
using UnityEngine.UI;

namespace Item.GachaItem
{
    public class Sample : MonoBehaviour
    {
        [SerializeField] private Button[] _btnDrawButtons;

        private void Start()
        {
            GachaItemSystem gachaItemSystem = new GachaItemSystem();

            Action[] updateGachaEventHandler = new Action[]
            {
                ()=> gachaItemSystem.UpdateGachaItemList(DrawWeaponList()),
                ()=> gachaItemSystem.UpdateGachaItemList(DrawArmorList()),
                ()=> gachaItemSystem.UpdateGachaItemList(DrawMixList()),
            };

            for (int i = 0; i < _btnDrawButtons.Length; i++)
            {
                int index = 0;
                _btnDrawButtons[i].onClick.AddListener(()=>
                {
                    updateGachaEventHandler[index].Invoke();
                    gachaItemSystem.ShowGachaView();
                    
                    foreach (var button in _btnDrawButtons)
                        button.gameObject.SetActive(false);
                });
            }
        }

        private GachaItemList DrawWeaponList()
        {
            List<GachaProbability> probabilities = new List<GachaProbability>()
            {
                {new GachaProbability(EItemType.Weapon.ToString(), 1, 50)},
                {new GachaProbability(EItemType.Weapon.ToString(), 2, 20)},
                {new GachaProbability(EItemType.Weapon.ToString(), 3, 10)},
            };

            GachaItemList gachaItemList = new GachaItemList(probabilities);
            return gachaItemList;
        }

        private GachaItemList DrawArmorList()
        {
            List<GachaProbability> probabilities = new List<GachaProbability>()
            {
                {new GachaProbability(EItemType.Armor.ToString(), 1, 50)},
                {new GachaProbability(EItemType.Armor.ToString(), 2, 20)},
                {new GachaProbability(EItemType.Armor.ToString(), 3, 10)},
            };

            GachaItemList gachaItemList = new GachaItemList(probabilities);
            return gachaItemList;
        }

        private GachaItemList DrawMixList()
        {
            List<GachaProbability> probabilities = new List<GachaProbability>()
            {
                {new GachaProbability(EItemType.Weapon.ToString(), 1, 50)},
                {new GachaProbability(EItemType.Weapon.ToString(), 2, 20)},
                {new GachaProbability(EItemType.Weapon.ToString(), 3, 10)},

                {new GachaProbability(EItemType.Armor.ToString(), 1, 50)},
                {new GachaProbability(EItemType.Armor.ToString(), 2, 20)},
                {new GachaProbability(EItemType.Armor.ToString(), 3, 10)},
            };

            GachaItemList gachaItemList = new GachaItemList(probabilities);
            return gachaItemList;
        }
    }
}