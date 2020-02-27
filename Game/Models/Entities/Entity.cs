using Game.Models.Items;
using Game.Models.Items.Interfaces;
using Game.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Entities
{
    public abstract class Entity
    {
        protected int _currentHealth;
        protected int _baseHealth;
        protected int _hpPerLevel;

        public Entity(int id, string name, int level, int baseHealth, int hpPerLevel)
        {
            Id = id;
            Name = name;
            Level = level;

            _baseHealth = baseHealth;
            _hpPerLevel = hpPerLevel;

            _currentHealth = MaxHealth;
        }
        public Entity(int id, string name, int level, int baseHealth, int hpPerLevel, int gold, List<Item> inventory, List<Skill> skills)
            : this(id, name, level, baseHealth, hpPerLevel)
        {
            Gold = gold;
            Inventory = inventory;
            Skills = skills;

            _currentHealth = MaxHealth;
        }
        public Entity(int id, string name, int level, int xp, int baseHealth, int health, int hpPerLevel, int gold, List<Item> inventory, List<Skill> skills)
            : this(id, name, level, baseHealth, hpPerLevel, gold, inventory, skills)
        {
            Health = health;
            XP = xp;
        }

        public int Id { get; protected set; }
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public double XP { get; set; } = 0;
        public int BaseHealth => _baseHealth + ((Level - 1) * _hpPerLevel);
        public int MaxHealth
        {
            get
            {
                var armorHealth = Inventory.Where(i => i is IArmor && ((IArmor)i).IsEquipped).Select(i => i as IArmor).Sum(a => a.BonusHealth);
                return BaseHealth + armorHealth;
            }
        }
        public int Health
        {
            get
            {
                return _currentHealth;
            }
            set
            {
                if (value > MaxHealth)
                {
                    _currentHealth = MaxHealth;
                }
                else if (value <= 0)
                {
                    _currentHealth = 0;
                }
                else
                {
                    _currentHealth = value;
                }
            }
        }
        public bool IsAlive => Health > 0;
        public int Gold { get; set; }
        public List<Item> Inventory { get; set; } = new List<Item>();
        public List<Skill> Skills { get; set; } = new List<Skill>();

        public CombatStyle CombatStyle { get; set; }
    }
}
