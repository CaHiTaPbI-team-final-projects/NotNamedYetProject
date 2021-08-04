using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WithoutName.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
