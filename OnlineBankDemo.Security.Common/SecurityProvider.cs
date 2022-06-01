using System;
using System.Linq;
using System.Reflection;

namespace OnlineBankDemo.Security.Common
{
    /// <summary>
    /// Базовый класс, отвечающий за предоставление настроек безопасности
    /// </summary>
    public class SecurityProvider
    {

        /// <summary>
        /// Показывает, является ли данный тип класса защищенным
        /// </summary>
        /// <param name="type">Тип класса для проверки</param>
        /// <returns></returns>
        public bool IsClassSecured(Type type)
        {
            SecureClassAttribute sAttr;
            return IsClassSecured(type, out sAttr);
        }

        /// <summary>
        /// Показывает, является ли данный тип класса защищенным
        /// </summary>
        /// <param name="type">Тип класса для проверки</param>
        /// <param name="sAttribute">Описание атрибута безопасности</param>
        /// <returns></returns>
        public bool IsClassSecured(Type type, out SecureClassAttribute sAttribute)
        {
            return IsElementSecured(type, out sAttribute);
        }

        /// <summary>
        /// Показывает, является ли метод класса защищенным
        /// </summary>
        /// <param name="method">Описание метода для проверки</param>
        /// <param name="sAttribute">Описание атрибута безопасности</param>
        /// <returns></returns>
        public bool IsMethodSecured(MethodBase method, out SecureMethodAttribute sAttribute)
        {
            return IsElementSecured(method, out sAttribute);
        }

        /// <summary>
        /// Проверяет, является ли элемент защищенным
        /// </summary>
        /// <typeparam name="T">Тип элемента для проверка</typeparam>
        /// <param name="mInfo"></param>
        /// <param name="sAttribute">Описание атрибута по проверке</param>
        private bool IsElementSecured<T>(MemberInfo mInfo, out T sAttribute)
            where T : BaseSecurityAttribute
        {
            object[] attrs;

            try
            {
                attrs = mInfo.GetCustomAttributes(false);
            }
            catch (Exception)
            {
                sAttribute = null;
                return false;
            }

            sAttribute = attrs.OfType<T>().FirstOrDefault();
            return sAttribute != null;
        }

    }
}