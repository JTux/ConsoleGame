using Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UI.Components
{
    public class Menu
    {
        public Menu(string header)
        {
            Title = new Title(HeaderTextIndex.GetHeaderByKey(header));
        }
        public Menu(string header, Subtitle subtitle) : this(header) => Subtitle = subtitle;
        public Menu(string header, List<MenuItem> options) : this(header) => Options = options;
        public Menu(string header, Subtitle subtitle, List<MenuItem> options) : this(header, options) => Subtitle = subtitle;

        public Title Title { get; private set; }
        public Subtitle Subtitle { get; private set; }
        public List<MenuItem> Options { get; private set; } = new List<MenuItem>();
    }
}
