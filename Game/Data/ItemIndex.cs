using Game.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Data
{
    public static class ItemIndex
    {
        private static readonly Dictionary<int, Item> _itemIndex = new Dictionary<int, Item>();

        static ItemIndex() => PopulateIndex();

        public static Item GetItemById(int itemId)
        {
            try
            {
                return _itemIndex[itemId];
            }
            catch
            {
                return null;
            }
        }

        private static void PopulateIndex()
        {
        }
    }
}
