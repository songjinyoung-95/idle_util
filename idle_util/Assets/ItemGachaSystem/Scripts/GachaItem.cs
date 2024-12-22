using Item.Synthesis;
using UnityEngine;

namespace Item.GachaItem
{
    public class GachaItem
    {
        public SynthesisItem Item { get; private set; }
        public Sprite ItemSprite { get; private set; }

        public GachaItem(SynthesisItem item, Sprite sprite)
        {
            Item        = item;
            ItemSprite  = sprite;
        }
    }
}