using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Util.Pool;

namespace Item.GachaItem
{
    public class GachaRewardView : MonoBehaviour
    {
        private const string GACHA_ITEM_SLOT = "GachaItemSlot";

        [SerializeField] private GameObject _panel;
        [SerializeField] private RectTransform _rtf_gridLayout;
        [SerializeField] private GachaItemSlot _slotPrefab;

        private PoolBase<GachaItemSlot> _slotPool;
        private List<GachaItemSlot> _activeSlots;

        public void Initialize()
        {
            _activeSlots = new List<GachaItemSlot>();

            _slotPool = new PoolBase<GachaItemSlot>(transform);
            _slotPool.Generator(_slotPrefab, GACHA_ITEM_SLOT, 10);
            
            HideView();
        }

        public void GetGachaItemSlot(Sprite itemSprite, string tierText)
        {
            // 뽑기 연출 추가

            GachaItemSlot itemSlot = _slotPool.Spawn(GACHA_ITEM_SLOT, Vector3.zero);
            itemSlot.SetItemInfo(itemSprite, tierText);
            itemSlot.transform.SetParent(_rtf_gridLayout);

            _activeSlots.Add(itemSlot);
        }

        public void HideView()
        {
            _panel.SetActive(false);
        }

        public void ShowView()
        {
            _panel.SetActive(true);
        }

        public void RefreshGachaItemSlot()
        {
            foreach (var slot in _activeSlots)
                _slotPool.Despawn(slot, GACHA_ITEM_SLOT);

            _activeSlots.Clear();
        }
    }
}