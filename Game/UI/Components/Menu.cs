using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UI.Components
{
    public class Menu
    {
        public Title Title { get; set; }
        public List<MenuItem> Options { get; private set; }
    }
}
