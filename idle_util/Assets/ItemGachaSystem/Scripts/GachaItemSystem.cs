using Item.Synthesis;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Item.GachaItem
{
    public class GachaItemSystem
    {
        private GachaItemList _currentyGachaList;
        private GachaView _view;

        public GachaItemSystem()
        {
            AsyncLoadView();
        }

        public void UpdateGachaItemList(GachaItemList itemList)
        {
            _currentyGachaList = itemList;
        }

        public void ShowGachaView()
        {
            _view.ShowView();
        }

        private async void AsyncLoadView()
        {
            var handle = Addressables.InstantiateAsync("GachaView");

            await handle.Task;

            if (handle.Status != UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"Addressables {typeof(GachaView)} is null");
                return;
            }

            if(!handle.Result.TryGetComponent<GachaView>(out var component))
            {
                Debug.LogError($"{component} is null");
                return;
            }

            _view = component;
            _view.Initailize();

            _view.OnGachaItem += GachaDraw;
        }



        private GachaItem[] GachaDraw(int count)
        {
            if(_currentyGachaList == null)
            {
                Debug.LogError($"가챠 아이템 확률을 설정하지 않았습니다");
                return null;
            }

            GachaItem[] gachaItems = new GachaItem[count];

            for (int i = 0; i < count; i++)
                gachaItems[i] = DrawRandomItem();

            if (gachaItems.Length <= 0)
                Debug.LogError($"가챠 횟수가 1회 미만으로 설정되었습니다");

            return gachaItems;
        }

        private GachaItem DrawRandomItem()
        {
            GachaProbability gachaProbability = _currentyGachaList.GetGachaItem();

            string type = gachaProbability.ItemType;
            int tier    = gachaProbability.Tier;
            int id      = SynthesisItemLookup.GetID(type, tier);

            GachaItem selectedItem = new GachaItem(new SynthesisItem(id, tier, type), null);

            Debug.Log($"획득 아이템 = {id},{tier},{type}");

            return selectedItem;
        }
    }
}