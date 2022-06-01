using System;
using System.Diagnostics;
using System.Reflection;

namespace OnlineBankDemo.Security.Common
{
    public abstract class SecurityProviderValidator : ISecurityProviderValidator
    {
        public bool Approved(object obj, bool throwOnDeny)
        {
            var classType = obj.GetType();
            var provider = new SecurityProvider();
            if (!provider.IsClassSecured(classType, out var secureClassAttr))
                return true;
            // Validator.Approved
            // IsAccountsGetAllowed
            //     .......
            var st = new StackTrace(true);
            if (st.FrameCount <= 1)
                return true;

            StackFrame sf = st.GetFrame(1);
            MethodBase method = sf.GetMethod();
            SecureMethodAttribute sAttribute;

            if (!provider.IsMethodSecured(method, out sAttribute))
                return true;

            string namespaceName = classType.Namespace;
            string className = classType.Name;
            string methodName = method.Name;

            var result = InnerApproved(sAttribute, namespaceName, className, methodName);

            if (!result && throwOnDeny)
            {
                throw new Exception($@"Отсутствуют права ""{sAttribute.Description}"" в меню ""{secureClassAttr.Description }""  для выполнения данного действия ");
            }

            return result;
        }

        protected abstract bool InnerApproved(SecureMethodAttribute sAttribute, string namespaceName, string className,
            string methodName);
    }

    public class OpenAccessSecurityProviderValidator : SecurityProviderValidator
    {
        // public bool Approved(object obj, bool throwOnDeny)
        // {
        //     return true;
        // }

        protected override bool InnerApproved(SecureMethodAttribute sAttribute, string namespaceName, string className, string methodName)
        {
            return true;
        }
    }
    
    // public class RestrictAccessSecurityProviderValidator : ISecurityProviderValidator
    // {
    //     public bool Approved(object obj, bool throwOnDeny)
    //     {
    //         return false;
    //     }
    // }
    
    // public class DataBaseSecurityProviderValidator : SecurityProviderValidator
    // {
    //     protected override bool InnerApproved(SecureMethodAttribute sAttribute, string namespaceName, string className, string methodName)
    //     {
    //         return SecurityValidator.Approved(sAttribute, namespaceName, className, methodName);
    //     }
    // }
    
    
}