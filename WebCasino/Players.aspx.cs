using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using ENTITIES;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WebCasino
{
    public partial class Players : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string request = await GetHttpPlayer();
                    List<ENTITIES.Player> lst = JsonConvert.DeserializeObject<List<ENTITIES.Player>>(request);
                    GridViewPlayers.DataSource = lst;

                    if (lst.Count <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "alert('No player records.');", true);
                    }
                    else
                    {
                        GridViewPlayers.DataSource = lst;
                        GridViewPlayers.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                BUSINESS.Player.CatchExceptions(ex);
                ScriptManager.RegisterClientScriptBlock(this.ButtonAddPlayer, GetType(), "Warning", "window.alert('Error showing the players.');", true);
            }
        }

        protected void ButtonAddPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                Player player = new Player();
                player.Name = TextBoxAddPlayerName.Text.Trim();
                player.LastName = TextBoxAddPlayerLastName.Text.Trim();
                player.UserName = TextBoxUserName.Text.Trim();
                player.Password = TextBoxPassword.Text.Trim();
                player.MoneyAccount = Convert.ToDecimal(TextBoxAddMoneyAccount.Text.Trim());
                if (player.Name.Length != 0 || player.Name.Length != 0 || player.UserName.Length != 0)
                {
                    BUSINESS.Player.AddPlayer(player.Name, player.LastName, player.UserName, player.Password, player.MoneyAccount);
                    DataTable dt = new DataTable();
                    dt = BUSINESS.Player.GetPlayer();
                    GridViewPlayers.DataSource = dt;
                    GridViewPlayers.DataBind();

                    ScriptManager.RegisterClientScriptBlock(this.ButtonAddPlayer, GetType(), "Warning", "window.alert('Has been saved a new player.');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.ButtonAddPlayer, GetType(), "Warning", "window.alert('One or more values are empty.');", true);

                }
            }
            catch (Exception ex)
            {
                BUSINESS.Player.CatchExceptions(ex);
                ScriptManager.RegisterClientScriptBlock(this.ButtonAddPlayer, GetType(), "Warning", "window.alert('Error adding the new player.');", true);
            }
        }


        protected void ButtonUpdatePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                Player player = new Player();
                player.IdPlayer = Convert.ToInt32(Session["SelectedId"]);
                player.Name = TextBoxUpdatePlayer.Text.Trim();
                player.LastName = TextBoxUpdateLastName.Text.Trim();
                player.MoneyAccount = Convert.ToDecimal(TextBoxUpdateMoneyAccount.Text.Trim());
                if (player.Name.Length != 0 || player.LastName.Length != 0)
                {
                    BUSINESS.Player.UpdatePlayer(player.IdPlayer, player.Name, player.LastName, player.MoneyAccount);
                    DataTable dt = new DataTable();
                    dt = BUSINESS.Player.GetPlayer();
                    GridViewPlayers.DataSource = dt;
                    GridViewPlayers.DataBind();

                    ScriptManager.RegisterClientScriptBlock(this.ButtonUpdatePlayer, GetType(), "Warning", "window.alert('A new player has been saved.');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.ButtonUpdatePlayer, GetType(), "Warning", "window.alert('One or more fields are empty.');", true);

                }
            }
            catch (Exception ex)
            {
                BUSINESS.Player.CatchExceptions(ex);
                ScriptManager.RegisterClientScriptBlock(this.ButtonUpdatePlayer, GetType(), "Warning", "window.alert('Error adding the new player.');", true);
            }
        }

        protected void ButtonDeletePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                int IdPlayer = Convert.ToInt32(Session["SelectedId"]);
                BUSINESS.Player.DeletePlayer(IdPlayer);
                DataTable dt = new DataTable();
                dt = BUSINESS.Player.GetPlayer();
                GridViewPlayers.DataSource = dt;
                GridViewPlayers.DataBind();
                ScriptManager.RegisterClientScriptBlock(this.ButtonUpdatePlayer, GetType(), "Warning", "window.alert('The selected player have been removed.');", true);

            }
            catch (Exception ex)
            {
                BUSINESS.Player.CatchExceptions(ex);
                ScriptManager.RegisterClientScriptBlock(this.ButtonUpdatePlayer, GetType(), "Warning", "window.alert('Error deleting the selected player.');", true);
            }
        }

        protected void GridViewPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se obtiene la fila seleccionada del gridview
            GridViewRow row = GridViewPlayers.SelectedRow;
            //Obtengo el id de la entidad que se esta editando
            Session["SelectedId"] = Convert.ToInt32(row.Cells[1].Text);
            Session["SelectedName"] = row.Cells[2].Text;
            TextBoxUpdatePlayer.Text = Convert.ToString(Session["SelectedName"] = row.Cells[2].Text);
            TextBoxUpdateLastName.Text = Convert.ToString(Session["SelectedLastName"] = row.Cells[3].Text);
            TextBoxUpdateMoneyAccount.Text = Convert.ToString(Session["SelectedMoneyAccount"] = row.Cells[5].Text);
        }


        protected void GridViewPlayers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            GridViewPlayers.PageIndex = e.NewPageIndex;
            dt = BUSINESS.Player.GetPlayer();
            GridViewPlayers.DataSource = dt;
            GridViewPlayers.DataBind();
        }

        protected async void GridViewPlayers_Sorting(object sender, GridViewSortEventArgs e)
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

        private async Task<string> GetHttpPlayer()
        {
            string url = "http://localhost:63482/Get/Players";
            string response = null;
            string json = null;
            HttpClient client = new HttpClient();
            HttpRequestMessage reqst = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage respmsg = await client.SendAsync(reqst);
            response = await respmsg.Content.ReadAsStringAsync();
            json = JToken.Parse(response).ToString();
            return json;
        }
    }
}