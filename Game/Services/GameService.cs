using Game.Data;
using Game.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Services
{
    public class GameService
    {
        private readonly Player _player;

        public GameService(Player player)
        {
            _player = player;
        }

        public void Play()
        {
            while (_player.CurrentZone != PlayableZone.Exit)
            {
                LoadZone();
            }
        }

        private void LoadZone()
        {
            switch (_player.CurrentZone)
            {
                case PlayableZone.Village:

                    break;
                case PlayableZone.City:
                    break;
                case PlayableZone.Danger:
                    break;
                default:
                    _player.CurrentZone = PlayableZone.Exit;
                    break;
            }
        }
    }
}
