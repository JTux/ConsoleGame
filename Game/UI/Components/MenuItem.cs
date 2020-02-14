using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UI.Components
{
    public class MenuItem
    {
        public Action Action { get; set; }

        public MenuItem(string text, params Action[] menuActions)
        {
            Text = text;
            IsEnabled = true;

            foreach(var action in menuActions)
                Action += action;
        }
        public MenuItem(string text, bool isEnabled, params Action[] menuActions) : this(text, menuActions)
        {
            IsEnabled = isEnabled;
        }

        public string Text { get; set; }
        public bool IsEnabled { get; set; }

        public void Activate() => Action.Invoke();
        public void SetAction(Action newAction) => Action = newAction;
    }
}
