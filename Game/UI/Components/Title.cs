using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UI.Components
{
    public class Title
    {
        private string _content;
        
        public Title(string content) => _content = content;

        public string Content
        {
            get => _content.Replace(';', '\n');
            private set => _content = value;
        }

        public override string ToString() => Content;
    }
}
