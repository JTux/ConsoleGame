using Game.Models.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Items.Armor
{
    public class Armor : Item, IArmor
    {
        private readonly int _id;
        private string _name;

        public Armor(int id, string name, int requiredLevel, int value, int additionalHealth, CombatStyle combatStyle, params ArmorCategory[] armorCategories)
        {
            _id = id;
            _name = name;
            Value = value;
            RequiredLevel = requiredLevel;
            BonusHealth = additionalHealth;
            CombatStyle = combatStyle;
            ArmorCategories = armorCategories;
        }

        public override int Id => _id;
        public override string Name => _name;
        public override int RequiredLevel { get; }

        public int BonusHealth { get; }
        public CombatStyle CombatStyle { get; }
        public ArmorCategory[] ArmorCategories { get; }


        public bool IsEquipped { get; protected set; }
    }
}
