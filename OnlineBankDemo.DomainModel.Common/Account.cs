using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankDemo.DomainModel.Common
{
    [Table("Accounts", Schema = "dbo")] 
    public class Account
    {
        [Key]
        [Column(Order = 0)]
        public string AccountNo { get; set; }

        [Key]
        [Column(Order = 1)]
        public int CurrencyID { get; set; }

        public string AccountName { get; set; }

        public string BalanceGroup { get; set; }

        public decimal Balance { get; set; }

        public decimal BalanceN { get; set; }
    }
}
