using System.Collections;
using System.Reflection;
using System.Text;

namespace DotnetSandbox
{
    public static class LogHelper
    {
        public static string Dump(object dumpObject, string path)
        {
            if (dumpObject == null) 
                return string.Empty;

            if (dumpObject is string str) 
                return str;
            
            var sb = new StringBuilder();

            var dumpObjectType = dumpObject.GetType();
            var properties = dumpObjectType.GetProperties();
            path += (path == null ? "" : ":") + dumpObjectType.Name;

            foreach (var propertyInfo in properties)
            {
                var value = propertyInfo.GetValue(dumpObject, null);
                var valueType = value?.GetType();
                var propertyPath = path + "." + propertyInfo.Name;

                if (value == null)
                {
                    sb.Append($"[{propertyPath} = NULL]\n");
                }
                // else if (valueType.IsArray || valueType.GetInterface(nameof(IEnumerable)) != null)
                // {
                //     //foreach (var item in (IEnumerable)value)            
                //         sb.Append("[]");            
                // }
                else if (valueType.FullName != typeof(string).FullName && valueType.IsClass)
                {
                    sb.Append(Dump(value, propertyPath));
                }
                else
                {
                    sb.Append($"[{propertyPath} = {value}]\n");
                }
            }
            return sb.ToString();
        }
    }
}