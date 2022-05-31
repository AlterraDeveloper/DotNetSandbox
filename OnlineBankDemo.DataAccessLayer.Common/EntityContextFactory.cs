using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Dynamic;

namespace OnlineBankDemo.DataAccessLayer.Common
{
    public interface IEntityContextFactory
    {
        DbContext Create(Type type);

        SqlConnection CreateConnection();
    }

    public abstract class BaseEntityContextFactory : IEntityContextFactory
    {
        public DbContext Create(Type type)
        {
            var instance = CreateInstance(type);
            instance.Configuration.ProxyCreationEnabled = false;
            instance.Configuration.LazyLoadingEnabled = false;
            return instance;
        }

        public abstract SqlConnection CreateConnection();
        
        // Template method - шаблонный метод - паттерн проектирования
        protected abstract DbContext CreateInstance(Type type);
    }
    
    /// <summary>
    /// Фабрика создания Entity контекста
    /// </summary>
    public abstract class BaseConnectionEntityContextFactory : BaseEntityContextFactory
    {
        public override SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        protected abstract string ConnectionString { get; }
    }
    
    /// <summary>
    /// Фабрика создания Entity контекста с возможностью указания названия строки поключения из config-файла
    /// </summary>
    public class CustomEntityContextFactory : BaseConnectionEntityContextFactory
    {
        public CustomEntityContextFactory(string connectionStringName)
        {
            ConnectionString = ConfigurationManager.AppSettings[connectionStringName];
        }

        protected override string ConnectionString { get; }

        protected override DbContext CreateInstance(Type type)
        {
            return (DbContext)Activator.CreateInstance(type, ConnectionString);
        }
    }
    
    public class EntityContextFactory : CustomEntityContextFactory
    {
        public EntityContextFactory() : base("DbConnectionString")
        {
        }
    }
    
    public class ReadOnlyEntityContextFactory : CustomEntityContextFactory
    {
        public ReadOnlyEntityContextFactory() : base("ReadOnlyDbConnectionString")
        {
        }
    }
}