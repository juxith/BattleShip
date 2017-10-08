using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameWorkFlow
    {
        public object FireshotResponse { get; private set; }

        internal void StartGame(GameState state)
        {
            ConsoleOutput.WhoStartsFirst(state);
            ShotStatus shotFired = ShotStatus.Invalid;

            while (shotFired != ShotStatus.Victory)
            {
                Coordinate shotLoc = ConsoleInput.GetCoordinateFireShot(state);
                Board toShootAt = state.IsPlayer1Turn ? state.P2.PlayerBoard : state.P1.PlayerBoard;

                FireShotResponse response = toShootAt.FireShot(shotLoc);

                switch (response.ShotStatus)
                {
                    case ShotStatus.Victory:
                        shotFired = ShotStatus.Victory;
                        break;
                    case ShotStatus.Invalid:
                        ConsoleOutput.ShotInvalid();
                        break;
                    case ShotStatus.Duplicate:
                        ConsoleOutput.ShotDuplicate();
                        break;
                    case ShotStatus.HitAndSunk:
                        ConsoleOutput.ShotHitAndSunk(response,state);
                        state.IsPlayer1Turn = !state.IsPlayer1Turn;
                        break;
                    case ShotStatus.Hit:
                        ConsoleOutput.ShotHit();
                        state.IsPlayer1Turn = !state.IsPlayer1Turn;
                        break;
                    case ShotStatus.Miss:
                        ConsoleOutput.ShotMiss();
                        state.IsPlayer1Turn = !state.IsPlayer1Turn;
                        break;
                    default:
                        break;
                }
                ConsoleOutput.DrawBoard(state);
            }
            ConsoleOutput.ShotVictory(state);
        }

    }
}
