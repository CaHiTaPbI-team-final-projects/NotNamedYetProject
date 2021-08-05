using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Server.Models

{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime BuyDate { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [MaxLength(int.MaxValue)]
        public byte[] Blob { get; set; }
    }
}
