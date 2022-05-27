using OnlineBankDemo.DomainModel.Common;
using System.Data.Common;
using System.Data.Entity;

namespace OnlineBankDemo.DataAccessLayer.Common
{
    public class CommonEntityContext : DbContext
    {
        public CommonEntityContext(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
    }
}
