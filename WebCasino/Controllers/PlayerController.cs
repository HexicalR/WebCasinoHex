using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebCasino.Controllers
{
    public class PlayerController : ApiController
    {
        [HttpGet]
        [Route("Get/Players")]
        public HttpResponseMessage GetPlayers()
        {
            try
            {
                List<ENTITIES.Player> players = new List<ENTITIES.Player>();
                DataTable dt = new DataTable();
                dt = BUSINESS.Player.GetPlayer();
                foreach (DataRow pl in dt.Rows)
                {
                    ENTITIES.Player p = new ENTITIES.Player();
                    p.IdPlayer = Convert.ToInt32(pl[0].ToString());
                    p.Name = pl[1].ToString();
                    p.LastName = pl[2].ToString();
                    p.UserName = pl[3].ToString();
                    p.MoneyAccount = Convert.ToDecimal(pl[4].ToString());
                    p.DateCreation = pl[5].ToString();
                    p.LastDateModification =pl[6].ToString();
                    players.Add(p);
                }
                return Request.CreateResponse(HttpStatusCode.OK, players);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No data found");
            }

        }
    }
}
