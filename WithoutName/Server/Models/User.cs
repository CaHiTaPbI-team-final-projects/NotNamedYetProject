using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Server.Models

{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Login {  get; set; }
        public string Password { get; set; }

        public decimal MonthLimit { get; set; }
        public decimal Income { get; set; }

        public virtual List<Card> Cards { get; set; }
        public virtual List<Receipt> Receipt { get; set; }
        public virtual List<Warranty> Warranties { get; set; }
        public virtual List<Account> Accounts { get; set; }
        public virtual List<Transaction> Transactions { get; set; }

    }
}
