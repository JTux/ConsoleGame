using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UI.Components
{
    public class MenuItem
    {
        public Func<bool> Action { get; set; }

        public MenuItem(string text, bool isEnabled, Func<bool> menuAction)
        {
            Text = text;
            IsEnabled = isEnabled;
            Action = menuAction;
        }

        public string Text { get; set; }
        public bool IsEnabled { get; set; }

        public bool Activate() => Action.Invoke();
        public void SetAction(Func<bool> newAction) => Action = newAction;
    }
}
