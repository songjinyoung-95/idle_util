using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Item.GachaItem
{
    public class GachaItemSlot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tmpTier;
        [SerializeField] private Image _itemSprite;

        public void SetItemInfo(Sprite itemSprite, string tierText)
        {
            _tmpTier.text = tierText;
            _itemSprite.sprite = itemSprite;
        }
    }
}