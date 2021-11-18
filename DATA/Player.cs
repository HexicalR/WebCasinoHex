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
    public class Players
    {
        public static DataTable GetPlayers()

        {
            DataTable dt = new DataTable();

            string cnxSql = ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cnxSql);
            try
            {
                cnx.Open();

                SqlCommand cmd = new SqlCommand("SP_GET_PLAYERS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Tools.WriteLog(ex);
            }
            finally
            {
                cnx.Close();
            }
            return dt;
        }
        public static DataTable GetPlayer()
        {
            DataTable dt = new DataTable();
            string cnxSql = ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cnxSql);
            try
            {
                cnx.Open();

                SqlCommand cmd = new SqlCommand("SP_GET_PLAYERS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Tools.WriteLog(ex);
            }
            finally
            {
                cnx.Close();
            }
            return dt;
        }
        public static DataTable GetPlayersBySorting(string Column, string Order)
        {
            DataTable dt = new DataTable();
            string cnxSql = ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cnxSql);
            try
            {
                cnx.Open();

                SqlCommand cmd = new SqlCommand("SP_GET_PLAYERS_BY_SORTING", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@VColumn", SqlDbType.VarChar).Value = Column;
                cmd.Parameters.Add("@VOrder", SqlDbType.VarChar).Value = Order;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Tools.WriteLog(ex);
            }
            finally
            {
                cnx.Close();
            }
            return dt;
        }
        public static void AddPlayer(string Name, string LastName, string Username, string Password, decimal MoneyAccount)
        {
            DataTable dt = new DataTable();
            string cnxSql = ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cnxSql);
            try
            {
                cnx.Open();

                SqlCommand cmd = new SqlCommand("SP_ADD_PLAYERS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@VName", SqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@VLastName", SqlDbType.VarChar).Value = LastName;
                cmd.Parameters.Add("@VUserName", SqlDbType.VarChar).Value = Username;
                cmd.Parameters.Add("@VPassword", SqlDbType.VarChar).Value = Password;
                cmd.Parameters.Add("@VMoneyAccount", SqlDbType.Decimal).Value = MoneyAccount;

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
        public static void UpdatePlayer(int IdPlayer, string Name, string LastName, decimal MoneyAccount)
        {
            DataTable dt = new DataTable();
            string cnxSql = ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cnxSql);
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_UPDATE_PLAYERS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@VIdPlayer", SqlDbType.VarChar).Value = IdPlayer;
                cmd.Parameters.Add("@VName", SqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@VLastName", SqlDbType.VarChar).Value = LastName;
                cmd.Parameters.Add("@VMoneyAccount", SqlDbType.VarChar).Value = MoneyAccount;
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
        public static void DeletePlayer(int IdPlayer)
        {
            DataTable dt = new DataTable();
            string cnxSql = ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
            SqlConnection cnx = new SqlConnection(cnxSql);
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_DELETE_PLAYERS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@VIdPlayer", SqlDbType.Int).Value = IdPlayer;

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
