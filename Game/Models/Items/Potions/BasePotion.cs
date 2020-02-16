using Game.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Items.Potions
{
    public abstract class BasePotion : Item
    {
        private readonly string _name;

        public BasePotion(string name, int value)
        {
            _name = name;
            Value = value;
        }

        public override string Name => _name;
        public override int Value { get; protected set; }

        public abstract void Use(Entity target);
    }
}
