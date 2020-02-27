using Game.Models.Items;
using Game.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Entities
{
    public class Player : Entity
    {
        public Player(int id, string name) : base(id, name, 1, 10, 2) { }
        public Player(int id, string name, CombatStyle combatStyle) : this(id, name) { CombatStyle = combatStyle; }
        public Player(int id, string name, int level, int baseHealth, int gold, CombatStyle combatStyle, List<Item> inventory, List<Skill> skills)
            : base(id, name, level, baseHealth, 2, gold, inventory, skills) { CombatStyle = combatStyle; }
        public Player(int id, string name, int level, int xp, int baseHealth, int health, int gold, List<Item> inventory, List<Skill> skills)
            : base(id, name, level, xp, baseHealth, health, 2, gold, inventory, skills) { }

        public void UpdateHpPerLevel(int hpPerLevel)
        {
            _hpPerLevel = hpPerLevel;
        }
    }
}
