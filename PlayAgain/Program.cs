using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            SetUpWorkFlow Welcome = new SetUpWorkFlow();
            GameState state = Welcome.SetUp();

            GameWorkFlow PlayGame = new GameWorkFlow();
            PlayGame.StartGame(state);
        }
    }
}
