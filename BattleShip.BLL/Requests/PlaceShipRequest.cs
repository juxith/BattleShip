using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Ships;

namespace BattleShip.BLL.Requests
{
    public class PlaceShipRequest
    {
        public Coordinate Coordinate { get; set; } //userinput
        public ShipDirection Direction { get; set; } //user input
        public ShipType ShipType { get; set; } //loop
    }
}
