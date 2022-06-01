using OnlineBankDemo.DataAccessLayer.Common;
using OnlineBankDemo.Security.Common;
using Unity;

namespace OnlineBankDemo.Service.Common
{
    public class CommonUnityConfig
    {
        public static void UnityConfig(IUnityContainer container)
        {
            container
                .RegisterType<IEntityContextFactory, EntityContextFactory>()
                .RegisterType<IUnitOfWork, CommonUnitOfWork>()
                .RegisterType<IUnitOfWork<CommonEntityContext>, CommonUnitOfWork>()
                .RegisterType<IReadOnlyUnitOfWork<CommonEntityContext>, CommonReadOnlyUnitOfWork>()
                .RegisterType<ISecurityProviderValidator, OpenAccessSecurityProviderValidator>()
                ;
        }
    }
}