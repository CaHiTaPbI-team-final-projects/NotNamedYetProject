using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
