using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Items
{
    public abstract class Item
    {
        public virtual int Id { get; }
        public abstract string Name { get; }
        public virtual int Value { get; protected set; }

        public virtual int RequiredLevel { get; } = 0;

        public override string ToString() => $"{Id}";
    }
}
