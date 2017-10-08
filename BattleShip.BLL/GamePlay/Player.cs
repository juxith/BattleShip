using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;

namespace BattleShip.BLL.GamePlay
{
    public class Player
    {
        public string Name { get; }
        public Board PlayerBoard { get; set; }
        public bool IsPlayer1Turn { get; set; }

        public Player (string name, Board playerBoard)
        {
            Name = name;
            PlayerBoard = playerBoard;
        }
    }
}
