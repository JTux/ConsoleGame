using Game.Data;
using Game.Extensions;
using Game.Models;
using Game.Models.Entities;
using Game.Services;
using Game.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Game.UI
{
    public class CharacterCreationUI : BaseUI<Player>
    {
        enum CreationStage
        {
            NameSelection, CombatStyleSelection, ConfirmationSelection, Completed,
            Exit
        }

        private readonly SaveService _saveService;
        private Player _player;
        CreationStage _stage = CreationStage.NameSelection;

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

        private void StartNewGame() => _player = CreateNewPlayer();

        private Player CreateNewPlayer()
        {
            string playerName = "";
            CombatStyle combatStyle = CombatStyle.Melee;

            while (_stage != CreationStage.Completed)
            {
                switch (_stage)
                {
                    case CreationStage.NameSelection:
                        playerName = GetCharacterName(null);
                        break;
                    case CreationStage.CombatStyleSelection:
                        combatStyle = GetCombatStyle(playerName);
                        break;
                    case CreationStage.ConfirmationSelection:
                        ConfirmCharacter(playerName, combatStyle);
                        break;
                    case CreationStage.Exit:
                        return null;
                }
            }

            return new Player(_saveService.SaveGameCount + 1, playerName, combatStyle) { CurrentZone = PlayableZone.Village };
        }

        private string GetCharacterName(string warningMessage)
        {
            Console.Clear();
            var newGameMenu = new Menu(
                header: "newGame",
                subtitle: new Subtitle(
                    $"Welcome traveler! What is your name?" +
                    $"\nTo exit character creation simply type \"exit\"." +
                    (!string.IsNullOrEmpty(warningMessage) ? $"{"\n" + warningMessage}" : "")));
            newGameMenu.DisplayTitles();

            _stage++;

            var playerName = Console.ReadLine();
            if (playerName.ToLower() == "exit")
                _stage = CreationStage.Exit;
            else if (!CheckForValidName(playerName))
                _stage = CreationStage.NameSelection;

            return (_stage == CreationStage.NameSelection) ? GetCharacterName("Please enter a valid name.") : playerName;
        }

        private bool CheckForValidName(string name)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ._-]*$");
            return regexItem.IsMatch(name) && !string.IsNullOrEmpty(name);
        }

        private CombatStyle GetCombatStyle(string playerName)
        {
            CombatStyle playerCombatStyle = CombatStyle.Magic;
            _stage++;

            var combatSelectOptions = new List<MenuItem>
            {
                new MenuItem("Melee", () => playerCombatStyle = CombatStyle.Melee),
                new MenuItem("Ranged", () => playerCombatStyle = CombatStyle.Ranged),
                new MenuItem("Magic", () => playerCombatStyle = CombatStyle.Magic),
                new MenuItem("Change Name", ()=> _stage = CreationStage.NameSelection)
            };

            var combatSelectMenu = new Menu("newGame", new Subtitle($"It's a pleasure to meet you, {playerName}.\nPlease select a starting combat style. Don't worry, you can change this later."), combatSelectOptions);
            combatSelectMenu.GetPlayerAction();

            return playerCombatStyle;
        }

        private void ConfirmCharacter(string name, CombatStyle combatStyle)
        {
            var confirmationOptions = new List<MenuItem>
            {
                new MenuItem($"I am ready to play as {name} starting with {combatStyle}.", () => _stage++),
                new MenuItem("Wait! Go back, I need to change something.", () => _stage--)
            };

            var confirmationMenu = new Menu("newGame", new Subtitle("Are you ready?"), confirmationOptions);
            confirmationMenu.GetPlayerAction();
        }

        private void ExitGame() { }
    }
}
