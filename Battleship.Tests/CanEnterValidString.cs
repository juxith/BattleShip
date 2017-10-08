using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BattleShip.BLL.GamePlay;
using BattleShip.UI;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;

namespace Battleship.Tests
{
    [TestFixture]
    public class ValidEntries
    {
        [Test]
        public void CanEnterValidEntry()
        {
            string test = "A1";
            string newTest = ConsoleInput.ValidStringEntry(test);

            Assert.AreEqual("a1", newTest);
        }

        [Test]
        public void CanConvertStringToCoordinate()
        {
            string testString = "a10";
            Coordinate actual = new Coordinate(1, 10);
            Coordinate test = TestGetCoordinate(testString);

            Coordinate TestGetCoordinate(String testCase)
            {
                int yNum = 0;
                int xNum = 0;
                string validString = ConsoleInput.ValidStringEntry(testCase);
                char yString = validString[0];
                string xString = validString.Substring(1);
                int.TryParse(xString, out xNum);
                yNum = (yString - ('a') + 1);

                return new Coordinate(yNum, xNum);
            }
            Assert.AreEqual(actual, test);
        }

        [TestCase("0", ShipDirection.Up)]
        [TestCase("1", ShipDirection.Down)]
        [TestCase("2", ShipDirection.Left)]
        [TestCase("3", ShipDirection.Right)]
        public void CanGetDirection(string input, ShipDirection Expected)
        {
            ShipDirection ship = new ShipDirection();
            PlaceShipRequest request = new PlaceShipRequest();
            request.Direction
            switch (input)
                {
                    case "0":
                        ship = ShipDirection.Up;
                        invalidInput = false;
                        break;
                    case "1":
                        ship = ShipDirection.Down;
                        invalidInput = false;
                        break;
                    case "2":
                        ship = ShipDirection.Left;
                        invalidInput = false;
                        break;
                    case "3":
                        ship = ShipDirection.Right;
                        invalidInput = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Invalid entry. Try again:  ");
                        Console.ResetColor();
                        input = Console.ReadLine();
                        break;
                }
             
            
            Assert.AreEqual(expected, actual);
      
        }

    }
}
