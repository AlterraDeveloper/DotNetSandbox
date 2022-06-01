using System;

namespace OnlineBankDemo.Security.Common
{
    public abstract class BaseSecurityAttribute : Attribute
    {
        /// <summary>
        /// Описание элемента безопасности
        /// </summary>
        public string Description { get; set; }

        protected BaseSecurityAttribute(string description)
        {
            Description = description;
        }
    }
}