using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Item.GachaItem
{
    public class GachaView : MonoBehaviour
    {
        private readonly int[] DRAW_COUNTS = new int[] { 10, 30, 100 };

        public delegate GachaItem[] GachaItemEventHandler(int count);
        public event GachaItemEventHandler OnGachaItem;

        [SerializeField] private GameObject _panel;
        [SerializeField] private GachaRewardView _rewardView;
        [SerializeField] private Button[] _drawButtons;

        private readonly WaitForSeconds _drawDelay = new WaitForSeconds(0.05f);

        public void Initailize()
        {
            _panel.SetActive(false);

            for (int i = 0; i < _drawButtons.Length; i++)
            {
                int index = i;
                _drawButtons[i].onClick.AddListener(() => GetGachaItem(index));
                DrawButtonsActivation(false);
            }

            _rewardView.Initialize();
        }

        public void ShowView()
        {
            _panel.SetActive(true);
            _rewardView.ShowView();

            DrawButtonsActivation(true);
        }

        private void DrawButtonsActivation(bool isActive)
        {
            for (int i = 0; i < _drawButtons.Length; i++)
                _drawButtons[i].gameObject.SetActive(isActive);

        }

        private void GetGachaItem(int index)
        {
            GachaItem[] gachaItem = OnGachaItem?.Invoke(DRAW_COUNTS[index]);

            _rewardView.RefreshGachaItemSlot();
            DrawButtonsActivation(false);

            StartCoroutine(Co_DrawGachaItemDelay());

            IEnumerator Co_DrawGachaItemDelay()
            {
                foreach (var item in gachaItem)
                {
                    _rewardView.GetGachaItemSlot(item.ItemSprite, item.Item.Tier.ToString());
                    yield return _drawDelay;
                }
                
                DrawButtonsActivation(true);
            }
        }
    }
}