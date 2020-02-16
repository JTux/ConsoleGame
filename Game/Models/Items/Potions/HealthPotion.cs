using Game.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Items.Potions
{
    public class HealthPotion : BasePotion
    {
        protected readonly int _healthGain;

        public HealthPotion(int id, string name, int value, int healthGain) 
            : base(id, name, value) => _healthGain = healthGain;

        public override void Use(Entity target) => target.Health += _healthGain;
    }
}
