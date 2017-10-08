using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GamePlay;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    public static class ConsoleOutput
    {
        public static void SplashScreen()
        {
            Console.WriteLine(@"                                                                                                  
                                                  My                                                
                                            `+++++Md++++:                                           
                                                  My                                                
                                                  My                                                
                                                  My                                                
                                                  My                                                
                                           ossssssMmssssss                                          
                                    om     .......Mh......                                          
                               `::::hM::::.       My                                                
                               `----hM----.       My                                                
                                    yM            My                                                
                                    yM         :NN+hNN                                              
                                    yM         /MM+hMM                                              
                              ://///dM/////////sMM+hMM////////.                                     
                              ://///dMyMMMMMMMMMMM+hMMMMMMMMMMo                                     
                                    yM+MMMMMMMMMdo:+hMMMMMMMMMo                                     
                                    yM+MMMMMMMMy  .` sMMMMMMMMo                                     
                                    yM+MMMMMMMMMh+:/yNMMMMMMMMo                                     
                                  hhNMmMMMMMMMMMMM+hMMMMMMMMMMmhhhhh.                               
                                  MMMMMMMMMMMMMMMM+hMMMMMMMMMMMMMMMM-                               
                                  ....oMMMMMMMMMMM+hMMMMMMMMMMs.....                                
                                      +MMMMMMMMMMM+yMMMMMMMMMMo                                     
                                      +MNmmdhyysss/+ssyhhdmNNMo                                     
                              ://////+++osyhdmNMMM+oMMNmmdhyyss+///////-                            
                              mMMMMMMMMMMMMMMMMMMM+oMMMMMMMMMMMMMMMMMMMy                            
                              mMMMMMMMMMMMMMMMMMMM++MMMMMMMMMMMMMMMMMMMy                            
                              mMMMMMMMMMMMMMMMMMMN++MMMMMMMMMMMMMMMMMMMy                            
          `+++-----.  .+++++++NMMMMMMNmdhyyso+///+/:ssssssssssssssssooooooooooo+`       `---        
          -dddNMMMMNNNNMMMNmdhyso+++++osyhddmNMMMMs:MMMMMMMMMMMMMMMMMMMMMMMMMMMMdhhmmmmmmddd        
               `ssssdhsooosyhddmNMMMMMMMMMMMMMMMMMs:MMMMMMMMMMMMMNNmddhhysssssssssdsss-             
               .MMMMMMMMMMMMMMMMMMMMMMMMMMMMMNmmdh+-hhyysssssssssyyhddmNNMMMMMMMMMMMMM/             
    +mmmhhhhhyosMMMMMMMMMMMMMMMNmddhyssoooooosyyhdo/+yhdmMMMMMMMMMMMMMMMMMMMMMMMMMMMMMo--+ooooohhh- 
        :::::/osNNmdhhysoo++++ossyhddmNMMMMMMMMMMMs/--------+++ossshddmNNMMMMMMMMMMMMMdyyooooo+:::` 
    ````....-:/+oosyhhdmNMMMMMMMMMMMMMMMMMMMMMMMMMs/---------------------:///ossyhhhmmo-...         
.++osyyhdmNNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMs/-----------------------------------://////////:-
.NMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMs/----------------------------------------------s.
 sMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMs/---------------------------------------------++ 
 -NMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMs/---------------------------------------------s` 
  yMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMs/--------------------------------------------o-  
  `NMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMs/--------------------------------------------s   
   sMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMs/-------------------------------------------s`   
    ddddddddddddddddddddddddddddddddddddddddddddddo/+++++++++++++++++++++++++++++++++++++++++++/    
");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        public static void Intro()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Game Set Up:  Never share battle strategy with your enemy. Don't share screen with opponent in set up.\nPress any key to begin.");
            Console.ReadLine();
            //add splash screen here. 
        }
        public static void WhoStartsFirst(GameState state)
        {
            if (state.IsPlayer1Turn)
            {
                Console.Clear();
                Console.WriteLine($" On a coin flip, {state.P1.Name} gets to fire first.\nPress any key to begin!");
                Console.ReadLine();

            }
            else
            {
                Console.Clear();
                Console.Write($" On a coin flip, {state.P2.Name} gets to fire first.\nPress any key to begin!");
                Console.ReadLine();
            }
        }

        internal static void ShotInvalid()
        {
            Console.WriteLine("Invalid shot, Try again.");
        }

        internal static void ShotDuplicate()
        {
            Console.WriteLine("You've already shot there.");
        }

        internal static void ForceDrawOppBoard(GameState boardState)
        {
            Board previousOppShotBoard = boardState.IsPlayer1Turn ? boardState.P2.PlayerBoard : boardState.P1.PlayerBoard;

            Console.WriteLine("    1   2   3   4   5   6   7   8   9   10");
            Console.WriteLine("__________________________________________");

            string letters = "ABCDEFGHIJ";
            Console.Write("A |");
            int i = 1;

            for (int y = 1; y < 11; y++)
            {
                for (int x = 1; x < 11; x++)
                {
                    ShotHistory currentState = previousOppShotBoard.CheckCoordinate(new Coordinate(y, x));
                    switch (currentState)
                    {
                        case ShotHistory.Unknown:

                            Console.Write(" ");
                            break;
                        case ShotHistory.Hit:

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("H");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Miss:

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("M");
                            Console.ResetColor();
                            break;
                    }
                    Console.Write("  |");
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------");
                if (i < letters.Length)
                {
                    Console.Write(letters[i++] + " |");
                }
            }
        }

        internal static void DrawBoard(GameState boardState)
        {
            Board drawBoard = boardState.IsPlayer1Turn ? boardState.P1.PlayerBoard : boardState.P2.PlayerBoard;

            Console.WriteLine("    1   2   3   4   5   6   7   8   9   10");
            Console.WriteLine("__________________________________________");

            string letters = "ABCDEFGHIJ";
            Console.Write("A |");
            int i = 1;

            for (int y = 1; y < 11; y++)
            {
                for (int x = 1; x < 11; x++)
                {
                    ShotHistory currentState = drawBoard.CheckCoordinate(new Coordinate(y, x));
                    switch (currentState)
                    {
                        case ShotHistory.Unknown:

                            Console.Write(" ");
                            break;
                        case ShotHistory.Hit:

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("H");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Miss:

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("M");
                            Console.ResetColor();
                            break;
                    }
                    Console.Write("  |");
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------");
                if (i < letters.Length)
                {
                    Console.Write(letters[i++] + " |");
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        internal static void ShotMiss()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You missed.");
            Console.ResetColor();
        }

        internal static void ShotHit()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A ship was hit. Nice shot!");
            Console.ResetColor();
        }

        internal static void ShotHitAndSunk(FireShotResponse response, GameState state)
        {
           
            if (state.IsPlayer1Turn)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Glorious {state.P1.Name} ! You hit and sunk the {response.ShipImpacted}");
                Console.ResetColor();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Glorious {state.P2.Name}! You hit and sunk the {response.ShipImpacted}");
                Console.ResetColor();
            }
        }

        internal static void ShotVictory(GameState state)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (state.IsPlayer1Turn)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{state.P1.Name} you are Victorious and have won the battle!!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{state.P2.Name} you are Victorious and have won the battle!!");

            }
            Console.ResetColor();

            ConsoleInput.ExitConsole();
            Console.WriteLine("Press any other key to play again");
            Console.ReadLine();

            PlayAgain.RestartGame();
        }

        internal static void ShipOverLap()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your ship is overlapping");
            Console.ResetColor();

        }

        internal static void NotEnoughSpace()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Not enough space");
            Console.ResetColor();

        }
    }
}
