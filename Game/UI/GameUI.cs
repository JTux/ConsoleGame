using Game.Data;
using Game.Extensions;
using Game.Models.Entities;
using Game.Models.Items;
using Game.Services;
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
        private readonly SaveService _saveService = new SaveService();

        public void Run()
        {

            while (_runStatus)
            {
                SetMenu();
                PrintMenu();
                GetPlayerAction();
            }
        }

        private void SetMenu()
        {
            var options = new List<MenuItem>
            {
                new MenuItem("Continue Game", _saveService.SaveGameCount > 0, LoadGame, Pause),
                new MenuItem("New Game", StartNewGame, Pause),
                new MenuItem("Exit", ExitGame),
            };

            _mainMenu = new Menu("Title", options);
        }

        private void GetPlayerAction()
        {
            int menuOption;
            var options = _mainMenu.Options.Where(o => o.IsEnabled).ToList();

            while (!int.TryParse(Console.ReadLine(), out menuOption) || menuOption > options.Count || menuOption < 1)
            {
                PrintMenu();
                Console.WriteLine("\nPlease select a valid option.");
            }

            Console.Clear();
            options[menuOption - 1].Activate();
        }

        private void PrintMenu()
        {
            Console.Clear();
            _mainMenu.Display();
        }

        private void LoadGame()
        {
            Console.WriteLine("Load");
        }

        private void StartNewGame()
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
