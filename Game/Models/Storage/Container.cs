using Game.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Storage
{
    public abstract class Container
    {
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
