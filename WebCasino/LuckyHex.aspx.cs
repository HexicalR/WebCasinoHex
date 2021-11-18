using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITIES;

namespace WebCasino
{
    public partial class LuckyHex : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    DataTable dt = new DataTable();
                    dt = BUSINESS.Player.GetPlayer();
                    if (dt.Rows.Count <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "alert('No player records.');", true);
                    }
                    else
                    {
                        GridViewPlayers.DataSource = dt;
                        GridViewPlayers.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                BUSINESS.Player.CatchExceptions(ex);
                ScriptManager.RegisterClientScriptBlock(this.ButtonTryLuck, GetType(), "Warning", "window.alert('Error showing the players.');", true);
            }
        }

        protected void GridViewPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewPlayers.SelectedRow;
            Session["SelectedId"] = Convert.ToInt32(row.Cells[1].Text);
            Session["SelectedMount"] = row.Cells[5].Text;

            TextBoxIdPlayer.Text = Session["SelectedId"].ToString();
            TextBoxTryLuck.Text = Session["SelectedMount"].ToString();
        }


        protected void GridViewPlayers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            GridViewPlayers.PageIndex = e.NewPageIndex;
            dt = BUSINESS.Player.GetPlayer();
            GridViewPlayers.DataSource = dt;
            GridViewPlayers.DataBind();
        }

        protected void GridViewPlayers_Sorting(object sender, GridViewSortEventArgs e)
        {
            string Column = e.SortExpression;
            SortDirection name;
            if (ViewState["Data"] == null)
            {
                name = SortDirection.Ascending;
                ViewState["Data"] = SortDirection.Descending;
            }
            else
            {
                name = (SortDirection)ViewState["Data"];
                if (name == SortDirection.Ascending)
                    ViewState["Data"] = SortDirection.Descending;
                else
                    ViewState["Data"] = SortDirection.Ascending;
            }
            string Order = "";
            if (name == SortDirection.Ascending)
                Order = "ASC";
            else
                Order = "DESC";

            DataTable dt = new DataTable();
            dt = BUSINESS.Player.GetPlayerBySorting(Column, Order);
            GridViewPlayers.DataSource = dt;
            GridViewPlayers.DataBind();

        }

        protected void ButtonTryLuck_Click(object sender, EventArgs e)
        {

            if (Convert.ToDecimal(Session["SelectedMount"]) <= 0 && Convert.ToDecimal(Session["SelectedMount"]) <= Convert.ToDecimal(TextBoxTryLuck.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "alert('You don't have enough money to bed, please recharge your card');", true);
            }
            else
            {
                Player player = new Player();
                Game game = new Game();
                player.IdPlayer = Convert.ToInt32(TextBoxIdPlayer.Text);
                game.IdGame = 1;

                int LuckTime = Convert.ToInt32(DateTime.Now.Year) + Convert.ToInt32(DateTime.Now.Month) + Convert.ToInt32(DateTime.Now.Day) + Convert.ToInt32(DateTime.Now.Hour) +
                Convert.ToInt32(DateTime.Now.Minute) + Convert.ToInt32(DateTime.Now.Second) + Convert.ToInt32(DateTime.Now.Millisecond);

                if (LuckTime % 2 == 0)
                {
                    decimal moneyearn = Convert.ToDecimal(TextBoxTryLuck.Text.Trim()) * 2;
                    BUSINESS.Game.SaveResults(game.IdGame, player.IdPlayer, moneyearn, 1); //the id game is the 1, user id, amount, win is 1
                    LabelMessage.Text = "YOU WON $ " + TextBoxTryLuck.Text.Trim();
                }
                else
                {
                    decimal moneylost = Convert.ToDecimal(TextBoxTryLuck.Text.Trim());
                    BUSINESS.Game.SaveResults(game.IdGame, player.IdPlayer, moneylost, 0);
                    LabelMessage.Text = "YOU LOST $ " + TextBoxTryLuck.Text.Trim();
                }
                DataTable dt = new DataTable();
                dt = BUSINESS.Player.GetPlayer();
                GridViewPlayers.DataSource = dt;
                GridViewPlayers.DataBind();
            }
        }
    }
}