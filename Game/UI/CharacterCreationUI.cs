using Game.Extensions;
using Game.Models;
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
            _menu.GetPlayerAction();
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
            _player = CreateNewPlayer();
        }

        private Player CreateNewPlayer()
        {
            Console.Clear();
            var newGameMenu = new Menu("newGame", new Subtitle("Welcome traveler! What is your name?"));
            newGameMenu.DisplayTitles();

            var playerName = Console.ReadLine();

            var combatStyle = GetCombatStyle(playerName);

            return new Player(_saveService.SaveGameCount + 1, playerName, combatStyle);
        }

        private CombatStyle GetCombatStyle(string playerName)
        {
            CombatStyle playerCombatStyle = CombatStyle.Mage;

            void SelectMelee() => playerCombatStyle = CombatStyle.Melee;
            void SelectRanged() => playerCombatStyle = CombatStyle.Ranged;
            void SelectMage() => playerCombatStyle = CombatStyle.Mage;

            var combatSelectOptions = new List<MenuItem>
            {
                new MenuItem("Melee", SelectMelee),
                new MenuItem("Ranged", SelectRanged),
                new MenuItem("Mage", SelectMage)
            };

            var combatSelectMenu = new Menu("newGame", new Subtitle($"It's a pleasure to meet you, {playerName}.\nPlease select a starting combat style. Don't worry, you can change this later."), combatSelectOptions);
            combatSelectMenu.GetPlayerAction();

            return playerCombatStyle;
        }

        private void ExitGame() { }
    }
}
