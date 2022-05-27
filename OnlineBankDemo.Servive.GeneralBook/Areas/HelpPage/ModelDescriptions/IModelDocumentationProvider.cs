using System;
using System.Reflection;

namespace OnlineBankDemo.Servive.GeneralBook.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}