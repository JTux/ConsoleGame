using Game.Models.Entities;
using Game.Models.Items.Potions;
using Game.Services;
using Game.UI;
using Game.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameUI();
            game.Run();
        }
    }
}
