using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public static class RNG
    {
        static Random _random = new Random();

        public static bool CoinFlip()
        {
            return _random.NextDouble() < 0.5;
        }

    }
}
