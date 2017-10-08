using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.GamePlay;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class SetUpWorkFlow
    {
        internal GameState SetUp()
        {
            ConsoleOutput.SplashScreen();
            ConsoleOutput.Intro();

            Player P1 = new Player(ConsoleInput.GetPlayer1Name(), BuildBoard());
            Console.Clear();
            Player P2 = new Player(ConsoleInput.GetPlayer2Name(), BuildBoard());

            bool IsPlayer1Turn = DecideWhoeGoesFirst();

            return new GameState(P1, P2, IsPlayer1Turn);
        }

        private static bool DecideWhoeGoesFirst()
        {
            return RNG.CoinFlip();
        }

        private static Board BuildBoard()
        {
            Board gameBoard = new Board();
        
            for (ShipType s = ShipType.Carrier; s >= ShipType.Destroyer; s--)
            {
                Console.WriteLine($"Where you would like to place the {s}.");
                
                PlaceShipRequest request = new PlaceShipRequest();
                bool isValidPlacement = true;
                while (isValidPlacement)
                {
                request.Coordinate = ConsoleInput.GetCoordinate();
                request.Direction = ConsoleInput.GetDirection();
                request.ShipType = s;
                var placeResult = gameBoard.PlaceShip(request);
                    if (placeResult == ShipPlacement.NotEnoughSpace)
                    {
                        ConsoleOutput.NotEnoughSpace();
                       
                    }
                    else if (placeResult == ShipPlacement.Overlap)
                    {
                        ConsoleOutput.ShipOverLap();
                        
                    }
                    else
                    {
                        isValidPlacement = false;
                    }
                }
            }
            return gameBoard;

        }
    }
}
