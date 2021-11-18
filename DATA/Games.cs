using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace DATA
{
    public class Games
    {
        public static void SaveResult(int IdGame, int IdPlayer, decimal money, int situation)
        {
            DataTable dt = new DataTable();
            string cnxSql = ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cnxSql);
            try
            {
                cnx.Open();

                SqlCommand cmd = new SqlCommand("SP_SAVE_RESULTS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@VIdGame", SqlDbType.Int).Value = IdGame;
                cmd.Parameters.Add("@VIdPlayer", SqlDbType.Int).Value = IdPlayer;
                cmd.Parameters.Add("@VMoneyBet", SqlDbType.Decimal).Value = money;
                cmd.Parameters.Add("@VSituation", SqlDbType.Int).Value = situation;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Tools.WriteLog(ex);
            }
            finally
            {
                cnx.Close();
            }
        }
        public static void CatchException(Exception ex)
        {
            Tools.WriteLog(ex);
        }
    }
}
