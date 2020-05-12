using System;
using System.Collections.Generic;

using Game.Engine.Items.BasicArmor;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class AdvancedItemFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> items = new List<Item>()
            {
                new WoodArmor(),
                new ElephantsBane(),
                new NullMagicHatchet()
                
            };
            return items[Index.RNG(0, items.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> items = new List<Item>()
            {
                new WoodArmor(),
                new NullMagicHatchet()
            };
            return items[Index.RNG(0, items.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            // BerserkerArmor only works for physical damage dealers
            List<Item> items = new List<Item>()
            {
                new WoodArmor(),
                new ElephantsBane()
            };
            return items[Index.RNG(0, items.Count)];
        }
    }
}
