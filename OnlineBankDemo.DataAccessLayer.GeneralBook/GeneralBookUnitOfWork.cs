using OnlineBankDemo.DataAccessLayer.Common;

namespace OnlineBankDemo.DataAccessLayer.GeneralBook
{
    public class GeneralBookUnitOfWork : UnitOfWork<GeneralBookEntityContext>
    {
        public GeneralBookUnitOfWork(IEntityContextFactory factory) : base(factory)
        {
        }
        
        
    }
}