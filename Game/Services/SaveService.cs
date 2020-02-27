using Game.Data;
using Game.Extensions;
using Game.Models;
using Game.Models.Entities;
using Game.Models.Items;
using Game.Models.Skills;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Game.Services
{
    public class SaveService
    {
        public int SaveGameCount { get; private set; }

        public SaveService()
        {
            ValidateDirectories();
            if (File.Exists("./Files/Settings.txt"))
            {
                var settingTxt = File.ReadAllText($"./Files/Settings.txt");
                var settings = settingTxt.Replace("\n", "").Replace("\"", "").Split(';').ToList();
                var gameCount = settings.FirstOrDefault(s => s.Contains("GameCount"));
                if (gameCount != null)
                {
                    SaveGameCount = int.Parse(gameCount.Split(new string[] { "GameCount:", ";" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                }
            }
        }

        public void UpdateSettings()
        {
            StreamWriter settings = new StreamWriter($"./Files/Settings.txt");
            settings.Write($"\"GameCount\": {SaveGameCount};");
            settings.Close();
        }

        public Player LoadGameById(int id)
        {
            var saveGame = File.ReadAllText($"./Files/Saves/Player{id}.txt");
            var saveSplit = saveGame.Replace("\n", "").Replace("\"", "").Split(';');

            var saveKeyValues = new Dictionary<string, string>();
            foreach (var row in saveSplit)
            {
                var kv = row.Split(':');
                saveKeyValues.Add(kv[0], kv[1]);
            }

            return GetPlayerFromSave(saveKeyValues);
        }

        public void SaveGame(Player player)
        {
            ValidateDirectories();
            StreamWriter characterFile = new StreamWriter($"./Files/Saves/Player{player.Id}.txt");
            characterFile.Write(GetSaveString(player));
            characterFile.Close();

            SaveGameCount = Directory.GetFiles("./Files/Saves", "*.txt").Length;
            UpdateSettings();
        }

        // Get Saves

        public void Reset()
        {
            ValidateDirectories();
            for (int i = 1; i <= SaveGameCount; i++)
            {
                if (File.Exists($"./Files/Saves/Player{i}.txt"))
                {
                    File.Delete($"./Files/Saves/Player{i}.txt");
                }
            }
            SaveGameCount = 0;
            UpdateSettings();
        }

        private void ValidateDirectories()
        {
            if (!Directory.Exists($"./Files"))
                Directory.CreateDirectory($"./Files");
            if (!Directory.Exists($"./Files/Saves"))
                Directory.CreateDirectory($"./Files/Saves");

            if (!File.Exists("./Files/Settings.txt"))
            {
                StreamWriter settings = new StreamWriter($"./Files/Settings.txt");
                settings.Close();
            }
        }

        private string GetSaveString(Player player)
        {
            string items = "", skills = "";
            for (int i = 0; i < player.Inventory.Count; i++)
                items += $"{player.Inventory[i].ToString()}{(i < player.Inventory.Count - 1 ? "," : "")}";

            for (int i = 0; i < player.Skills.Count; i++)
                skills += $"{player.Skills[i].ToString()}{(i < player.Skills.Count - 1 ? "," : "")}";

            return (
                "\"Id\":1;" +
                $"\n\"Name\":{player.Name};" +
                $"\n\"Level\":{player.Level};" +
                $"\n\"XP\":{player.XP};" +
                $"\n\"BaseHealth\":{player.BaseHealth};" +
                $"\n\"CombatStyle\":{player.CombatStyle};" +
                $"\n\"Health\":{player.Health};" +
                $"\n\"IsAlive\":{player.IsAlive};" +
                $"\n\"Gold\":{player.Gold};" +
                $"\n\"Inventory\":{items};" +
                $"\n\"Skills\":{skills}");
        }

        private Player GetPlayerFromSave(Dictionary<string, string> saveValues)
        {
            var id = int.Parse(saveValues.GetValue("Id"));
            var name = saveValues.GetValue("Name");
            var level = int.Parse(saveValues.GetValue("Level"));
            var xp = int.Parse(saveValues.GetValue("XP"));
            var baseHealth = int.Parse(saveValues.GetValue("BaseHealth"));
            var combatStyle = (CombatStyle)Enum.Parse(typeof(CombatStyle), saveValues.GetValue("CombatStyle"));
            var health = int.Parse(saveValues.GetValue("Health"));
            var gold = int.Parse(saveValues.GetValue("Gold"));

            var inventoryStr = saveValues.GetValue("Inventory");
            var itemIds = inventoryStr.Split(',').Where(s => s != "");
            var inventory = new List<Item>();
            foreach (var itemId in itemIds)
                inventory.Add(ItemIndex.GetItemById(int.Parse(itemId)));

            var skillsStr = saveValues.GetValue("Skills");
            var skillIds = skillsStr.Split(',').Where(s => s != "");
            var skills = new List<Skill>();
            foreach (var skillId in skillIds)
                skills.Add(SkillIndex.GetSkillbyId(int.Parse(skillId)));

            return new Player(id, name, level, xp, baseHealth, health, 2, inventory, skills) { CombatStyle = combatStyle };
        }
    }
}
