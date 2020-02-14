using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UI.Components
{
    public class Menu
    {
        public Menu() { }
        public Menu(string header)
        {
            var headerTextDictionary = new HeaderTextIndex();
            Title = new Title(headerTextDictionary[header]);
        }
        public Menu(string header, List<MenuItem> options) : this(header) => Options = options;

        public Title Title { get; private set; }
        public List<MenuItem> Options { get; private set; } = new List<MenuItem>();
    }
}
