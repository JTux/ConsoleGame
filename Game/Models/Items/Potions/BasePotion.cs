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
        private readonly int _id;

        public BasePotion(int id, string name, int value)
        {
            _id = id;
            _name = name;
            Value = value;
        }

        public override int Id => _id;
        public override string Name => _name;
        public override int Value { get; protected set; }

        public abstract void Use(Entity target);
    }
}
