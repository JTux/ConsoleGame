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
        public static void DisplayTitles(this Menu menu) => menu.DisplayTitles(Console.ForegroundColor);
        public static void DisplayTitles(this Menu menu, ConsoleColor subtitleColor)
        {
            Console.WriteLine(menu.Title + "\n");
            if (menu.Subtitle != null)
                menu.Subtitle.Display(subtitleColor);
        }

        public static void DisplayOptions(this Menu menu, int activeId, int cursorPos)
        {
            var actionNumber = 1;
            Console.CursorTop = cursorPos;
            Console.CursorLeft = 0;

            var activeOptions = menu.Options.Where(o => o.IsEnabled).ToList();

            for (int i = 0; i < activeOptions.Count(); i++)
            {
                if (activeOptions[i].IsEnabled)
                {
                    if (i == activeId)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    var option = $"{actionNumber++}) { activeOptions[i].Text}";
                    var extraSpaces = new string(' ', Console.WindowWidth - option.Length - 1);
                    Console.WriteLine($"{option}{extraSpaces}");
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void GetPlayerAction(this Menu menu) => menu.GetPlayerAction(Console.ForegroundColor);
        public static void GetPlayerAction(this Menu menu, ConsoleColor subtitleColor)
        {
            var menuOption = menu.GetSelectedAction(subtitleColor);
            var options = menu.Options.Where(o => o.IsEnabled).ToList();
            options[menuOption].Activate();
        }

        public static int GetSelectedAction(this Menu menu) => menu.GetSelectedAction(Console.ForegroundColor);
        public static int GetSelectedAction(this Menu menu, ConsoleColor subtitleColor)
        {
            Console.Clear();
            var selectionId = 0;

            menu.DisplayTitles(subtitleColor);

            var cursorPos = Console.CursorTop;
            while (true)
            {
                menu.DisplayOptions(selectionId, cursorPos);

                var optionCount = menu.Options.Where(o => o.IsEnabled).Count();

                var keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.Enter)
                    return selectionId;
                else if (keyPressed == ConsoleKey.UpArrow && selectionId > 0)
                    selectionId--;
                else if (keyPressed == ConsoleKey.DownArrow && selectionId < optionCount - 1)
                    selectionId++;
                else if (InputKeyDict.TryGetValue(keyPressed, out int num) && optionCount > num)
                    selectionId = num;
                else if (keyPressed == ConsoleKey.Home || keyPressed == ConsoleKey.PageUp)
                    selectionId = 0;
                else if (keyPressed == ConsoleKey.End || keyPressed == ConsoleKey.PageDown)
                    selectionId = optionCount - 1;
            }
        }

        static readonly Dictionary<ConsoleKey, int> InputKeyDict = new Dictionary<ConsoleKey, int>
        {
            {ConsoleKey.NumPad1, 0},
            {ConsoleKey.D1, 0},
            {ConsoleKey.NumPad2, 1},
            {ConsoleKey.D2, 1},
            {ConsoleKey.NumPad3, 2},
            {ConsoleKey.D3, 2},
            {ConsoleKey.NumPad4, 3},
            {ConsoleKey.D4, 3},
            {ConsoleKey.NumPad5, 4},
            {ConsoleKey.D5, 4},
            {ConsoleKey.NumPad6, 5},
            {ConsoleKey.D6, 5},
            {ConsoleKey.NumPad7, 6},
            {ConsoleKey.D7, 6},
            {ConsoleKey.NumPad8, 7},
            {ConsoleKey.D8, 7},
            {ConsoleKey.NumPad9, 8},
            {ConsoleKey.D9, 8},
        };
    }
}
