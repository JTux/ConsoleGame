using Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Persistence
{
    public class SaveGame
    {
        public SaveGame(int saveNumber, string name, int level, CombatStyle combatStyle, PlayableZone currentZone)
        {
            SaveNumber = saveNumber;
            Name = name;
            Level = level;
            CombatStyle = combatStyle;
            Zone = currentZone;
        }

        public int SaveNumber { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public CombatStyle CombatStyle { get; set; }
        public PlayableZone Zone { get; set; }
    }
}
