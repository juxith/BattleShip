using BattleShip.BLL.GamePlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class GameState
    {
        public Player P1 { get; }
        public Player P2 { get; }
        public bool IsPlayer1Turn { get; set; }

        public GameState( Player p1, Player p2, bool isPlayer1Turn)
        {
            P1 = p1;
            P2 = p2;
            IsPlayer1Turn = isPlayer1Turn;
        }
    }
}
