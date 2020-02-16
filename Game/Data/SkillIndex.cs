using Game.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Data
{
    public static class SkillIndex
    {
        private static readonly Dictionary<int, Skill> _skillIndex = new Dictionary<int, Skill>();

        static SkillIndex() => PopulateIndex();

        public static Skill GetSkillbyId(int skillId)
        {
            try
            {
                return _skillIndex[skillId];
            }
            catch
            {
                return null;
            }
        }

        private static void PopulateIndex()
        {
        }
    }
}
