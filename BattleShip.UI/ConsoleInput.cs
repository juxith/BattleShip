using BattleShip.BLL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public static class ConsoleInput
    {

        public static string GetPlayer1Name()
        {
            Console.Clear();
            Console.Write("Enter player 1 name: ");
            string name = Console.ReadLine();
            ConsoleInput.ValidStringEntry(name);
            return name;
        }

        public static string GetPlayer2Name()
        {
            Console.Clear();
            Console.Write("Enter player 2 name: ");
            string name = Console.ReadLine();
            ConsoleInput.ValidStringEntry(name);
            return name;
        }

        public static Coordinate GetCoordinate()
        {
            Console.Write("Enter coordiante to place ship. (Exmaple A1 - E10):  ");

            bool invalidInput = true;
            int yNum = 0;
            int xNum = 0;

            while (invalidInput)
            {
                string input = Console.ReadLine();
                string valid = ConsoleInput.ValidStringEntry(input);
                char xString = valid[0];
                string yString = valid.Substring(1);
                int.TryParse(yString, out yNum);
                xNum = (xString - ('a') + 1);

                if ((xNum < 11 && xNum > 0) && (yNum < 11 && yNum > 0))
                {
                    invalidInput = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid entry. Try again.:  ");
                    Console.ResetColor();
                }
            }
            return new Coordinate(xNum, yNum);
        }

        internal static Coordinate GetCoordinateFireShot(GameState state)
        {

            if (state.IsPlayer1Turn)
            {
                Console.Clear();
                Console.WriteLine($"{state.P1.Name} enter coordiante to fire shot:  ");
                ConsoleOutput.ForceDrawOppBoard(state);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{state.P2.Name} enter coordiante to fire shot:  ");
                ConsoleOutput.ForceDrawOppBoard(state);
            }

            bool invalidInput = true;
            int yNum = 0;
            int xNum = 0;

            while (invalidInput)
            {
                string input = Console.ReadLine();
                string valid = ConsoleInput.ValidStringEntry(input);
                char xString = valid[0];
                string yString = valid.Substring(1);
                int.TryParse(yString, out yNum);
                xNum = (xString - ('a') + 1);

                if ((xNum < 11 && xNum > 0) && (yNum < 11 && yNum >0))
                {
                    invalidInput = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid entry. Try again.:  ");
                    Console.ResetColor();
                }
            }
            return new Coordinate(xNum, yNum);
        }

        public static string ValidStringEntry(String input)
        {
            while (input == string.Empty || input.Substring(0) == " " || input.Length < 2)
            {
                Console.Write("Invalid entry. Try again: ");
                input = Console.ReadLine();
            }
            return input.ToLower();
        }

        internal static ShipDirection GetDirection() //for shot locations
        {
            Console.Write("Enter ship placement direction. 0=Up, 1=Down, 2=Left, 3=Right:  ");

            string input = Console.ReadLine();
            ShipDirection ship = new ShipDirection();
            bool invalidInput = true;
            while (invalidInput)
            {
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
            }
            return ship;
        }

        internal static void ExitConsole()
        {
            Console.WriteLine("Press 'ESC' to quit or press any other key to continue.");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
    }

}