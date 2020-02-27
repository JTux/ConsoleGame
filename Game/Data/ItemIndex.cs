using Game.Models;
using Game.Models.Items;
using Game.Models.Items.Armor;
using Game.Models.Items.Potions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Data
{
    public static class ItemIndex
    {
        private static Dictionary<int, Item> _itemIndex;

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
            _itemIndex = new Dictionary<int, Item>
            {
                // Potions
                { 1, new HealthPotion(1, "Minor Health Potion", 10, 7) },
                { 2, new HealthPotion(2, "Health Potion", 22, 15) },
                { 3, new HealthPotion(3, "Major Health Potion", 40, 30) },
                { 4, new Poison(4, "Minor Poison", 15, 8) },
                { 5, new Poison(5, "Poison", 25, 18) },
                { 6, new Poison(6, "Major Poison", 50, 35) },

                //-- Armors
                // Melee
                { 7, new Armor(7, "Bronze Helmet", 1, 100, 35, CombatStyle.Melee, ArmorCategory.Head) },
                { 8, new Armor(8, "Bronze Platebody", 1, 100, 35, CombatStyle.Melee, ArmorCategory.Chest) },
                { 9, new Armor(9, "Bronze Gauntlets", 1, 100, 35, CombatStyle.Melee, ArmorCategory.Hands) },
                { 10, new Armor(10, "Bronze Platelegs", 1, 100, 35, CombatStyle.Melee, ArmorCategory.Legs, ArmorCategory.Feet) },

                { 11, new Armor(11, "Iron Helmet", 5, 100, 35, CombatStyle.Melee, ArmorCategory.Head) },
                { 12, new Armor(12, "Iron Platebody", 5, 100, 35, CombatStyle.Melee, ArmorCategory.Chest) },
                { 13, new Armor(13, "Iron Gauntlets", 5, 100, 35, CombatStyle.Melee, ArmorCategory.Hands) },
                { 14, new Armor(14, "Iron Platelegs", 5, 100, 35, CombatStyle.Melee, ArmorCategory.Legs, ArmorCategory.Feet) },

                { 15, new Armor(15, "Steel Helmet", 10, 100, 35, CombatStyle.Melee, ArmorCategory.Head) },
                { 16, new Armor(16, "Steel Platebody", 10, 100, 35, CombatStyle.Melee, ArmorCategory.Chest) },
                { 17, new Armor(17, "Steel Gauntlets", 10, 100, 35, CombatStyle.Melee, ArmorCategory.Hands) },
                { 18, new Armor(18, "Steel Platelegs", 10, 100, 35, CombatStyle.Melee, ArmorCategory.Legs, ArmorCategory.Feet) },

                // Ranged
                { 19, new Armor(19, "Leather Coif", 1, 100, 35, CombatStyle.Ranged, ArmorCategory.Head) },
                { 20, new Armor(20, "Leather Body", 1, 100, 35, CombatStyle.Ranged, ArmorCategory.Chest) },
                { 21, new Armor(21, "Leather Gloves", 1, 100, 35, CombatStyle.Ranged, ArmorCategory.Hands) },
                { 22, new Armor(22, "Leather Chaps", 1, 100, 35, CombatStyle.Ranged, ArmorCategory.Legs) },
                { 23, new Armor(23, "Leather Boots", 1, 100, 35, CombatStyle.Ranged, ArmorCategory.Feet) },

                { 24, new Armor(24, "Hard Leather Helmet", 5, 100, 35, CombatStyle.Ranged, ArmorCategory.Head) },
                { 25, new Armor(25, "Hard Leather Body", 5, 100, 35, CombatStyle.Ranged, ArmorCategory.Chest) },
                { 26, new Armor(26, "Hard Leather Gloves", 5, 100, 35, CombatStyle.Ranged, ArmorCategory.Hands) },
                { 27, new Armor(27, "Hard Leather Chaps", 5, 100, 35, CombatStyle.Ranged, ArmorCategory.Legs) },
                { 28, new Armor(28, "Hard Leather Boots", 5, 100, 35, CombatStyle.Ranged, ArmorCategory.Feet) },

                { 29, new Armor(29, "Armored Helmet", 10, 100, 35, CombatStyle.Ranged, ArmorCategory.Head) },
                { 30, new Armor(30, "Armored Body", 10, 100, 35, CombatStyle.Ranged, ArmorCategory.Chest) },
                { 31, new Armor(31, "Armored Gloves", 10, 100, 35, CombatStyle.Ranged, ArmorCategory.Hands) },
                { 32, new Armor(32, "Armored Chaps", 10, 100, 35, CombatStyle.Ranged, ArmorCategory.Legs) },
                { 33, new Armor(33, "Armored Boots", 10, 100, 35, CombatStyle.Ranged, ArmorCategory.Feet) },

                // Mage
                { 34, new Armor(34, "Magic Hat", 1, 100, 35, CombatStyle.Mage, ArmorCategory.Head) },
                { 35, new Armor(35, "Magic Robe", 1, 100, 35, CombatStyle.Mage, ArmorCategory.Chest) },
                { 36, new Armor(36, "Magic Gloves", 1, 100, 35, CombatStyle.Mage, ArmorCategory.Hands) },
                { 37, new Armor(37, "Magic Skirt", 1, 100, 35, CombatStyle.Mage, ArmorCategory.Legs) },
                { 38, new Armor(38, "Magic Boots", 1, 100, 35, CombatStyle.Mage, ArmorCategory.Feet) },

                { 39, new Armor(39, "Elemental Hat", 5, 100, 35, CombatStyle.Mage, ArmorCategory.Head) },
                { 40, new Armor(40, "Elemental Robe", 5, 100, 35, CombatStyle.Mage, ArmorCategory.Chest) },
                { 41, new Armor(41, "Elemental Gloves", 5, 100, 35, CombatStyle.Mage, ArmorCategory.Hands) },
                { 42, new Armor(42, "Elemental Skirt", 5, 100, 35, CombatStyle.Mage, ArmorCategory.Legs) },
                { 43, new Armor(43, "Elemental Boots", 5, 100, 35, CombatStyle.Mage, ArmorCategory.Feet) },

                { 44, new Armor(44, "Mystic Hat", 10, 100, 35, CombatStyle.Mage, ArmorCategory.Head) },
                { 45, new Armor(45, "Mystic Robe", 10, 100, 35, CombatStyle.Mage, ArmorCategory.Chest) },
                { 46, new Armor(46, "Mystic Gloves", 10, 100, 35, CombatStyle.Mage, ArmorCategory.Hands) },
                { 47, new Armor(47, "Mystic Skirt", 10, 100, 35, CombatStyle.Mage, ArmorCategory.Legs) },
                { 48, new Armor(48, "Mystic Boots", 10, 100, 35, CombatStyle.Mage, ArmorCategory.Feet) },
            };
        }
    }
}
