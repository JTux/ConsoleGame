using Game.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Extensions
{
    public static class MenuConsoleExtensions
    {
        public static void Display(this Menu menu)
        {
            Console.WriteLine(menu.Title + "\n");

            var displayNumber = 1;

            for (int i = 0; i < menu.Options.Count; i++)
            {
                if (menu.Options[i].IsEnabled)
                    Console.WriteLine($"{displayNumber++}) " + menu.Options[i].Text);
            }
        }
    }
}
