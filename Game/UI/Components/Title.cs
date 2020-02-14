using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UI.Components
{
    public class Title
    {
        public Title(string content) => _content = content;

        private string _content;
        public string Content
        {
            get => _content.Replace(';', '\n');
            private set => _content = value;
        }
    }
}
