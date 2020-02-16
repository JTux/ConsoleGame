using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Items
{
    public abstract class Item
    {
        public abstract string Name { get; }
        public virtual int Value { get; protected set; }
    }
}
