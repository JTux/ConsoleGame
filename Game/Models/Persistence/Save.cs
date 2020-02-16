using Game.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Persistence
{
    public class Save
    {
        public int Id { get; private set; }
        public Entity Character { get; set; }
        public string Location { get; set; }
    }
}
