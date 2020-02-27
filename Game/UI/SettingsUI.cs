using Game.Extensions;
using Game.Services;
using Game.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UI
{
    public class SettingsUI : BaseUI
    {
        private SaveService _saveService;
        private bool _running = true;
        private bool _gameIsPlaying;

        public SettingsUI(SaveService saveService, bool gameIsPlaying)
        {
            _saveService = saveService;
            _gameIsPlaying = gameIsPlaying;
        }

        public void Run()
        {
            while (_running)
            {
                SetMenu();
                _menu.GetPlayerAction();
            }
        }

        protected override void SetMenu()
        {
            var options = new List<MenuItem>
            {
                new MenuItem("Reset Saves", (!_gameIsPlaying && _saveService.SaveGameCount > 0), ResetSaveFiles),
                new MenuItem("Exit Settings", Exit)
            };

            _menu = new Menu("settings", options);
        }

        private void ResetSaveFiles()
        {
            bool runReset = true;
            void Leave() => runReset = false;

            var resetOptions = new List<MenuItem>
            {
                new MenuItem("Confirm reset", _saveService.Reset, Leave),
                new MenuItem("Return to Settings", Leave)
            };

            var resetMenu = new Menu(
                header: "danger",
                subtitle: new Subtitle("Are you sure you want to reset your saves? This option cannot be undone."),
                options: resetOptions);

            while (runReset)
            {
                resetMenu.GetPlayerAction(subtitleColor: ConsoleColor.Red);
            }
        }

        private void Exit() => _running = false;
    }
}
