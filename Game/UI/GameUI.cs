using Game.Extensions;
using Game.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UI
{
    public class GameUI
    {
        private bool _runStatus = true;
        private Menu _mainMenu;

        public void Run()
        {
            SetMenu();

            while (_runStatus)
            {
                Console.Clear();
                _mainMenu.Display();
                GetAction();
            }
        }

        private void SetMenu()
        {
            var saveFileCount = 0;

            var options = new List<MenuItem>
            {
                new MenuItem("Continue Game", saveFileCount > 0, GetLoadGames, Pause),
                new MenuItem("New Game", GetNewGame, Pause),
                new MenuItem("Exit", ExitGame),
            };

            _mainMenu = new Menu("Title", options);
        }

        private void GetAction()
        {
            int menuOption;
            var options = _mainMenu.Options.Where(o => o.IsEnabled).ToList();

            while (!int.TryParse(Console.ReadLine(), out menuOption) || menuOption > options.Count || menuOption < 1)
            {
                Console.Clear();
                _mainMenu.Display();
                Console.WriteLine("\nPlease select a valid option.");
            }

            Console.Clear();
            options[menuOption - 1].Activate();
        }

        private void GetLoadGames()
        {
            Console.WriteLine("Load");
        }

        private void GetNewGame()
        {
            Console.WriteLine("New");
        }

        private void ExitGame() => _runStatus = false;

        private void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
