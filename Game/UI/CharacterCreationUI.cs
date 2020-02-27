using Game.Extensions;
using Game.Models.Entities;
using Game.Services;
using Game.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UI
{
    public class CharacterCreationUI : BaseUI<Player>
    {
        private readonly SaveService _saveService;
        private Player _player;

        public CharacterCreationUI(SaveService saveService) => _saveService = saveService;

        public override Player Run()
        {
            SetMenu();
            var actionId = _menu.GetSelectedAction();
            _menu.Options[actionId].Action.Invoke();
            return _player;
        }

        protected override void SetMenu()
        {
            var options = new List<MenuItem>
            {
                new MenuItem("Create New Character", StartNewGame),
                new MenuItem("Return To Main Menu", ExitGame),
            };

            _menu = new Menu("newGame", options);
        }

        private void StartNewGame()
        {
            _player = new Player(_saveService.SaveGameCount + 1, "Phil");
        }

        private void ExitGame() { }
    }
}
