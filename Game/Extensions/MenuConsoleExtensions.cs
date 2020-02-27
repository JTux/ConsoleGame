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

                var activeOptionCount = menu.Options.Where(o => o.IsEnabled).Count();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectionId > 0)
                            selectionId--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectionId < activeOptionCount - 1)
                            selectionId++;
                        break;
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        if (activeOptionCount > 0)
                            selectionId = 0;
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        if (activeOptionCount > 1)
                            selectionId = 1;
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        if (activeOptionCount > 2)
                            selectionId = 2;
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        if (activeOptionCount > 3)
                            selectionId = 3;
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        if (activeOptionCount > 4)
                            selectionId = 4;
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        if (activeOptionCount > 5)
                            selectionId = 5;
                        break;
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.D7:
                        if (activeOptionCount > 6)
                            selectionId = 6;
                        break;
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.D8:
                        if (activeOptionCount > 7)
                            selectionId = 7;
                        break;
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.D9:
                        if (activeOptionCount > 8)
                            selectionId = 8;
                        break;
                    case ConsoleKey.Enter:
                        return selectionId;
                    default: continue;
                }
            }
        }
    }
}
