using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Items
{
    public class Gold : Item
    {
        private int _count = 0;

        public Gold(int count)
        {
            _count = count;
        }

        public override string Name
        {
            get => $"{Value} Gold Coin{(Value != 1 ? "s" : "")}";
        }

        public override int Value
        {
            get => _count;
            protected set => _count = value;
        }
    }
}
