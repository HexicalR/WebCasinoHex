using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES
{
    public class Player
    {
        public int IdPlayer { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal MoneyAccount { get; set; }
        public string DateCreation { get; set; }
        public string LastDateModification { get; set; }

    }
}
