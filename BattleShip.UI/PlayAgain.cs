using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class PlayAgain
    {
        public static void RestartGame()
        {
            SetUpWorkFlow playAgain = new SetUpWorkFlow();
            GameState state = playAgain.SetUp();

            GameWorkFlow playGame = new GameWorkFlow();
            playGame.StartGame(state);
        }
    }
}
