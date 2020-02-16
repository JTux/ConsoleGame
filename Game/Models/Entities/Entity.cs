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

        public Entity(string name, int level, int baseHealth, int hpPerLevel)
        {
            Name = name;
            Level = level;

            _baseHealth = baseHealth;
            _hpPerLevel = hpPerLevel;

            _currentHealth = MaxHealth;

            CalcXP();
        }
        public Entity(string name, int level, int baseHealth, int hpPerLevel, List<Item> inventory)
            : this(name, level, baseHealth, hpPerLevel)
        {
            Inventory = inventory;
            _currentHealth = MaxHealth;
        }

        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public double XP { get; set; } = 0;
        public int BaseHealth => _baseHealth + (Level * _hpPerLevel);
        public int MaxHealth
        {
            get
            {
                var armorHealth = Inventory.Where(i => i is IArmor).Select(i => i as IArmor).Sum(a => a.BonusHealth);
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
        public List<Item> Inventory { get; set; } = new List<Item>();
        public List<Skill> Skills { get; set; }


        private void CalcXP()
        {
            XP = Level * (15 + (5 * (Level)));
        }
    }
}
