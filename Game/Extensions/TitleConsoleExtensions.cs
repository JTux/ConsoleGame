using Game.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Extensions
{
    public static class TitleConsoleExtensions
    {
        public static void Display(this Subtitle subtitle, ConsoleColor textColor)
        {
            var defaultTextColor = Console.ForegroundColor;

            Console.ForegroundColor = textColor;
            Console.WriteLine(subtitle.Content);
            Console.ForegroundColor = defaultTextColor;
        }
    }
}
