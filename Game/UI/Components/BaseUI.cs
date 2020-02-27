using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UI.Components
{
    public abstract class BaseUI
    {
        protected Menu _menu;
        protected abstract void SetMenu();
    }

    public abstract class BaseUI<T> : BaseUI
    {
        public abstract T Run();
    }
}
