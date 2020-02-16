using Game.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Data
{
    public static class EntityIndex
    {
        private static readonly Dictionary<int, Entity> _entityIndex = new Dictionary<int, Entity>();

        static EntityIndex() => PopulateIndex();

        public static Entity GetEntityById(int entityId)
        {
            try
            {
                return _entityIndex[entityId];
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
