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
            Player player = null;
            bool loadGame = false;

            var saves = _saveService.GetSaveGames();
            if (saves.Count > 0)
            {
                void SelectSave(int saveNumber)
                {
                    loadGame = true;
                    player = _saveService.LoadGameById(saveNumber);
                }

                var saveItems = new List<MenuItem>();
                for (int i = 0; i < saves.Count; i++)
                {
                    var save = saves[i];
                    var menuItem = new MenuItem(
                        text: $"{save.Name}, a level {save.Level} focusing on {save.CombatStyle}.", 
                        menuActions: () => SelectSave(save.SaveNumber));
                    saveItems.Add(menuItem);
                }
                saveItems.Add(new MenuItem("Return to menu.", () => { }));

                var loadMenu = new Menu("loadGame", new Subtitle("Select a save file."), saveItems);
                loadMenu.GetPlayerAction();
            }

            if (loadGame)
                InitializeGame(player);
        }

        private void StartNewGame()
        {
            var player = new CharacterCreationUI(_saveService).Run();

            if (player != null)
            {
                _saveService.SaveGame(player);
                InitializeGame(player);
            }
        }

        private void InitializeGame(Player player)
        {
            Console.WriteLine(player.Name);
            Console.ReadLine();
        }

        private void RunSettings() => new SettingsUI(_saveService, false).Run();
        private void ExitGame() => _runStatus = false;
    }
}
