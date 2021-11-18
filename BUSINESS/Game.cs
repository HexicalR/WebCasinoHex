using System;
using System.Data;
using System.Configuration;

namespace BUSINESS
{
    public class Game
    {
        public static void SaveResults(int IdGame, int IdPlayer, decimal money, int situation)
        {
            DATA.Games.SaveResult(IdGame, IdPlayer, money, situation);
        }
    }
}
