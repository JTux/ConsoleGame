using Game.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Items.Potions
{
    class Poison : BasePotion
    {
        private readonly int _damageValue;

        public Poison(int id, string name, int value, int damage)
            : base(id, name, value) => _damageValue = damage;

        public override void Use(Entity target) => target.Health -= _damageValue;
    }
}
