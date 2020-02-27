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
    public class GameUI : BaseUI
    {
        private bool _runStatus = true;
        private readonly SaveService _saveService = new SaveService();

        public void Run()
        {
            while (_runStatus)
            {
                SetMenu();
                _menu.GetPlayerAction();
                Console.Clear();
            }
        }

        protected override void SetMenu()
        {
            var options = new List<MenuItem>
            {
                new MenuItem("Continue Game", _saveService.SaveGameCount > 0, LoadGame),
                new MenuItem("New Game", StartNewGame),
                new MenuItem("Settings", RunSettings),
                new MenuItem("Exit", ExitGame),
            };

            _menu = new Menu("title", options);
        }

        private void LoadGame()
        {
            Console.WriteLine("Load");
        }

        private void StartNewGame()
        {
            var player = new CharacterCreationUI(_saveService).Run();

            if (player != null)
            {
                _saveService.SaveGame(player);
            }
        }

        private void RunSettings() => new SettingsUI(_saveService, false).Run();
        private void ExitGame() => _runStatus = false;
    }
}
